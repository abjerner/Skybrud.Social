using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects.Pagination {

    public class InstagramLikedMediaPagination : SocialJsonObject {

        #region Properties

        public string NextUrl { get; set; }

        public string NextMaxLikeId { get; set; }

        #endregion

        #region Constructors

        private InstagramLikedMediaPagination(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramLikedMediaPagination Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramLikedMediaPagination(obj) {
                NextUrl = obj.GetString("next_url"),
                NextMaxLikeId = obj.GetString("next_max_like_id")
            };
        }

        #endregion

    }

}