using System;
using Skybrud.Social.Http;
using Skybrud.Social.Pinterest.Objects;

namespace Skybrud.Social.Pinterest.Exceptions {

    /// <summary>
    /// Class representing an exception based on an error from the Pinterest API.
    /// </summary>
    public class PinterestException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <code>SocialHttpResponse</code>.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets a reference to an object with information about the error.
        /// </summary>
        public PinterestError Error { get; private set; }

        #endregion

        #region Constructors

        public PinterestException(SocialHttpResponse response, PinterestError error) : base("The Pinterest API responded with an error (" + error.Message + ")") {
            Response = response;
            Error = error;
        }

        #endregion

    }

}