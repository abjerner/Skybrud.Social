using Skybrud.Social.Google.YouTube.Objects.Channels;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Responses {

    public class YouTubeChannelsResponse : YouTubeResponse<YouTubeChannelsCollection> {

        #region Constructors

        private YouTubeChannelsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static YouTubeChannelsResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new YouTubeChannelsResponse(response) {
                Body = YouTubeChannelsCollection.Parse(obj)
            };

        }

        #endregion

    }

}