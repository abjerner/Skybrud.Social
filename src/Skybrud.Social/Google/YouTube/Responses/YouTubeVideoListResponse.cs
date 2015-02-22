using Skybrud.Social.Google.YouTube.Objects.Videos;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Responses {

    public class YouTubeVideoListResponse : YouTubeResponse<YouTubeVideoList> {

        #region Constructors

        private YouTubeVideoListResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static YouTubeVideoListResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new YouTubeVideoListResponse(response) {
                Body = YouTubeVideoList.Parse(obj)
            };

        }

        #endregion

    }

}