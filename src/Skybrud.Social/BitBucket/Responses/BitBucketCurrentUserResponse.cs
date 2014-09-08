using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses {

    public class BitBucketCurrentUserResponse : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets information about the current user.
        /// </summary>
        public BitBucketUser User { get; private set; }
        
        /// <summary>
        /// Gets an array of repositories owned by the current user.
        /// </summary>
        public BitBucketUserRepository[] Repositories { get; private set; }

        #endregion

        #region Constructor

        private BitBucketCurrentUserResponse(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static BitBucketCurrentUserResponse ParseJson(string str) {
            return Parse(JsonConverter.ParseObject(str));
        }

        public static BitBucketCurrentUserResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            return new BitBucketCurrentUserResponse(obj) {
                User = obj.GetObject("user", BitBucketUser.Parse),
                Repositories = obj.GetArray("repositories", BitBucketUserRepository.Parse)
            };
        }

        #endregion

    }

}