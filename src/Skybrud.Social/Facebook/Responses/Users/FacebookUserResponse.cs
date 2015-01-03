using Skybrud.Social.Facebook.Objects.Users;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Users {

    public class FacebookUserResponse : FacebookResponse<FacebookUser> {

        #region Constructors

        private FacebookUserResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookUserResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookUserResponse(response) {
                Body = FacebookUser.Parse(obj)
            };

        }

        #endregion

    }

}