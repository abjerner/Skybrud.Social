using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {

    public class FacebookAppResponse {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public string SubCategory { get; private set; }
        public string Link { get; private set; }
        public string Namespace { get; private set; }
        public string IconUrl { get; private set; }
        public string LogoUrl { get; private set; }
        public int? DailyActiveUsers { get; private set; }
        public int? WeeklyActiveUsers { get; private set; }
        public int? MonthlyActiveUsers { get; private set; }
        public int? DailyActiveUserRank { get; private set; }
        public int? MontlyActiveUserRank { get; private set; }

        #endregion

        #region Constructors

        private FacebookAppResponse() {
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
        /// Loads an instance of <var>FacebookAppResponse</var> from the
        /// JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static FacebookAppResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>FacebookAppResponse</var> from the
        /// specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static FacebookAppResponse ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>FacebookAppResponse</var> from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static FacebookAppResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookException.Parse);
            return new FacebookAppResponse {
                JsonObject = obj,
                Id = obj.GetLong("id"),
                Name = obj.GetString("name"),
                Description = obj.GetString("description"),
                Category = obj.GetString("category"),
                SubCategory = obj.GetString("subcategory"),
                Link = obj.GetString("link"),
                Namespace = obj.GetString("namespace"),
                IconUrl = obj.GetString("icon_url"),
                LogoUrl = obj.GetString("logo_url"),
                DailyActiveUsers = obj.HasValue("weekly_active_users") ? (int?) obj.GetInt("weekly_active_users") : null,
                WeeklyActiveUsers = obj.HasValue("weekly_active_users") ? (int?) obj.GetInt("weekly_active_users") : null,
                MonthlyActiveUsers = obj.HasValue("monthly_active_users") ? (int?) obj.GetInt("monthly_active_users") : null,
                DailyActiveUserRank = obj.HasValue("daily_active_users_rank") ? (int?) obj.GetInt("daily_active_users_rank") : null,
                MontlyActiveUserRank = obj.HasValue("monthly_active_users_rank") ? (int?) obj.GetInt("monthly_active_users_rank") : null,
            };
        }

        #endregion

    }

}
