using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramAccessTokenResponse : InstagramResponse<InstagramAccessTokenSummary> {

        #region Constructors

        private InstagramAccessTokenResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramAccessTokenResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramAccessTokenResponse(response) {
                Body = InstagramAccessTokenSummary.Parse(obj)
            };

        }

        #endregion

    }

}