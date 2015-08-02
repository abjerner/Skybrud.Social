using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects.Profiles {

    /// <summary>
    /// Class representing the response body of a request to get a list of profiles.
    /// </summary>
    public class AnalyticsProfilesResponseBody : GoogleApiObject {

        #region Properties

        /// <summary>
        /// Gets the <code>kind</code> of the object.
        /// </summary>
        public string Kind { get; private set; }

        /// <summary>
        /// Gets the username of the authenticated user.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the total amount of results.
        /// </summary>
        public int TotalResults { get; private set; }

        /// <summary>
        /// Gets the start index of the current page.
        /// </summary>
        public int StartIndex { get; private set; }

        /// <summary>
        /// Gets the amount of results per page.
        /// </summary>
        public int ItemsPerPage { get; private set; }

        /// <summary>
        /// Gets a link for the previous page.
        /// </summary>
        public string PreviousLink { get; private set; }

        /// <summary>
        /// Gets a link for the next page.
        /// </summary>
        public string NextLink { get; private set; }

        /// <summary>
        /// Gets an array of web properties of the current page.
        /// </summary>
        public AnalyticsProfile[] Items { get; private set; }

        #endregion

        #region Constructors

        private AnalyticsProfilesResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>AnalyticsProfilesResponseBody</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static AnalyticsProfilesResponseBody Parse(JsonObject obj) {
            if (obj == null) return null;
            return new AnalyticsProfilesResponseBody(obj) {
                Kind = obj.GetString("kind"),
                Username = obj.GetString("username"),
                TotalResults = obj.GetInt32("totalResults"),
                StartIndex = obj.GetInt32("startIndex"),
                ItemsPerPage = obj.GetInt32("itemsPerPage"),
                PreviousLink = obj.GetString("previousLink"),
                NextLink = obj.GetString("nextLink"),
                Items = obj.GetArray("items", AnalyticsProfile.Parse)
            };
        }

        #endregion

    }

}