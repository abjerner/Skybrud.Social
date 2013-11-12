namespace Skybrud.Social.OAuth {

    public class OAuthRequestToken {

        #region Properties

        /// <summary>
        /// The request token.
        /// </summary>
        public string Token { get; internal set; }

        /// <summary>
        /// The request token secret.
        /// </summary>
        public string TokenSecret { get; internal set; }

        /// <summary>
        /// Is the callback confirmed?
        /// </summary>
        public bool CallbackConfirmed { get; internal set; }

        /// <summary>
        /// Gets the authentication URL based for this request token.
        /// </summary>
        public string AuthorizeUrl { get; internal set; }

        #endregion

        #region Constructor(s)

        internal OAuthRequestToken() {
            // make constructor internal
        }

        #endregion

    }

}