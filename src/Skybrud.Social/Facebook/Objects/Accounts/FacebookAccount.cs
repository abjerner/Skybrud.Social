using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Accounts {

    public class FacebookAccount : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the account.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// Gets the name of the account.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the category of the account.
        /// </summary>
        public string Category { get; internal set; }

        /// <summary>
        /// Gets a list of sub categories of the account.
        /// </summary>
        public FacebookObject[] CategoryList { get; private set; }

        /// <summary>
        /// The access token associated with the current user and the account.
        /// The access token may be <var>NULL</var> depending on the permissions.
        /// </summary>
        public string AccessToken { get; internal set; }

        /// <summary>
        /// Gets the permissions given to manage the account. Permissions may not be
        /// specified for all types of accounts.
        /// </summary>
        public string[] Permissions { get; internal set; }

        #endregion

        #region Constructors

        private FacebookAccount(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parse the JSON object of an account.
        /// </summary>
        /// <param name="obj">The JSON object.</param>
        /// <returns></returns>
        public static FacebookAccount Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookAccount(obj) {
                Id = obj.GetString("id"),
                Name = obj.GetString("name"),
                Category = obj.GetString("category"),
                CategoryList = obj.GetArray("category_list", FacebookObject.Parse),
                AccessToken = obj.GetString("access_token"),
                Permissions = obj.GetArray<string>("perms") ?? new string[0]
            };
        }

        #endregion

    }

}