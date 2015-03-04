using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Responses {

    public class TwitterStatusMessageResponse : TwitterResponse<TwitterStatusMessage> {

        #region Constructors

        private TwitterStatusMessageResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static TwitterStatusMessageResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new TwitterStatusMessageResponse(response) {
                Body = JsonObject.ParseJson(response.Body, TwitterStatusMessage.Parse)
            };

        }

        #endregion

    }

}