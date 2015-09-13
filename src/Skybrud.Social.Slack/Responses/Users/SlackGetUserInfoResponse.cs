using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Slack.Objects.Users;

namespace Skybrud.Social.Slack.Responses.Users {

    public class SlackGetUserInfoResponse : SlackResponse<SlackUserResponseBody> {

        #region Constructors

        private SlackGetUserInfoResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>SlackGetUserInfoResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>SlackGetUserInfoResponse</code>.</returns>
        public static SlackGetUserInfoResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new SlackGetUserInfoResponse(response) {
                Body = JsonObject.ParseJson(response.Body, SlackUserResponseBody.Parse)
            };

        }

        #endregion

    }

}