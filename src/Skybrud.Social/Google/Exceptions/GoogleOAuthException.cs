using System;

namespace Skybrud.Social.Google.Exceptions {
    
    public class GoogleOAuthException : Exception {

        #region Properties

        public string Error { get; private set; }

        /// <summary>
        /// A more user-friendly description of the error. The description may not be specified for all errors.
        /// </summary>
        public string Description { get; private set; }

        #endregion

        #region Constructors

        public GoogleOAuthException(string error, string description) : base(description ?? error) {
            Error = error;
            Description = description;
        }

        #endregion

    }

}
