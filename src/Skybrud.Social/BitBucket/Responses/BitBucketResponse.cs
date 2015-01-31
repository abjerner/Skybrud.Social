using System.Net;
using Skybrud.Social.BitBucket.Exceptions;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Responses {

    public class BitBucketResponse {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        protected BitBucketResponse(SocialHttpResponse response) {
            Response = response;
        }

        #endregion

        #region Static methods

        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Otherwise throw an exception
            throw new BitBucketException(response);

        }

        #endregion

    }

    public class BitBucketResponse<T> : BitBucketResponse {

        public T Body { get; protected set; }

        protected BitBucketResponse(SocialHttpResponse response) : base(response) { }

    }

}