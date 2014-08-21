using System;
using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {

    public class FacebookMeResponse {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Link { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Gender { get; private set; }
        public int? TimeZone { get; private set; }
        public string Locale { get; private set; }
        public bool? IsVerified { get; private set; }
        public DateTime UpdatedTime { get; private set; }

        #endregion

        #region Constructors

        internal FacebookMeResponse() {
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
        /// Loads an instance of <code>FacebookMeResponse</code> from the JSON
        /// file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static FacebookMeResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <code>FacebookMeResponse</code> from the
        /// specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static FacebookMeResponse ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <code>FacebookMeResponse</code> from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static FacebookMeResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookException.Parse);
            return new FacebookMeResponse {
                JsonObject = obj,
                Id = obj.GetLong("id"),
                Name = obj.GetString("name"),
                FirstName = obj.GetString("first_name"),
                LastName = obj.GetString("last_name"),
                Link = obj.GetString("link"),
                UserName = obj.GetString("username"),
                Email = obj.GetString("email"),
                Gender = obj.GetString("gender"),
                TimeZone = obj.HasValue("timezone") ? (int?)obj.GetInt("timezone") : null,
                Locale = obj.GetString("locale"),
                IsVerified = obj.HasValue("verified") ? (bool?)obj.GetBoolean("verified") : null,
                UpdatedTime = obj.GetDateTime("updated_time")
            };
        }

        #endregion

    }

}
