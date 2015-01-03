using Skybrud.Social.Facebook.Objects.Events;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Events {

    public class FacebookEventsResponse : FacebookResponse<FacebookEventsCollection> {

        #region Constructors

        private FacebookEventsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookEventsResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookEventsResponse(response) {
                Body = FacebookEventsCollection.Parse(obj)
            };

        }

        #endregion

    }

}