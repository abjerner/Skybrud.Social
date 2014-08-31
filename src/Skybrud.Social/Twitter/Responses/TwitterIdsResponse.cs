using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Responses {
    
    public class TwitterIdsResponse {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        /// <summary>
        /// Gets an array of the IDs on the current page.
        /// </summary>
        public long[] Ids { get; protected set; }

        /// <summary>
        /// Gets the cursor for the next page.
        /// </summary>
        public long NextCursor { get; protected set; }

        /// <summary>
        /// Gets the cursor for the previous page.
        /// </summary>
        public long PreviousCursor { get; protected set; }

        #endregion

        #region Constructor

        protected TwitterIdsResponse() {
            // Hide default constructor
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a response from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static TwitterIdsResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a response from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static TwitterIdsResponse ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets a response from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static TwitterIdsResponse Parse(JsonObject obj) {
            if (obj == null) return null;



            JsonArray array = obj.GetArray("ids");



            long[] ids = new long[array.Length];

            for (int i = 0; i < ids.Length; i++) {
                ids[i] = array.GetLong(i);
            }






                return new TwitterIdsResponse {
                    JsonObject = obj,
                    Ids = ids,
                    NextCursor = obj.GetLong("next_cursor"),
                    PreviousCursor = obj.GetLong("previous_cursor")
                };
        }

        #endregion

    }

}
