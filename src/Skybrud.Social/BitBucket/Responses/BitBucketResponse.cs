using System.Net;
using Skybrud.Social.BitBucket.Exceptions;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Responses {

    /// <summary>
    /// Class representing a response from the BitBucket API.
    /// </summary>
    public class BitBucketResponse : SocialResponse {

        #region Constructors

        protected BitBucketResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Otherwise throw an exception
            throw new BitBucketException(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the BitBucket API.
    /// </summary>
    public class BitBucketResponse<T> : BitBucketResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        protected BitBucketResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}