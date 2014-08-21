using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses {
    
    public class BitBucketCommitsResponse {

        #region Properties

        /// <summary>
        /// The amount of commits per page.
        /// </summary>
        public int PageLength { get; private set; }

        /// <summary>
        /// The current page.
        /// </summary>
        public int Page { get; private set; }

        /// <summary>
        /// Whether there is a more pages.
        /// </summary>
        public bool HasNext { get; private set; }

        /// <summary>
        /// A link for the next page (might not be specified).
        /// </summary>
        public string Next { get; private set; }

        /// <summary>
        /// Array of commits on the specified page.
        /// </summary>
        public BitBucketCommit[] Values { get; private set; }

        #endregion

        #region Constructor(s)

        private BitBucketCommitsResponse() {
            // make default constructor private
        }

        #endregion

        #region Static methods

        public static BitBucketCommitsResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        public static BitBucketCommitsResponse Parse(JsonObject obj) {
            return new BitBucketCommitsResponse {
                PageLength = obj.GetInt("pagelen"),
                Page = obj.GetInt("page"),
                Values = obj.GetArray("values", BitBucketCommit.Parse),
                Next = obj.GetString("next"),
                HasNext = obj.GetString("next") != null
            };
        }

        #endregion

    }

}
