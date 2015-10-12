using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options.Relationships {

    /// <summary>
    /// Class representing the options for getting a list of other users a given user is following.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/#get_users_follows</cref>
    /// </see>
    public class InstagramFollowsOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of users to be returned.
        /// </summary>
        public int Count { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an instance with default options.
        /// </summary>
        public InstagramFollowsOptions() { }

        /// <summary>
        /// Initializes an instance with the specified <code>count</code>.
        /// </summary>
        /// <param name="count">The maximum amount of users to be returned.</param>
        public InstagramFollowsOptions(int count) {
            Count = count;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <code>SocialQueryString</code> representing the GET parameters.
        /// </summary>
        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (Count > 0) qs.Add("count", Count);
            return qs;
        }

        #endregion

    }

}