using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses {

    public class BitBucketCurrentUserResponse : BitBucketResponse<BitBucketCurrentUser> {

        #region Constructors

        private BitBucketCurrentUserResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static BitBucketCurrentUserResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);
            
            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Initialize the response object
            return new BitBucketCurrentUserResponse(response) {
                Body = BitBucketCurrentUser.Parse(obj)
            };

        }

        #endregion

    }

}