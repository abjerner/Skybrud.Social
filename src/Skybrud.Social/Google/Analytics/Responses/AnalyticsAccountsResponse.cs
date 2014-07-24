using Skybrud.Social.Google.Analytics.Objects;
using Skybrud.Social.Google.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Responses {

    public class AnalyticsAccountsResponse {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }
        
        public string Username { get; private set; }
        public int TotalResults { get; private set; }
        public int StartIndex { get; private set; }
        public int ItemsPerPage { get; private set; }
        public AnalyticsAccount[] Items { get; private set; }
        public AnalyticsAccount[] Accounts {
            get { return Items; }
        }

        #endregion

        #region Constructors

        private AnalyticsAccountsResponse() {
            // Hide default constructor
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a JSON string representing the object.
        /// </summary>
        public string ToJson() {
            return JsonObject == null ? null : JsonObject.ToJson();
        }

        /// <summary>
        /// Saves the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            if (JsonObject != null) JsonObject.SaveJson(path);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>AnalyticsAccountsResponse</var> from the JSON file at the
        /// specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        public static AnalyticsAccountsResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>AnalyticsAccountsResponse</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static AnalyticsAccountsResponse ParseJson(string json) {
            return Parse(JsonConverter.ParseObject(json));
        }

        /// <summary>
        /// Gets an instance of <var>AnalyticsAccountsResponse</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static AnalyticsAccountsResponse Parse(JsonObject obj) {

            // Check whether "obj" is NULL
            if (obj == null) return null;

            // Check for any API errors
            if (obj.HasValue("error")) {
                JsonObject error = obj.GetObject("error");
                throw new GoogleApiException(error.GetInt("code"), error.GetString("message"));
            }

            // Initialize the response object
            return new AnalyticsAccountsResponse {
                JsonObject = obj,
                Username = obj.GetString("username"),
                TotalResults = obj.GetInt("totalResults"),
                StartIndex = obj.GetInt("startIndex"),
                ItemsPerPage = obj.GetInt("itemsPerPage"),
                Items = obj.GetArray("items", AnalyticsAccount.Parse)
            };

        }

        #endregion

    }

}