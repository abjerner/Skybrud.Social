using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramResponse {

        /// <summary>
        /// Gets a reference to the underlying response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        protected InstagramResponse(SocialHttpResponse response) {
            Response = response;
        }

        public static void ValidateResponse(SocialHttpResponse response, JsonObject obj) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Get the "meta" object
            JsonObject meta = obj.GetObject("meta");

            // Get some values from the "meta" object
            int code = meta.GetInt32("code");
            string type = meta.GetString("error_type");
            string message = meta.GetString("error_message");

            // Now throw some exceptions
            if (type == "OAuthException") throw new InstagramOAuthException(code, type, message);
            if (type == "OAuthAccessTokenException") throw new InstagramOAuthAccessTokenException(code, type, message);
            if (type == "APINotFoundError") throw new InstagramNotFoundException(code, type, message);

            throw new InstagramException(code, type, message);

        }

    }

    public class InstagramResponse<T> : InstagramResponse {

        public T Body { get; protected set; }

        protected InstagramResponse(SocialHttpResponse response) : base(response) { }

    }

    public class InstagramResponseBody<T> {

        public object Meta { get; set; }
        
        public T Data { get; set; } 

    }

}
