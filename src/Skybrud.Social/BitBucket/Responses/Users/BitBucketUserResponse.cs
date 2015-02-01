using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses.Users {

    public class BitBucketUserResponse : BitBucketResponse<BitBucketUserResponseBody> {

        #region Constructor

        private BitBucketUserResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static BitBucketUserResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);
            
            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Initialize the response object
            return new BitBucketUserResponse(response) {
                Body = BitBucketUserResponseBody.Parse(obj)
            };

        }

        #endregion

    }

}