using Skybrud.Social.BitBucket.Objects.Repositories;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses.Repositories {
    
    public class BitBucketCommitsResponse : BitBucketResponse<BitBucketCommitsCollection> {

        #region Constructors

        private BitBucketCommitsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static BitBucketCommitsResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new BitBucketCommitsResponse(response) {
                Body = JsonObject.ParseJson(response.Body, BitBucketCommitsCollection.Parse)
            };

        }

        #endregion

    }

}