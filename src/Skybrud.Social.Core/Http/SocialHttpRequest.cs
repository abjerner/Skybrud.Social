using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Http {

    /// <summary>
    /// Wrapper class for <see cref="HttpWebResponse"/>.
    /// </summary>
    public class SocialHttpRequest {

        #region Private fields

        private SocialHttpHeaderCollection _headers = new SocialHttpHeaderCollection();
        private IHttpQueryString _queryString = new SocialHttpQueryString();
        private IHttpPostData _postData = new SocialHttpPostData();
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
        public ICredentials Credentials { get; set; }

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

#if NET_FRAMEWORK

        /// <summary>
        /// Gets or sets the timeout of the request. Default is 100 seconds.
        /// </summary>
        public TimeSpan Timeout { get; set; }

#endif

        /// <summary>
        /// Gets or sets the collection of headers.
        /// </summary>
        public SocialHttpHeaderCollection Headers {
            get => _headers;
            set => _headers = value ?? new SocialHttpHeaderCollection();
        }

        /// <summary>
        /// Gets or sets the query string of the request.
        /// </summary>
        public IHttpQueryString QueryString {
            get => _queryString;
            set => _queryString = value ?? new SocialHttpQueryString();
        }

        /// <summary>
        /// Gets or sets the POST data of the request.
        /// </summary>
        public IHttpPostData PostData {
            get => _postData;
            set => _postData = value ?? new SocialHttpPostData();
        }

        /// <summary>
        /// Gets or sets the <see cref="CookieContainer"/> to be used for the request.
        /// </summary>
        public CookieContainer Cookies {
            get => _cookies;
            set => _cookies = value ?? new CookieContainer();
        }

        /// <summary>
        /// Gets or sets the content type of the request.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the body of the request.
        /// </summary>
        public string Body { get; set; }

        #region HTTP Headers

        /// <summary>
        /// Gets a or sets a list of content types that are acceptable for the response - eg. <c>text/html</c>,
        /// <c>text/html,application/xhtml+xml</c> or <c>application/json</c>. This property corresponds to the
        /// <c>Accept</c> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Content_negotiation</cref>
        /// </see>
        public string Accept { get; set; }
        
        /// <summary>
        /// Gets or sets the character sets that are acceptable - eg. <c>utf8</c>. This property corresponds to
        /// the <c>Accept-Charset</c> HTTP header.
        /// </summary>
        public string AcceptCharset {
            get => Headers.AcceptCharset;
            set => Headers.AcceptCharset = value;
        }

        /// <summary>
        /// Gets or sets the a list of acceptable encodings - eg. <c>gzip</c> or <c>gzip, deflate</c>. This
        /// property corresponds to the <c>Accept-Encoding</c> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/HTTP_compression</cref>
        /// </see>
        public string AcceptEncoding {
            get => Headers.AcceptEncoding;
            set => Headers.AcceptEncoding = value;
        }

        /// <summary>
        /// Gets or sets the accept language header of the request - eg. <c>en-US</c>, <c>en</c> or <c>da</c>. This
        /// property corresponds to the <c>Accept-Language</c> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Content_negotiation</cref>
        /// </see>
        public string AcceptLanguage {
            get => Headers.AcceptLanguage;
            set => Headers.AcceptLanguage = value;
        }

        /// <summary>
        /// Gets or sets the authentication credentials for HTTP authentication. This property corresponds to the
        /// <c>Authorization</c> HTTP header.
        /// </summary>
        public string Authorization {
            get => Headers.Authorization;
            set => Headers.Authorization = value;
        }

        /// <summary>
        /// Gets or sets the address of the previous web page from which a link to the currently requested page was
        /// followed. (The word "referrer" has been misspelled in the RFC as well as in most implementations to the
        /// point that it has become standard usage and is considered correct terminology). This property corresponds
        /// to the <c>Referer</c> HTTP header.
        /// </summary>
        public string Referer { get; set; }

        /// <summary>
        /// Gets or sets a string representing the user agent. This property corresponds to the <c>User-Agent</c>
        /// HTTP header.
        /// </summary>
        public string UserAgent { get; set; }

        #endregion

#if NET_STANDARD2

        /// <summary>
        /// Gets or sets the type of decompression that is used.
        /// </summary>
        public DecompressionMethods AutomaticDecompression { get; set; }

        /// <summary>
        /// Gets or sets the media type of the request.
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        /// Gets or sets the value of the <strong>Transfer-encoding</strong> HTTP header.
        /// </summary>
        public string TransferEncoding { get; set; }

        /// <summary>
        /// Gets or sets the value of the <strong>Connection</strong> HTTP header.
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Gets or sets the value of the <strong>Expect</strong> HTTP header.
        /// </summary>
        public string Expect { get; set; }

#endif

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new request with default options.
        /// </summary>
        public SocialHttpRequest() {
            Method = SocialHttpMethod.Get;
            Encoding = Encoding.UTF8;
#if NET_FRAMEWORK
            Timeout = TimeSpan.FromSeconds(100);
#endif
            PostData = new SocialHttpPostData();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the request and returns the corresponding response as an instance of <see cref="SocialHttpResponse"/>.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public SocialHttpResponse GetResponse() {
            return GetResponse(null);
        }

        /// <summary>
        /// Executes the request and returns the corresponding response as an instance of <see cref="SocialHttpResponse"/>.
        /// </summary>
        /// <param name="callback">Lets you specify a callback method for modifying the underlying <see cref="HttpWebRequest"/>.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
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
            request.CookieContainer = Cookies;
            if (!String.IsNullOrWhiteSpace(ContentType)) request.ContentType = ContentType;

#if NET_FRAMEWORK
            request.Timeout = (int) Timeout.TotalMilliseconds;
            if (!String.IsNullOrWhiteSpace(Host)) request.Host = Host;
            if (!String.IsNullOrWhiteSpace(UserAgent)) request.UserAgent = UserAgent;
            if (!String.IsNullOrWhiteSpace(Referer)) request.Referer = Referer;
#endif

#if NET_STANDARD2
            request.AutomaticDecompression = AutomaticDecompression;
            request.MediaType = MediaType;
            request.TransferEncoding = TransferEncoding;
            request.Connection = Connection;
            request.Expect = Expect;
#endif

#if NET_STANDARD
            if (!String.IsNullOrWhiteSpace(Host)) request.Headers["Host"] = Host;
            if (!String.IsNullOrWhiteSpace(UserAgent)) request.Headers["User-Agent"] = UserAgent;
            if (!String.IsNullOrWhiteSpace(Referer)) request.Headers["Referer"] = Referer;


#endif

            // Handle various POST scenarios
            if (!String.IsNullOrWhiteSpace(Body)) {

                // Set the length of the request body
                SetRequestContentLength(request, Body.Length);

                // Write the body to the request stream
                Task<Stream> hest = request.GetRequestStreamAsync();
                using (Stream stream = hest.Result) {
                    stream.Write(Encoding.UTF8.GetBytes(Body), 0, Body.Length);
                }

            } else if (Method == SocialHttpMethod.Post || Method == SocialHttpMethod.Put || Method == SocialHttpMethod.Patch || Method == SocialHttpMethod.Delete) {
                
                // Make sure we have a POST data instance
                PostData = PostData ?? new SocialHttpPostData();

                if (PostData.IsMultipart) {

                    // Declare the boundary to be used for the multipart data
                    string boundary = Guid.NewGuid().ToString().Replace("-", "");

                    // Set the content type (including the boundary)
                    request.ContentType = "multipart/form-data; boundary=" + boundary;

                    // Write the multipart body to the request stream
                    Task<Stream> hest = request.GetRequestStreamAsync();
                    hest.Wait();
                    using (Stream stream = hest.Result) {
                        PostData.WriteMultipartFormData(stream, boundary);
                    }

                } else {
                    
                    // Convert the POST data to an URL encoded string
                    string dataString = PostData.ToString();
                    
                    // Set the content type
                    request.ContentType = "application/x-www-form-urlencoded";

                    // Set the length of the request body
                    SetRequestContentLength(request, dataString.Length);

                    // Write the body to the request stream
                    Task<Stream> hest = request.GetRequestStreamAsync();
                    hest.Wait();
                    using (Stream stream = hest.Result) {
                        stream.Write(Encoding.UTF8.GetBytes(dataString), 0, dataString.Length);
                    }

                }
                
            }
            
            // Call the callback
            callback?.Invoke(request);

            // Get the response
            try {

                #if NET_STANDARD

                Task<WebResponse> responseTask = request.GetResponseAsync();

                responseTask.Wait();

                return SocialHttpResponse.GetFromWebResponse(responseTask.Result as HttpWebResponse, this);

                #endif

                #if NET_FRAMEWORK
                
                return SocialHttpResponse.GetFromWebResponse(request.GetResponse() as HttpWebResponse, this);

                #endif

            } catch (WebException ex) {
                if (ex.Status != WebExceptionStatus.ProtocolError) throw;
                return SocialHttpResponse.GetFromWebResponse(ex.Response as HttpWebResponse, this);
            }

        }

        private void SetRequestContentLength(HttpWebRequest request, int contentLength) {
#if NET_FRAMEWORK
            request.ContentLength = contentLength;
#endif
#if NET_STANDARD
            request.Headers["Content-Length"] = contentLength.ToString();
#endif
        }

        #endregion

    }

}