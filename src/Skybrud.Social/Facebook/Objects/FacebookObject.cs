using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookObject : SocialJsonObject {

        #region Properties

        /// <summary>
        /// The ID of the object.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// The name of the object.
        /// </summary>
        public string Name { get; internal set; }

        #endregion

        #region Constructors

        private FacebookObject(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookObject Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookObject(obj) {
                Id = obj.GetString("id"),
                Name = obj.GetString("name")
            };
        }

        #endregion

    }

}