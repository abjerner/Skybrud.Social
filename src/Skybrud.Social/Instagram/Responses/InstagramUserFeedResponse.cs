using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramUserFeedResponse : InstagramResponse<InstagramUserFeedResponseBody> {

        #region Constructors

        private InstagramUserFeedResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramUserFeedResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramUserFeedResponse(response) {
                Body = InstagramUserFeedResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramUserFeedResponseBody : InstagramResponseBody<InstagramMedia[]> {

        #region Constructors

        protected InstagramUserFeedResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramUserFeedResponseBody Parse(JsonObject obj) {
            return new InstagramUserFeedResponseBody(obj) {
                Data = obj.GetArray("data", InstagramMedia.Parse)
            };
        }

        #endregion

    }

}