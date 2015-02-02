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

            // Initialize the response object
            return new BitBucketCurrentUserRepositoriesResponse(response) {
                Body = JsonArray.ParseJson(response.Body).ParseMultiple(BitBucketUserRepository.Parse)
            };

        }

        #endregion

    }

}