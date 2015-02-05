using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Twitter.Exceptions {

    public class TwitterException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <code>SocialHttpResponse</code>.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets the error code received from the Twitter API.
        /// </summary>
        public int Code { get; private set; }

        #endregion

        #region Constructors

        internal TwitterException(SocialHttpResponse response, string message, int code) : base(message) {
            Response = response;
            Code = code;
        }

        #endregion

    }

}