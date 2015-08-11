using System.Net;
using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {

    /// <summary>
    /// Class representing a response from the Facebook Graph API.
    /// </summary>
    public class FacebookResponse : SocialResponse {

        #region Constructors

        protected FacebookResponse(SocialHttpResponse response) : base(response) { }

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
            
            // Throw an exception based on the error message from the API
            JsonObject error = obj.GetObject("error");
            int code = error.GetInt32("code");
            string type = error.GetString("type");
            string message = error.GetString("message");
            int subcode = error.HasValue("error_subcode") ? error.GetInt32("error_subcode") : 0;
            throw new FacebookException(response, code, type, message, subcode);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Facebook Graph API.
    /// </summary>
    public class FacebookResponse<T> : FacebookResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        protected FacebookResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}