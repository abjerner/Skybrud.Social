using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Exceptions;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Common;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramResponse {

        /// <summary>
        /// Gets a reference to the underlying response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets information about rate limiting.
        /// </summary>
        public InstagramRateLimiting RateLimiting { get; private set; }

        protected InstagramResponse(SocialHttpResponse response) {
            Response = response;
            RateLimiting = InstagramRateLimiting.GetFromResponse(response);
        }

        public static void ValidateResponse(SocialHttpResponse response, JsonObject obj) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Get the "meta" object
            InstagramMetaData meta = obj.GetObject("meta", InstagramMetaData.Parse);

            // Now throw some exceptions
            if (meta.ErrorType == "OAuthException") throw new InstagramOAuthException(response, meta);
            if (meta.ErrorType == "OAuthAccessTokenException") throw new InstagramOAuthAccessTokenException(response, meta);
            if (meta.ErrorType == "APINotFoundError") throw new InstagramNotFoundException(response, meta);

            throw new InstagramException(response, meta);

        }

    }

    public class InstagramResponse<T> : InstagramResponse {

        public T Body { get; protected set; }

        protected InstagramResponse(SocialHttpResponse response) : base(response) { }

    }

    public class InstagramResponseBody<T> : SocialJsonObject {

        #region Properties

        public InstagramMetaData Meta { get; private set; }
        
        public T Data { get; protected set; }

        #endregion

        #region Constructors

        protected InstagramResponseBody(JsonObject obj) : base(obj) {
            Meta = obj.GetObject("meta", InstagramMetaData.Parse);
        }

        #endregion

    }

}