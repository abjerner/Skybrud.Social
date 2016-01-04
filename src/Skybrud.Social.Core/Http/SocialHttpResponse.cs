using System.IO;
using System.Net;
using Skybrud.Social.Json;

namespace Skybrud.Social.Http {
    
    /// <summary>
    /// Wrapper class for <code>HttpWebResponse</code>.
    /// </summary>
    public class SocialHttpResponse {

        private string _body;

        #region Properties

        /// <summary>
        /// Gets a reference to the <code>SocialHttpRequest</code> that resulted in the response.
        /// </summary>
        public SocialHttpRequest Request { get; private set; }

        /// <summary>
        /// Gets a reference to the underlying <code>HttpWebResponse</code>.
        /// </summary>
        public HttpWebResponse Response { get; private set; }

        /// <summary>
        /// Gets the status code returned by the server.
        /// </summary>
        public HttpStatusCode StatusCode {
            get { return Response.StatusCode; }
        }

        /// <summary>
        /// Gets the status description returned by the server.
        /// </summary>
        public string StatusDescription {
            get { return Response.StatusDescription; }
        }

        /// <summary>
        /// Gets the HTTP method of the request to the server.
        /// </summary>
        public string Method {
            get { return Response.Method; }
        }

        /// <summary>
        /// Gets the content type of the request.
        /// </summary>
        public string ContentType {
            get { return Response.ContentType; }
        }

        /// <summary>
        /// Gets a collections of headers returned by the server.
        /// </summary>
        public WebHeaderCollection Headers {
            get { return Response.Headers; }
        }

        /// <summary>
        /// Gets the response body as a raw string.
        /// </summary>
        public string Body {
            get {
                if (_body == null) {
                    using (Stream stream = Response.GetResponseStream()) {
                        if (stream == null) return null;
                        using (StreamReader reader = new StreamReader(stream)) {
                            _body = reader.ReadToEnd();
                        }
                    }
                }
                return _body;
            }
        }

        #endregion

        #region Constructor

        private SocialHttpResponse(SocialHttpRequest request, HttpWebResponse response) {
            Request = request;
            Response = response;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the response body as a RAW string.
        /// </summary>
        public string GetBodyAsString() {
            return Body;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Creates a new instance based on the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The instance of <code>HttpWebResponse</code> to be parsed.</param>
        /// <returns>Returns a new instance of <code>SocialHttpResponse</code> based on the specified <code>response</code>.</returns>
        public static SocialHttpResponse GetFromWebResponse(HttpWebResponse response) {
            return response == null ? null : new SocialHttpResponse(null, response);
        }

        /// <summary>
        /// Creates a new instance based on the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The instance of <code>HttpWebResponse</code> to be parsed.</param>
        /// <param name="request">The instance of <code>SocialHttpRequest</code> that resulted in the response.</param>
        /// <returns>Returns a new instance of <code>SocialHttpResponse</code> based on the specified <code>response</code>.</returns>
        public static SocialHttpResponse GetFromWebResponse(HttpWebResponse response, SocialHttpRequest request) {
            return response == null ? null : new SocialHttpResponse(request, response);
        }

        #endregion

    }

}