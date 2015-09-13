using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Slack.Exceptions {

    /// <summary>
    /// Class representing an exception based on an error from the Slack API.
    /// </summary>
    public class SlackException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <code>SocialHttpResponse</code>.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets the error returned by the Slack API.
        /// </summary>
        public string Error { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified parameters.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="error">The error.</param>
        public SlackException(SocialHttpResponse response, string error) : base("Invalid response received from the Slack API: " + error) {
            Response = response;
            Error = error;
        }

        #endregion

    }

}