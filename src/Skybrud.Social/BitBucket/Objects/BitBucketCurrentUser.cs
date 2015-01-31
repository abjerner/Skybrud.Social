using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {

    public class BitBucketCurrentUser : SocialJsonObject {

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

        private BitBucketCurrentUser(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static BitBucketCurrentUser Parse(JsonObject obj) {
            if (obj == null) return null;
            return new BitBucketCurrentUser(obj) {
                User = obj.GetObject("user", BitBucketUser.Parse),
                Repositories = obj.GetArray("repositories", BitBucketUserRepository.Parse)
            };
        }

        #endregion

    }

}