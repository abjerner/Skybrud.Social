using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses {

    public class BitBucketRepositoriesResponse : SocialJsonArray {

        #region Properties

        public BitBucketUserRepository[] Repositories { get; private set; }

        #endregion

        #region Constructor

        private BitBucketRepositoriesResponse(JsonArray array) : base(array) { }

        #endregion

        #region Static methods

        public static BitBucketRepositoriesResponse ParseJsonArray(string str) {
            return Parse(JsonConverter.ParseArray(str));
        }

        public static BitBucketRepositoriesResponse Parse(JsonArray array) {
            if (array == null) return null;
            return new BitBucketRepositoriesResponse(array) {
                Repositories = array.ParseMultiple(BitBucketUserRepository.Parse)
            };
        }

        #endregion

    }

}
