using System;
using System.Net;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Exceptions {
    
    public class BitBucketException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <code>SocialHttpResponse</code>.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets the HTTP status code returned by the BitBucket API.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        #endregion

        #region Constructors

        public BitBucketException(SocialHttpResponse response) : base("Invalid response received from the BitBucket API (Status: " + ((int) response.StatusCode) + ")") {
            Response = response;
            StatusCode = response.StatusCode;
        }

        #endregion

    }

}