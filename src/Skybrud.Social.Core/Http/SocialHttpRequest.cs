using System;
using System.IO;
using System.Net;
using System.Text;

namespace Skybrud.Social.Http {

    /// <summary>
    /// Wrapper class for <see cref="HttpWebResponse"/>.
    /// </summary>
    public class SocialHttpRequest {

        #region Private fields

        private SocialHeaderCollection _headers = new SocialHeaderCollection();
        private SocialHttpQueryString _queryString = new SocialHttpQueryString();
        private SocialPostData _postData = new SocialPostData();
        private CookieContainer _cookies = new CookieContainer();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the HTTP method of the request.
        /// </summary>
        public SocialHttpMethod Method { get; set; }
        
        /// <summary>
        /// Gets or sets the credentials (username and password) of the request.
        /// </summary>
        public NetworkCredential Credentials { get; set; }

        /// <summary>
        /// Gets or sets the URL of the request. The query string can either be specified directly in the URL, or
        /// separately through the <see cref="QueryString"/> property.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the HTTP host of the request. If left blank, the host will be based on <see cref="Url"/>
        /// instead.
        /// </summary>
        public string Host { get; set; }

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
        public SocialHttpQueryString QueryString {
            get { return _queryString; }
            set { _queryString = value ?? new SocialHttpQueryString(); }
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

        /// <summary>
        /// Gets or sets the <see cref="CookieContainer"/> to be used for the request.
        /// </summary>
        public CookieContainer Cookies {
            get { return _cookies; }
            set { _cookies = value; }
        }

        #region HTTP Headers

        /// <summary>
        /// Gets a or sets a list of content types that are acceptable for the response - eg. <code>text/html</code>,
        /// <code>text/html,application/xhtml+xml</code> or <code>application/json</code>. This property corresponds to
        /// the <code>Accept</code> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Content_negotiation</cref>
        /// </see>
        public string Accept { get; set; }
        
        /// <summary>
        /// Gets or sets the character sets that are acceptable - eg. <code>utf8</code>. This property corresponds to
        /// the <code>Accept-Charset</code> HTTP header.
        /// </summary>
        public string AcceptCharset {
            get { return Headers.AcceptCharset; }
            set { Headers.AcceptCharset = value; }
        }

        /// <summary>
        /// Gets or sets the a list of acceptable encodings - eg. <code>gzip</code> or <code>gzip, deflate</code>. This
        /// property corresponds to the <code>Accept-Encoding</code> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/HTTP_compression</cref>
        /// </see>
        public string AcceptEncoding {
            get { return Headers.AcceptEncoding; }
            set { Headers.AcceptEncoding = value; }
        }

        /// <summary>
        /// Gets or sets the accept language header of the request - eg. <code>en-US</code>, <code>en</code> or
        /// <code>da</code>. This property corresponds to the <code>Accept-Language</code> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Content_negotiation</cref>
        /// </see>
        public string AcceptLanguage {
            get { return Headers.AcceptLanguage; }
            set { Headers.AcceptLanguage = value; }
        }

        /// <summary>
        /// Gets or sets the authentication credentials for HTTP authentication. This property corresponds to the
        /// <code>Authorization</code> HTTP header.
        /// </summary>
        public string Authorization {
            get { return Headers.Authorization; }
            set { Headers.Authorization = value; }
        }

        /// <summary>
        /// Gets or sets the address of the previous web page from which a link to the currently requested page was
        /// followed. (The word "referrer" has been misspelled in the RFC as well as in most implementations to the
        /// point that it has become standard usage and is considered correct terminology).  This property corresponds
        /// to the <code>Referer</code> HTTP header.
        /// </summary>
        public string Referer { get; set; }

        /// <summary>
        /// Gets or sets a string representing the user agent. This property corresponds to the <code>User-Agent</code>
        /// HTTP header.
        /// </summary>
        public string UserAgent { get; set; }

        #endregion

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
            request.Referer = Referer;
            request.UserAgent = UserAgent;
            request.Timeout = (int) Timeout.TotalMilliseconds;
            request.CookieContainer = Cookies;
            if (!String.IsNullOrWhiteSpace(Host)) request.Host = Host;

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