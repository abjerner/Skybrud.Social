using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Exceptions {

    /// <summary>
    /// Class representing an exception based on an error from the Facebook Graph API.
    /// </summary>
    public class FacebookException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <code>SocialHttpResponse</code>.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets the error code received from the Facebook API.
        /// </summary>
        public int Code { get; private set; }

        /// <summary>
        /// Gets the type of the error received from the Facebook API.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the sub error code received from the Facebook API. If a sub error code isn't specified in the
        /// response, <code>0</code> will be returned.
        /// </summary>
        public int Subcode { get; private set; }

        #endregion

        #region Constructors

        public FacebookException(SocialHttpResponse response, int code, string type, string message, int subcode = 0) : base(message) {
            Response = response;
            Code = code;
            Type = type;
            Subcode = subcode;
        }

        #endregion

    }

}