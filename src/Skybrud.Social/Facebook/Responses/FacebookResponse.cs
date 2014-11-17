using System;
using System.Net;
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

    }

    public class FacebookResponse<T> : FacebookResponse {

        public T Data { get; private set; }

        protected FacebookResponse(SocialHttpResponse response) : base(response) { }

        #region Static methods

        public static FacebookResponse<T> ParseResponse(SocialHttpResponse response, Func<JsonObject, T> func) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            if (response.StatusCode != HttpStatusCode.OK) {
                // TODO: Cast exception of type FacebookException
                throw new Exception(obj.GetString("message"));
            }

            // Initialize the response object
            return new FacebookResponse<T>(response) {
                Data = func(obj)
            };

        }

        #endregion

    }

}
