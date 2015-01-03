using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Likes {

    public class FacebookLike : SocialJsonObject {

        #region Properties

        /// <summary>
        /// The ID of the person.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// The name of the person.
        /// </summary>
        public string Name { get; internal set; }

        #endregion

        #region Constructors

        private FacebookLike(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookLike Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookLike(obj) {
                Id = obj.GetString("id"),
                Name = obj.GetString("name")
            };
        }

        #endregion

    }

}