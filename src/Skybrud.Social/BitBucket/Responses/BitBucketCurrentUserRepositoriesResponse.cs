using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses {

    public class BitBucketCurrentUserRepositoriesResponse : SocialJsonArray {

        #region Properties

        public BitBucketUserRepository[] Repositories { get; private set; }

        #endregion

        #region Constructor

        private BitBucketCurrentUserRepositoriesResponse(JsonArray array) : base(array) { }

        #endregion

        #region Static methods

        public static BitBucketCurrentUserRepositoriesResponse ParseJsonArray(string str) {
            return Parse(JsonConverter.ParseArray(str));
        }

        public static BitBucketCurrentUserRepositoriesResponse Parse(JsonArray array) {
            if (array == null) return null;
            return new BitBucketCurrentUserRepositoriesResponse(array) {
                Repositories = array.ParseMultiple(BitBucketUserRepository.Parse)
            };
        }

        #endregion

    }

}
