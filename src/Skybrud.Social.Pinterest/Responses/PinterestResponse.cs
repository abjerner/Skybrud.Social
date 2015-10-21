using System;
using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Json.Extensions.JObject;
using Skybrud.Social.Pinterest.Exceptions;
using Skybrud.Social.Pinterest.Objects;

namespace Skybrud.Social.Pinterest.Responses {

    /// <summary>
    /// Class representing a response from the Pinterest API.
    /// </summary>
    public abstract class PinterestResponse : SocialResponse {

        #region Constructor

        protected PinterestResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Parse the JSON response
            PinterestError error = SocialUtils.ParseJsonObject(response.Body, PinterestError.Parse);

            // Throw the exception
            throw new PinterestException(response, error);

        }

        #endregion

    }
    
    /// <summary>
    /// Class representing a response from the Pinterest API.
    /// </summary>
    public class PinterestResponse<T> : PinterestResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        protected PinterestResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}