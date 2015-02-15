using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects.Pagination {

    public class InstagramIdBasedPagination : SocialJsonObject {

        #region Properties

        public string NextUrl { get; set; }

        public string NextMaxId { get; set; }

        #endregion

        #region Constructors

        private InstagramIdBasedPagination(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramIdBasedPagination Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramIdBasedPagination(obj) {
                NextUrl = obj.GetString("next_url"),
                NextMaxId = obj.GetString("next_max_id")
            };
        }

        #endregion

    }

}