using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses.User {

    public class BitBucketCurrentUserRepositoriesResponse : BitBucketResponse<BitBucketUserRepository[]> {

        #region Constructors

        private BitBucketCurrentUserRepositoriesResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static BitBucketCurrentUserRepositoriesResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Initialize the response object
            return new BitBucketCurrentUserRepositoriesResponse(response) {
                //Body = BitBucketUserRepository.Parse(obj)
            };

        }

        #endregion

    }

}