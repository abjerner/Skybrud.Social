using System.Net;
using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {

    public class FacebookResponse {

        /// <summary>
        /// Gets a reference to the underlying response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        protected FacebookResponse(SocialHttpResponse response) {
            Response = response;
        }

        public static void ValidateResponse(SocialHttpResponse response, JsonObject obj) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;
            
            // Throw an exception based on the error message from the API
            JsonObject error = obj.GetObject("error");
            int code = error.GetInt32("code");
            string type = error.GetString("type");
            string message = error.GetString("message");
            int subcode = error.HasValue("error_subcode") ? error.GetInt32("error_subcode") : 0;
            throw new FacebookApiException(code, type, message, subcode);
        
        }

    }

    public class FacebookResponse<T> : FacebookResponse {

        public T Body { get; protected set; }

        protected FacebookResponse(SocialHttpResponse response) : base(response) { }

    }

}