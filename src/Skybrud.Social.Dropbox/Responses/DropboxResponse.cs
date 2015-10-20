using System;
using System.Net;
using Skybrud.Social.Http;

namespace Skybrud.Social.Dropbox.Responses {

    /// <summary>
    /// Class representing a response from of the Dropbox API.
    /// </summary>
    public abstract class DropboxResponse : SocialResponse {

        #region Constructor

        protected DropboxResponse(SocialHttpResponse response) : base(response) { }

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
    /// Class representing a response from of the Dropbox API.
    /// </summary>
    public class DropboxResponse<T> : DropboxResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        protected DropboxResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}