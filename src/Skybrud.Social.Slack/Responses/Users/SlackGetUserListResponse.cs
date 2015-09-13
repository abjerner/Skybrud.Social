using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Slack.Objects.Users;

namespace Skybrud.Social.Slack.Responses.Users {

    public class SlackGetUserListResponse : SlackResponse<SlackUsersResponseBody> {

        #region Constructors

        private SlackGetUserListResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>SlackGetUserListResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>WindowsLiveUserResponse</code>.</returns>
        public static SlackGetUserListResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new SlackGetUserListResponse(response) {
                Body = JsonObject.ParseJson(response.Body, SlackUsersResponseBody.Parse)
            };

        }

        #endregion

    }

}