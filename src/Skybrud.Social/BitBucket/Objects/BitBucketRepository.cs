using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {

    public class BitBucketRepository : SocialJsonObject {

        #region Properties

        public string Name { get; private set; }

        public string Language { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime UpdatedOn { get; private set; }

        #endregion

        #region Constructors

        private BitBucketRepository(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static BitBucketRepository Parse(JsonObject obj) {
            if (obj == null) return null;
            return new BitBucketRepository(obj) {
                Name = obj.GetString("name"),
                Language = obj.GetString("language"),
                CreatedOn = obj.GetDateTime("created_on"),
                UpdatedOn = obj.GetDateTime("updated_on")
            };
        }

        #endregion

    }

}
