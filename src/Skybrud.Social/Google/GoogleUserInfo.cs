using Skybrud.Social.Json;

namespace Skybrud.Social.Google {
    
    /// <summary>
    /// Class representing a Google account/user. Not all properties may be present since it both
    /// depends on the scope of the application as well as what information the user has specified
    /// and is sharing.
    /// </summary>
    public class GoogleUserInfo {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// The full name of the user.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the given name (first name) of the user.
        /// </summary>
        public string GivenName { get; private set; }

        /// <summary>
        /// Gets the family name (last name) of the user.
        /// </summary>
        public string FamilyName { get; private set; }

        /// <summary>
        /// A link to the user's Google+ profile (if the user is on Google+).
        /// </summary>
        public string Profile { get; private set; }

        /// <summary>
        /// Gets the URL for the user's profile picture if present.
        /// </summary>
        public string Picture { get; private set; }

        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets whether the email address of the user has been verified.
        /// </summary>
        public bool IsEmailVerified { get; private set; }

        /// <summary>
        /// Gets the gender of the user.
        /// </summary>
        public string Gender { get; private set; }

        /// <summary>
        /// Gets the birth date of the user.
        /// </summary>
        public string Birthdate { get; private set; }

        /// <summary>
        /// Gets the locale of the user.
        /// </summary>
        public string Locale { get; private set; }

        #endregion

        #region Constructors

        private GoogleUserInfo() {
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
        /// Loads a user from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static GoogleUserInfo LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a user from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static GoogleUserInfo ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets a user from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static GoogleUserInfo Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GoogleUserInfo {
                JsonObject = obj,
                Id = obj.GetString("sub"),
                Name = obj.GetString("name"),
                GivenName = obj.GetString("given_name"),
                FamilyName = obj.GetString("family_name"),
                Profile = obj.GetString("profile"),
                Picture = obj.GetString("picture"),
                Email = obj.GetString("email"),
                IsEmailVerified = obj.GetBoolean("email_verified"),
                Gender = obj.GetString("gender"),
                Birthdate = obj.GetString("birthdate"),
                Locale = obj.GetString("locale")
            };
        }

        #endregion

    }

}
