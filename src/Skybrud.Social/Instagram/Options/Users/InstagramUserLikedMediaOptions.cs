using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options.Users {
    
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed_liked</cref>
    /// </see>
    public class InstagramUserLikedMediaOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of media to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Only media before this ID is returned.
        /// </summary>
        public string MaxLikeId { get; set; }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (Count > 0) qs.Add("count", Count);
            if (MaxLikeId != null) qs.Add("max_like_id", MaxLikeId);
            return qs;
        }

        #endregion

    }

}