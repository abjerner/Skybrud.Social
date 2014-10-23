using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses {

    public class BitBucketUserResponse : SocialJsonObject {

        #region Properties

        public BitBucketUser User { get; private set; }
        public BitBucketUserRepository[] Repositories { get; private set; }

        #endregion

        #region Constructor

        private BitBucketUserResponse(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static BitBucketUserResponse ParseJson(string str) {
            return JsonConverter.ParseObject(str, Parse);
        }

        public static BitBucketUserResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            return new BitBucketUserResponse(obj) {
                User = obj.GetObject("user", BitBucketUser.Parse),
                Repositories = obj.GetArray("repositories", BitBucketUserRepository.Parse)
            };
        }

        #endregion

    }

}
