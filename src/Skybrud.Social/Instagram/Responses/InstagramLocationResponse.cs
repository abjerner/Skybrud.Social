using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramLocationResponse : InstagramResponse<InstagramLocationResponseBody> {

        #region Constructors

        private InstagramLocationResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramLocationResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramLocationResponse(response) {
                Body = InstagramLocationResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramLocationResponseBody : InstagramResponseBody<InstagramLocation> {

        #region Constructors

        protected InstagramLocationResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramLocationResponseBody Parse(JsonObject obj) {
            return new InstagramLocationResponseBody(obj) {
                Data = obj.GetObject("data", InstagramLocation.Parse)
            };
        }

        #endregion

    }

}