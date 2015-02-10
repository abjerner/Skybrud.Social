using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects {

    public class TwitterUserCollection : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the array with the users returned in the response.
        /// </summary>
        public TwitterUser[] Users { get; private set; }

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

        private TwitterUserCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>TwitterUserCollection</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static TwitterUserCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterUserCollection(obj) {
                Users = obj.GetArray("users", TwitterUser.Parse),
                NextCursor = obj.GetInt64("next_cursor"),
                PreviousCursor = obj.GetInt64("previous_cursor")
            };
        }

        #endregion
    
    }

}