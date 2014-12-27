using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Events {

    public class FacebookEventOwner : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the user or page.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of the user or page.
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Constructors

        private FacebookEventOwner(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookEventOwner Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookEventOwner(obj) {
                Id = obj.GetString("id"),
                Name = obj.GetString("name")
            };

        }

        #endregion

    }

}