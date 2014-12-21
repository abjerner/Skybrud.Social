using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookLink : SocialJsonObject {

        #region Properties

        public string Id { get; private set; }
        public string Message { get; private set; }
        public string Name { get; private set; }
        public string Link { get; private set; }
        public string Caption { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedTime { get; private set; }

        #endregion

        #region Constructors

        private FacebookLink(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookLink Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookLink(obj) {
                Id = obj.GetString("id"),
                Message = obj.GetString("message"),
                Name = obj.GetString("name"),
                Link = obj.GetString("link"),
                Caption = obj.GetString("caption"),
                Description = obj.GetString("description"),
                CreatedTime = DateTime.Parse(obj.GetString("created_time"))
            };
        }

        #endregion

    }

}
