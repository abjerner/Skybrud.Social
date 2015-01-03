using Skybrud.Social.Facebook.Objects.Accounts;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Accounts {

    public class FacebookAccountsResponse : FacebookResponse<FacebookAccountsCollection> {

        #region Constructors

        private FacebookAccountsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookAccountsResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookAccountsResponse(response) {
                Body = FacebookAccountsCollection.Parse(obj)
            };

        }

        #endregion

    }

}