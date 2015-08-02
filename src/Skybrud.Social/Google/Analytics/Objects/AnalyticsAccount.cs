using System;
using Skybrud.Social.Google.Analytics.Objects.Accounts;
using Skybrud.Social.Google.Analytics.Objects.Common;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {

    /// <summary>
    /// Class representing a Google Analytics account. This is not the same as a Google Account,
    /// since a Google Account can have multiple Analytics accounts.
    /// </summary>
    public class AnalyticsAccount : GoogleApiObject {

        // TODO: Move class to the "Skybrud.Social.Google.Analytics.Objects.Accounts" namespace for v1.0

        #region Properties
        
        /// <summary>
        /// Gets the ID of the account.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of the account.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets a reference to an object describing the permissions to the account.
        /// </summary>
        public AnalyticsPermissions Permissions { get; private set; }

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

        private AnalyticsAccount(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an account from the JSON file at the specified <code>path</code>.
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
        /// Gets an account from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static AnalyticsAccount Parse(JsonObject obj) {
            return new AnalyticsAccount(obj) {
                Id = obj.GetString("id"),
                Name = obj.GetString("name"),
                Permissions = obj.GetObject("permissions", AnalyticsPermissions.Parse),
                Created = obj.GetDateTime("created"),
                Updated = obj.GetDateTime("updated")
            };
        }

        #endregion

    }

}