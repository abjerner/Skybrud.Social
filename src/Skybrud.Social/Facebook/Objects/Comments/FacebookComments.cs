using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Comments {

    /// <summary>
    /// Class representing a collection of comments of a Facebook object.
    /// </summary>
    public class FacebookComments : SocialJsonObject {

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

        /// <summary>
        /// Gets a summary of the comments of the parent object, or <code>null</code> if not present.
        /// </summary>
        public FacebookCommentsSummary Summary { get; private set; }

        /// <summary>
        /// Gets whether a summary is present.
        /// </summary>
        public bool HasSummary {
            get { return Summary != null; }
        }
        
        #region Constructors

        private FacebookComments(JsonObject obj) : base(obj) { }

        #endregion

        /// <summary>
        /// Gets an instance of <code>FacebookComments</code> from the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        /// <returns>Returns an instance of <code>FacebookComments</code>.</returns>
        public static FacebookComments Parse(JsonObject obj) {
            if (obj == null) return new FacebookComments(null) { Data = new FacebookCommentSummary[0] };
            return new FacebookComments(obj) {
                Count = obj.GetInt32("count"),
                Data = obj.GetArray("data", FacebookCommentSummary.Parse) ?? new FacebookCommentSummary[0],
                Summary = obj.GetObject("summary", FacebookCommentsSummary.Parse)
            };
        }

    }

}