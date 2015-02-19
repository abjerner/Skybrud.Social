using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects {

    public class YouTubePageInfo : GoogleApiObject {

        #region Properties

        public int TotalResults { get; private set; }

        public int ResultsPerPage { get; private set; }

        #endregion

        #region Constructors

        protected YouTubePageInfo(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubePageInfo</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubePageInfo Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubePageInfo(obj) {
                TotalResults = obj.GetInt32("totalResults"),
                ResultsPerPage = obj.GetInt32("resultsPerPage")
            };
        }

        #endregion

    }

}