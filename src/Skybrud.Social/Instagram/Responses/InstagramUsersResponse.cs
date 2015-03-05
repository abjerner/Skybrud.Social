using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramUsersResponse : InstagramResponse<InstagramUsersResponseBody> {

        #region Constructors

        private InstagramUsersResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramUsersResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramUsersResponse(response) {
                Body = InstagramUsersResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramUsersResponseBody : InstagramResponseBody<InstagramUserSummary[]> {

        #region Constructors

        protected InstagramUsersResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramUsersResponseBody Parse(JsonObject obj) {
            return new InstagramUsersResponseBody(obj) {
                Data = obj.GetArray("data", InstagramUserSummary.Parse)
            };
        }

        #endregion

    }

}