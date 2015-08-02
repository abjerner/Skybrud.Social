using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Google.Analytics.Exceptions {

    /// <summary>
    /// Class representing an exception returned by the Analytics API.
    /// </summary>
    public class AnalyticsException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <code>SocialHttpResponse</code>.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets the error code of the response.
        /// </summary>
        public int Code { get; private set; }

        #endregion

        #region Constructors

        internal AnalyticsException(SocialHttpResponse response, int code, string message) : base(message) {
            Response = response;
            Code = code;
        }

        #endregion

    }

}