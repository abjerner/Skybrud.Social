using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookComments {

        /// <summary>
        /// Gets the total amounbt of comments. This value might not always be
        /// present in the API response - in such cases the count will be zero.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// An array of comments. For a post, photo or similar with many
        /// comments, this array will only be a subset of all comments.
        /// </summary>
        public FacebookCommentSummary[] Data { get; private set; }

        public static FacebookComments Parse(JsonObject obj) {
            if (obj == null) return new FacebookComments { Data = new FacebookCommentSummary[0] };
            return new FacebookComments {
                Count = obj.GetInt("count"),
                Data = obj.GetArray("data", FacebookCommentSummary.Parse) ?? new FacebookCommentSummary[0]
            };
        }

    }

}
