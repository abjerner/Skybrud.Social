using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options {

    /// <see cref="http://instagram.com/developer/endpoints/users/#get_users_search"/>
    public class InstagramUserSearchOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the search query.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of users to return.
        /// </summary>
        public int Count { get; set; }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            qs.Add("q", Query);
            if (Count > 0) qs.Add("count", Count);
            return qs;
        }

        #endregion

    }

}