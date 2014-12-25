using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Albums {
    
    public class FacebookAlbumPlace : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the place.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the title of the place.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the location of the place.
        /// </summary>
        public FacebookLocation Location { get; private set; }

        #endregion

        #region Constructors

        private FacebookAlbumPlace(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets a place from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static FacebookAlbumPlace Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookAlbumPlace(obj) {
                Id = obj.GetString("id"),
                Location = obj.GetObject("location", FacebookLocation.Parse),
                Name = obj.GetString("name")
            };
        }

        #endregion

    }

}
