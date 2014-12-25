using System.Collections.Generic;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookMessageTag : SocialJsonObject {

        #region Properties

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Offset { get; private set; }
        public int Length { get; private set; }

        #endregion

        #region Constructors

        private FacebookMessageTag(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookMessageTag Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookMessageTag(obj) {
                Id = obj.GetString("id"),
                Name = obj.GetString("name"),
                Type = obj.GetString("type"),
                Offset = obj.GetInt32("offset"),
                Length = obj.GetInt32("length")
            };
        }

        public static FacebookMessageTag[] ParseMultiple(JsonObject obj) {
            if (obj == null) return null;
            List<FacebookMessageTag> temp = new List<FacebookMessageTag>();
            foreach (string key in obj.Keys) {
                temp.AddRange(obj.GetArray(key, Parse));
            }
            return temp.ToArray();
        }

        #endregion

    }

}