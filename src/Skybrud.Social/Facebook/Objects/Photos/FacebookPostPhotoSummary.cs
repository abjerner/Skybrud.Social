using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Photos {
    
    public class FacebookPostPhotoSummary : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the photo.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the ID of the post about the photo.
        /// </summary>
        public string PostId { get; private set; }

        #endregion

        #region Constructors

        private FacebookPostPhotoSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookPostPhotoSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPostPhotoSummary(obj) {
                Id = obj.GetString("id"),
                PostId = obj.GetString("post_id")
            };

        }

        #endregion

    }

}