using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects.Geocode;

namespace Skybrud.Social.Twitter.Responses {

    public class TwitterReverseGeocodeResponse : TwitterResponse<TwitterReverseGeocodeResults> {

        #region Constructors

        private TwitterReverseGeocodeResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static TwitterReverseGeocodeResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new TwitterReverseGeocodeResponse(response) {
                Body = JsonObject.ParseJson(response.Body, TwitterReverseGeocodeResults.Parse)
            };

        }

        #endregion

    }

}