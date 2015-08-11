using System.Net;

namespace Skybrud.Social.Http {
    
    /// <summary>
    /// Class representing a response from a call to a server. Generally this class should be used to represent the
    /// object oriented (parsed) response wrapping an instance of <code>SocialHttpResponse</code> (raw response).
    /// </summary>
    public class SocialResponse {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

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

        #endregion

        #region Constructors

        protected SocialResponse(SocialHttpResponse response) {
            Response = response;
        }

        #endregion

    }

}