using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramLocationRecentMediaResponse : InstagramResponse<InstagramLocationRecentMediaResponseBody> {

        #region Constructors

        private InstagramLocationRecentMediaResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramLocationRecentMediaResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramLocationRecentMediaResponse(response) {
                Body = InstagramLocationRecentMediaResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramLocationRecentMediaResponseBody : InstagramResponseBody<InstagramMedia[]> {

        public InstagramLocationRecentMediaPagination Pagination { get; private set; }

        public static InstagramLocationRecentMediaResponseBody Parse(JsonObject obj) {
            return new InstagramLocationRecentMediaResponseBody {
                Pagination = obj.GetObject("pagination", InstagramLocationRecentMediaPagination.Parse),
                Data = obj.GetArray("data", InstagramMedia.Parse)
            };
        }

    }

    public class InstagramLocationRecentMediaPagination : SocialJsonObject {

        #region Properties

        public string NextUrl { get; private set; }

        public string NextMaxId { get; private set; }

        #endregion

        #region Constructors

        private InstagramLocationRecentMediaPagination(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramLocationRecentMediaPagination Parse(JsonObject obj) {
            return new InstagramLocationRecentMediaPagination(obj) {
                NextUrl = obj.GetString("next_url"),
                NextMaxId = obj.GetString("next_max_id")
            };
        }

        #endregion

    }

}