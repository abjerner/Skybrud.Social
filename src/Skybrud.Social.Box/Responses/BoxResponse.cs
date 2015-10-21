using System;
using System.Net;
using Skybrud.Social.Http;

namespace Skybrud.Social.Box.Responses {

    /// <summary>
    /// Class representing a response from of the Box.com API.
    /// </summary>
    public abstract class BoxResponse : SocialResponse {

        #region Constructor

        protected BoxResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Now throw some exceptions
            throw new Exception("WTF?");

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from of the Box.com API.
    /// </summary>
    public class BoxResponse<T> : BoxResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        protected BoxResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}