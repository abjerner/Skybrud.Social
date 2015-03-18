using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Pagination;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramLikedMediaResponse : InstagramResponse<InstagramLikedMediaResponseBody> {

        #region Constructors

        private InstagramLikedMediaResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramLikedMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramLikedMediaResponse(response) {
                Body = InstagramLikedMediaResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramLikedMediaResponseBody : InstagramResponseBody<InstagramMedia[]> {

        #region Properties

        public InstagramLikedMediaPagination Pagination { get; private set; }

        #endregion

        #region Constructors

        protected InstagramLikedMediaResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramLikedMediaResponseBody Parse(JsonObject obj) {
            return new InstagramLikedMediaResponseBody(obj) {
                Pagination = obj.GetObject("pagination", InstagramLikedMediaPagination.Parse),
                Data = obj.GetArray("data", InstagramMedia.Parse)
            };
        }

        #endregion

    }

}