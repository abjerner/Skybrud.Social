using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects.Pagination {

    /// <summary>
    /// Class representing pagination information for an ID based pagination.
    /// </summary>
    public class InstagramIdBasedPagination : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the URL of the next page.
        /// </summary>
        public string NextUrl { get; set; }

        /// <summary>
        /// Gets the ID of the first item og the next page.
        /// </summary>
        public string NextMaxId { get; set; }

        #endregion

        #region Constructors

        private InstagramIdBasedPagination(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramIdBasedPagination</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramIdBasedPagination</code>.</returns>
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