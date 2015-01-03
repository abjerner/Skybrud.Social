using Skybrud.Social.Facebook.Objects.Events;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Events {

    public class FacebookEventResponse : FacebookResponse<FacebookEvent> {

        #region Constructors

        private FacebookEventResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookEventResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookEventResponse(response) {
                Body = FacebookEvent.Parse(obj)
            };

        }

        #endregion

    }

}