using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses.User {

    public class BitBucketCurrentUserResponse : BitBucketResponse<BitBucketCurrentUserResponseBody> {

        #region Constructors

        private BitBucketCurrentUserResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static BitBucketCurrentUserResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new BitBucketCurrentUserResponse(response) {
                Body = JsonObject.ParseJson(response.Body, BitBucketCurrentUserResponseBody.Parse)
            };

        }

        #endregion

    }

}