using System.Net;

namespace Skybrud.Social.Http {
    
    /// <summary>
    /// Interface describing a response.
    /// </summary>
    public interface IResponse {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying raw response.
        /// </summary>
        SocialHttpResponse Response { get; }

        /// <summary>
        /// Gets the status code returned by the server.
        /// </summary>
        HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the status description returned by the server.
        /// </summary>
        string StatusDescription { get; }

        /// <summary>
        /// Gets the HTTP method of the request to the server.
        /// </summary>
        string Method { get; }

        /// <summary>
        /// Gets the content type of the response.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Gets a collection of headers returned by the server.
        /// </summary>
        SocialHttpHeaderCollection Headers { get; }

        #endregion

    }

}