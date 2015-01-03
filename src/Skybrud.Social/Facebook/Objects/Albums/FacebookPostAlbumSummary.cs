using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Albums {
    
    public class FacebookPostAlbumSummary : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the album.
        /// </summary>
        public string Id { get; private set; }

        #endregion

        #region Constructors

        private FacebookPostAlbumSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookPostAlbumSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPostAlbumSummary(obj) {
                Id = obj.GetString("id")
            };
        }

        #endregion

    }

}