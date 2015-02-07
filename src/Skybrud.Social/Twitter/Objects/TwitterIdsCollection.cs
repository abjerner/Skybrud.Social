using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects {

    public class TwitterIdsCollection : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the array with the IDs returned in the response.
        /// </summary>
        public long[] Ids { get; private set; }

        /// <summary>
        /// Gets the cursor pointing to the next page in the result set.
        /// </summary>
        public long NextCursor { get; private set; }

        /// <summary>
        /// Gets the cursor pointing to the previous page in the result set.
        /// </summary>
        public long PreviousCursor { get; private set; }

        #endregion

        #region Constructors

        private TwitterIdsCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets a place from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static TwitterIdsCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterIdsCollection(obj) {
                Ids = obj.GetArray("ids").For((array, index) => array.GetInt64(index)),
                NextCursor = obj.GetInt64("next_cursor"),
                PreviousCursor = obj.GetInt64("previous_cursor")
            };
        }

        #endregion
    
    }

}