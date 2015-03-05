using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Pagination;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramLocationRecentMediaResponse : InstagramResponse<InstagramLocationRecentMediaResponseBody> {

        #region Constructors

        private InstagramLocationRecentMediaResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramLocationRecentMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

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

        #region Properties

        public InstagramIdBasedPagination Pagination { get; private set; }

        #endregion

        #region Constructors

        protected InstagramLocationRecentMediaResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramLocationRecentMediaResponseBody Parse(JsonObject obj) {
            return new InstagramLocationRecentMediaResponseBody(obj) {
                Pagination = obj.GetObject("pagination", InstagramIdBasedPagination.Parse),
                Data = obj.GetArray("data", InstagramMedia.Parse)
            };
        }

        #endregion

    }

}