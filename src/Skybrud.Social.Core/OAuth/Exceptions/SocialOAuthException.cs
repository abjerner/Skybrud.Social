using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.OAuth.Exceptions {
    
    /// <summary>
    /// Class representing an OAuth exception
    /// </summary>
    public class SocialOAuthException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="response">The underlying response.</param>
        /// <param name="message">The message.</param>
        public SocialOAuthException(SocialHttpResponse response, string message) : base(message) {
            Response = response;
        }

        #endregion

    }

}