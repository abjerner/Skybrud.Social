using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {
    
    public class BitBucketAuthor : SocialJsonObject {

        public string Raw { get; private set; }

        public BitBucketAuthorUser User { get; private set; }
        
        #region Constructors

        private BitBucketAuthor(JsonObject obj) : base(obj) {
            // Hide default constructor
        }

        #endregion

        public static BitBucketAuthor Parse(JsonObject obj) {

            // Check if NULL
            if (obj == null) return null;

            // Initialize the author object
            return new BitBucketAuthor(obj) {
                Raw = obj.GetString("raw"),
                User = obj.GetObject("user", BitBucketAuthorUser.Parse)
            };

        }

    }

}
