using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses {

    public class BitBucketCurrentUserResponse {

        #region Properties

        /// <summary>
        /// Gets information about the current user.
        /// </summary>
        public BitBucketUser User { get; private set; }

        #endregion

        #region Constructor

        internal BitBucketCurrentUserResponse() {
            // Hide default constructor
        }

        #endregion

        #region Static methods

        public static BitBucketCurrentUserResponse ParseJson(string str) {
            return Parse(JsonConverter.ParseObject(str));
        }

        public static BitBucketCurrentUserResponse Parse(JsonObject obj) {
            return new BitBucketCurrentUserResponse {
                User = obj.GetObject("user", BitBucketUser.Parse)
            };
        }

        #endregion

    }

}