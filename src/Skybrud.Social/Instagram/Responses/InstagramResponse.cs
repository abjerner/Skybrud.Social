using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Exceptions;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Common;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    /// <summary>
    /// Class representing a response from the Instagram API.
    /// </summary>
    public class InstagramResponse : SocialResponse {

        #region Properties
        
        /// <summary>
        /// Gets information about rate limiting.
        /// </summary>
        public InstagramRateLimiting RateLimiting { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        protected InstagramResponse(SocialHttpResponse response) : base(response) {
            RateLimiting = InstagramRateLimiting.GetFromResponse(response);
        }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        /// <param name="obj">The object representing the response object.</param>
        public static void ValidateResponse(SocialHttpResponse response, JsonObject obj) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Get the "meta" object (may be the root object for some errors)
            InstagramMetaData meta = obj.HasValue("code") ? InstagramMetaData.Parse(obj) : obj.GetObject("meta", InstagramMetaData.Parse);

            // Now throw some exceptions
            if (meta.ErrorType == "OAuthException") throw new InstagramOAuthException(response, meta);
            if (meta.ErrorType == "OAuthAccessTokenException") throw new InstagramOAuthAccessTokenException(response, meta);
            if (meta.ErrorType == "APINotFoundError") throw new InstagramNotFoundException(response, meta);

            throw new InstagramException(response, meta);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Instagram API.
    /// </summary>
    public class InstagramResponse<T> : InstagramResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        protected InstagramResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a response from the Instagram API.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InstagramResponseBody<T> : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets meta data about the response.
        /// </summary>
        public InstagramMetaData Meta { get; private set; }
        
        /// <summary>
        /// Gets the data of the response.
        /// </summary>
        public T Data { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> representing the response body.</param>
        protected InstagramResponseBody(JsonObject obj) : base(obj) {
            Meta = obj.GetObject("meta", InstagramMetaData.Parse);
        }

        #endregion

    }

}