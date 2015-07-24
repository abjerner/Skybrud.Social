using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {

    /// <summary>
    /// Class representing a Google Analytics account. This is not the same as a Google Account,
    /// since a Google Account can have multiple Analytics accounts.
    /// </summary>
    public class AnalyticsAccount {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }
        
        /// <summary>
        /// Gets the ID of the account.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of the account.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the creation date of the account.
        /// </summary>
        public DateTime Created { get; private set; }

        /// <summary>
        /// Gets the update date of the account.
        /// </summary>
        public DateTime Updated { get; private set; }

        #endregion

        #region Constructors

        private AnalyticsAccount() {
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
        /// Loads an account from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static AnalyticsAccount LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an account from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static AnalyticsAccount ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an account from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static AnalyticsAccount Parse(JsonObject obj) {
            return new AnalyticsAccount {
                JsonObject = obj,
                Id = obj.GetString("id"),
                Name = obj.GetString("name"),
                Created = obj.GetDateTime("created"),
                Updated = obj.GetDateTime("updated")
            };
        }

        #endregion

    }

}