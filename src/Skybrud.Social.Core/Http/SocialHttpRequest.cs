using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Skybrud.Social.Http {

    /// <summary>
    /// Wrapper class for <code>HttpWebResponse</code>.
    /// </summary>
    public class SocialHttpRequest {

        #region Private fields

        private SocialHeaderCollection _headers = new SocialHeaderCollection();
        private SocialQueryString _queryString = new SocialQueryString();
        private SocialPostData _postData = new SocialPostData();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the HTTP method of the request.
        /// </summary>
        public SocialHttpMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the accept header of the request.
        /// </summary>
        public string Accept { get; set; }

        /// <summary>
        /// Gets or sets the user agent header of the request.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the accept language of the request.
        /// </summary>
        public string AcceptLanguage {
            get { return Headers.Headers["Accept-Language"]; }
            set { Headers.Headers["Accept-Language"] = value; }
        }

        /// <summary>
        /// Gets or sets the authorization header of the request.
        /// </summary>
        public string Authorization {
            get { return Headers.Authorization; }
            set { Headers.Authorization = value; }
        }

        /// <summary>
        /// Gets or sets the credentials (username and password) of the request.
        /// </summary>
        public NetworkCredential Credentials { get; set; }

        /// <summary>
        /// Gets or sets the URL of the request. The query string can either be specified directly in the URL, or
        /// separately through the <code>QueryString</code> property.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the encoding of the request. Default is UTF-8.
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// Gets or sets the timeout of the request. Default is 100 seconds.
        /// </summary>
        public TimeSpan Timeout { get; set; }

        /// <summary>
        /// Gets or sets the collection of headers.
        /// </summary>
        public SocialHeaderCollection Headers {
            get { return _headers; }
            set { _headers = value ?? new SocialHeaderCollection(); }
        }

        /// <summary>
        /// Gets or sets the query string of the request.
        /// </summary>
        public SocialQueryString QueryString {
            get { return _queryString; }
            set { _queryString = value ?? new SocialQueryString(); }
        }

        /// <summary>
        /// Gets or sets the POST data of the request.
        /// </summary>
        public SocialPostData PostData {
            get { return _postData; }
            set { _postData = value ?? new SocialPostData(); }
        }

        /// <summary>
        /// Gets or sets whether the content type of the HTTP POST request should be <code>multipart/form-data</code>.
        /// If this property is <code>false</code> for a HTTP POST request, the content type
        /// <code>application/x-www-form-urlencoded</code> will be used as default instead. If not a HTTP POST request,
        /// this property will be ignored.
        /// </summary>
        public bool IsMultipart { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new request with default options.
        /// </summary>
        public SocialHttpRequest() {
            Method = SocialHttpMethod.Get;
            Encoding = Encoding.UTF8;
            Timeout = TimeSpan.FromSeconds(100);
            PostData = new SocialPostData();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the request and returns the corresponding response as an instance of <see cref="SocialHttpResponse"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public SocialHttpResponse GetResponse() {
            return GetResponse(null);
        }

        /// <summary>
        /// Executes the request and returns the corresponding response as an instance of <see cref="SocialHttpResponse"/>.
        /// </summary>
        /// <param name="callback">Lets you specify a callback method for modifying the underlying <see cref="HttpWebRequest"/>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public SocialHttpResponse GetResponse(Action<HttpWebRequest> callback) {

            // Build the URL
            string url = Url;
            if (QueryString != null && !QueryString.IsEmpty) url += (url.Contains("?") ? "&" : "?") + QueryString;

            // Initialize the request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // Misc
            request.Method = Method.ToString().ToUpper();
            request.Credentials = Credentials;
            request.Headers = Headers.Headers;
            request.Accept = Accept;
            request.UserAgent = UserAgent;
            request.Timeout = (int) Timeout.TotalMilliseconds;

            // Add the request body (if a POST request)
            if (Method == SocialHttpMethod.Post) {
                if (IsMultipart) {
                    string boundary = Guid.NewGuid().ToString().Replace("-", "");
                    request.ContentType = "multipart/form-data; boundary=" + boundary;
                    using (Stream stream = request.GetRequestStream()) {
                        PostData.WriteMultipartFormData(stream, boundary);
                    }
                } else {
                    string dataString = PostData.ToString();
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = dataString.Length;
                    using (Stream stream = request.GetRequestStream()) {
                        stream.Write(Encoding.UTF8.GetBytes(dataString), 0, dataString.Length);
                    }
                }
            }

            // Call the callback
            if (callback != null) callback(request);

            // Get the response
            try {
                return SocialHttpResponse.GetFromWebResponse(request.GetResponse() as HttpWebResponse, this);
            } catch (WebException ex) {
                if (ex.Status != WebExceptionStatus.ProtocolError) throw;
                return SocialHttpResponse.GetFromWebResponse(ex.Response as HttpWebResponse, this);
            }

        }

        #endregion

    }

}