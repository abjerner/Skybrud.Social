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
        private NameValueCollection _postData = new NameValueCollection();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the HTTP method of the request.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the accept headerof the request.
        /// </summary>
        public string Accept { get; set; }

        /// <summary>
        /// Gets or sets the user agent header of the request.
        /// </summary>
        public string UserAgent { get; set; }

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
        public NameValueCollection PostData {
            get { return _postData; }
            set { _postData = value ?? new NameValueCollection(); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new request with default options.
        /// </summary>
        public SocialHttpRequest() {
            Method = "GET";
            Encoding = Encoding.UTF8;
            Timeout = TimeSpan.FromSeconds(100);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the request and returns the corresponding response as an instance of <code>SocialHttpResponse</code>.
        /// </summary>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetResponse() {
            return GetResponse(null);
        }

        /// <summary>
        /// Executes the request and returns the corresponding response as an instance of <code>SocialHttpResponse</code>.
        /// </summary>
        /// <param name="callback">Lets you specify a callback method for modifying the underlying <code>HttpWebRequest</code>.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetResponse(Action<HttpWebRequest> callback) {

            // Build the URL
            string url = Url;
            if (QueryString != null && !QueryString.IsEmpty) url += (url.Contains("?") ? "&" : "?") + QueryString;

            // Initialize the request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // Misc
            request.Method = Method;
            request.Credentials = Credentials;
            request.Headers = Headers.Headers;
            request.Accept = Accept;
            request.UserAgent = UserAgent;
            request.Timeout = (int) Timeout.TotalMilliseconds;

            // Add the request body (if a POST request)
            if (Method == "POST" && PostData != null && PostData.Count > 0) {
                string dataString = SocialUtils.NameValueCollectionToQueryString(PostData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = dataString.Length;
                using (Stream stream = request.GetRequestStream()) {
                    stream.Write(Encoding.UTF8.GetBytes(dataString), 0, dataString.Length);
                }
            }

            // Call the callback
            if (callback != null) callback(request);

            // Get the response
            try {
                return SocialHttpResponse.GetFromWebResponse(request.GetResponse() as HttpWebResponse);
            } catch (WebException ex) {
                if (ex.Status != WebExceptionStatus.ProtocolError) throw;
                return SocialHttpResponse.GetFromWebResponse(ex.Response as HttpWebResponse);
            }

        }

        #endregion

    }

}