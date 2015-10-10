using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects.Pagination {

    /// <summary>
    /// Class representing pagination information.
    /// </summary>
    public class InstagramLikedMediaPagination : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the URL of the next page.
        /// </summary>
        public string NextUrl { get; set; }

        /// <summary>
        /// Gets the ID of the first item og the next page.
        /// </summary>
        public string NextMaxLikeId { get; set; }

        #endregion

        #region Constructors

        private InstagramLikedMediaPagination(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramLikedMediaPagination</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramLikedMediaPagination</code>.</returns>
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