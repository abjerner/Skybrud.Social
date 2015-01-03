using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Likes {

    public class FacebookLikes : SocialJsonObject {

        // TODO: Check whether this class is still used...

        #region Properties

        public int Count { get; private set; }
        public FacebookObject[] Data { get; private set; }

        #endregion

        #region Constructors

        private FacebookLikes(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookLikes Parse(JsonObject obj) {
            // TODO: Should we just return NULL if "obj" is NULL?
            if (obj == null) return new FacebookLikes(null) { Data = new FacebookObject[0] };
            return new FacebookLikes(obj) {
                Count = obj.GetInt32("count"),
                Data = obj.GetArray("data", FacebookObject.Parse) ?? new FacebookObject[0]
            };
        }

        #endregion

    }

}