using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookObject {

        #region Properties

        /// <summary>
        /// The ID of the object.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// The name of the object.
        /// </summary>
        public string Name { get; internal set; }

        #endregion

        #region Constructors

        private FacebookObject() {
            // Hide default constructor
        }

        #endregion

        #region Static methods

        public static FacebookObject Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookObject {
                Id = obj.GetLong("id"),
                Name = obj.GetString("name")
            };
        }

        public static FacebookObject[] ParseMultiple(JsonArray array) {
            return array == null ? new FacebookObject[0] : array.ParseMultiple(Parse);
        }

        #endregion

    }

}
