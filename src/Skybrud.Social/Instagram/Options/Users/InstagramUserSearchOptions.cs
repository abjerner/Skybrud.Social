using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options.Users {

    /// <summary>
    /// Class representing the options for for getting a list of users matching a given query.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_search</cref>
    /// </see>
    public class InstagramUserSearchOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the search query.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of users to be returned.
        /// </summary>
        public int Count { get; set; }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <code>SocialQueryString</code> representing the GET parameters.
        /// </summary>
        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            qs.Add("q", Query);
            if (Count > 0) qs.Add("count", Count);
            return qs;
        }

        #endregion

    }

}