using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Slack.Objects.Authentication;

namespace Skybrud.Social.Slack.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a call to get an access token.
    /// </summary>
    public class SlackTokenResponse : SlackResponse<SlackTokenInfo> {
        
        #region Constructors

        private SlackTokenResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>SlackTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>SlackTokenResponse</code>.</returns>
        public static SlackTokenResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");
            
            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new SlackTokenResponse(response) {
                Body = JsonObject.ParseJson(response.Body, SlackTokenInfo.Parse)
            };

        }

        #endregion

    }

}