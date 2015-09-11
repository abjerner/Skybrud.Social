using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Microsoft.Responses;
using Skybrud.Social.Microsoft.WindowsLive.Objects;
using System;
using Skybrud.Social.Microsoft.WindowsLive.Objects.Users;

namespace Skybrud.Social.Microsoft.WindowsLive.Responses {

    /// <summary>
    /// Class representing the response of a call to get information about a single Windows Live user.
    /// </summary>
    public class WindowsLiveUserResponse : MicrosoftResponse<WindowsLiveUser> {

        #region Constructors

        private WindowsLiveUserResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>WindowsLiveUserResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>WindowsLiveUserResponse</code>.</returns>
        public static WindowsLiveUserResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new WindowsLiveUserResponse(response) {
                Body = JsonObject.ParseJson(response.Body, WindowsLiveUser.Parse)
            };

        }

        #endregion

    }

}