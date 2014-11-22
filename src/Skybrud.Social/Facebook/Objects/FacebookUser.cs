using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookUser : SocialJsonObject {

        #region Properties

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Link { get; private set; }
        public string Username { get; private set; }
        public FacebookObject Hometown { get; private set; }
        public FacebookObject Location { get; private set; }
        public string Gender { get; private set; }
        public string Email { get; private set; }
        public int? Timezone { get; private set; }
        public string Locale { get; private set; }
        public FacebookObject[] Languages { get; private set; }
        public bool IsVerified { get; private set; }

        #endregion

        #region Constructors

        private FacebookUser(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a user from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static FacebookUser LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a user from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static FacebookUser ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets a user from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static FacebookUser Parse(JsonObject obj) {
            if (obj == null) return null;
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookApiException.Parse);
            return new FacebookUser(obj) {
                Id = obj.GetString("id"),
                Name = obj.GetString("name"),
                FirstName = obj.GetString("first_name"),
                LastName = obj.GetString("last_name"),
                Link = obj.GetString("link"),
                Username = obj.GetString("username"),
                Hometown = obj.GetObject("hometown", FacebookObject.Parse),
                Location = obj.GetObject("location", FacebookObject.Parse),
                Gender = obj.GetString("gender"),
                Email = obj.GetString("email"),
                Timezone = obj.GetInt32("timezone"),
                Locale = obj.GetString("locale"),
                Languages = obj.GetArray("languages", FacebookObject.Parse) ?? new FacebookObject[0],
                IsVerified = obj.GetBoolean("verified")
            };
        }

        #endregion

    }

}
