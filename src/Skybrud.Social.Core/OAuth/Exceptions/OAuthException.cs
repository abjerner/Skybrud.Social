using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.OAuth.Exceptions {
    
    /// <summary>
    /// Class representing an OAuth exception
    /// </summary>
    public class OAuthException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>response</code> and <code>message</code>.
        /// </summary>
        /// <param name="response">The underlying response.</param>
        /// <param name="message">The message.</param>
        public OAuthException(SocialHttpResponse response, string message) : base(message) {
            Response = response;
        }

        #endregion

    }

}