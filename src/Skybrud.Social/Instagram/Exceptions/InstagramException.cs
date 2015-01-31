using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Instagram.Exceptions {

    public class InstagramException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <code>SocialHttpResponse</code>.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets the error code received from the Instagram API.
        /// </summary>
        public int Code { get; private set; }

        /// <summary>
        /// Gets the type of the error received from the Instagram API.
        /// </summary>
        public string Type { get; private set; }

        #endregion

        #region Constructors

        internal InstagramException(SocialHttpResponse response, int code, string type, string message) : base(message) {
            Response = response;
            Code = code;
            Type = type;
        }

        #endregion

    }

}