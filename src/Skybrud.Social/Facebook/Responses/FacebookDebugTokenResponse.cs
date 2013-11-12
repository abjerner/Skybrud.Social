using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {

    public class FacebookDebugTokenResponse {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        /// <summary>
        /// The ID of the application.
        /// </summary>
        public long AppId { get; private set; }

        /// <summary>
        /// Whether the the access token is valid.
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// The name of the application.
        /// </summary>
        public string Application { get; private set; }

        /// <summary>
        /// The ID of the user. Is only present for user access tokens.
        /// </summary>
        public long? UserId { get; private set; }

        /// <summary>
        /// The timestamp for when the token was issued.
        /// </summary>
        public DateTime? IssuedAt { get; private set; }

        /// <summary>
        /// The timestamp for when the token will expire.
        /// </summary>
        public DateTime? ExpiresAt { get; private set; }

        /// <summary>
        /// For user access tokens, the user will grant the app one or multiple
        /// scopes. This property will be an array of all granted scopes. For
        /// any other types of access tokens, this array will be empty.
        /// </summary>
        public string[] Scopes { get; private set; }

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
        /// Loads an instance of <var>FacebookDebugTokenResponse</var> from the
        /// JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static FacebookDebugTokenResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>FacebookDebugTokenResponse</var> from the
        /// specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static FacebookDebugTokenResponse ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        ///  /// Gets an instance of <var>FacebookDebugTokenResponse</var> from
        /// the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static FacebookDebugTokenResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            JsonObject data = obj.GetObject("data");
            return new FacebookDebugTokenResponse {
                JsonObject = obj,
                AppId = data.GetLong("app_id"),
                IsValid = data.GetBoolean("is_valid"),
                Application = data.GetString("application"),
                UserId = data.HasValue("user_id") ? (long?) data.GetLong("user_id") : null,
                IssuedAt = data.HasValue("issued_at") ? (DateTime?) data.GetDateTimeFromUnixTimestamp("issued_at") : null,
                ExpiresAt = data.HasValue("expires_at") ? (DateTime?) data.GetDateTimeFromUnixTimestamp("expires_at") : null,
                Scopes = data.GetArray<string>("scopes") ?? new string[0]
            };
        }

        #endregion

    }

}
