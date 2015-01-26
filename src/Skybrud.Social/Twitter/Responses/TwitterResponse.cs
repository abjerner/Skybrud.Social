using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Exceptions;

namespace Skybrud.Social.Twitter.Responses {

    public class TwitterResponse {

        /// <summary>
        /// Gets a reference to the underlying response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        protected TwitterResponse(SocialHttpResponse response) {
            Response = response;
        }

        public static void ValidateResponse(SocialHttpResponse response, JsonObject obj) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Get the "errors" array
            JsonArray errors = obj.GetArray("errors");

            // Get the first error (don't remember ever seeing multiple errors in the same response)
            JsonObject error = errors.GetObject(0);

            // Throw the exception
            throw new TwitterApiException(response, error.GetString("message"), error.GetInt32("code"));

        }

    }

    public class TwitterResponse<T> : TwitterResponse {

        public T Body { get; protected set; }

        protected TwitterResponse(SocialHttpResponse response) : base(response) { }

    }

}