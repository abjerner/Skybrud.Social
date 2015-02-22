using Skybrud.Social.Google.YouTube.Objects.Channels;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Responses {

    public class YouTubeChannelListResponse : YouTubeResponse<YouTubeChannelList> {

        #region Constructors

        private YouTubeChannelListResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static YouTubeChannelListResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new YouTubeChannelListResponse(response) {
                Body = YouTubeChannelList.Parse(obj)
            };

        }

        #endregion

    }

}