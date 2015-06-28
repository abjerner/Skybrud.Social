using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Twitter.Options.Favorites {
    
    /// <summary>
    /// Options for a call to the Twitter API for getting a list of favorites.
    /// </summary>
    public class TwitterGetFavoritesOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user for whom to return results for.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the screen name of the user for whom to return results for.
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Gets or sets the number of records to retrieve. Must be less than or equal to <code>200</code>; defaults to
        /// <code>20</code>. The value of count is best thought of as a limit to the number of tweets to return because
        /// suspended or deleted content is removed after the count has been applied.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Returns results with an ID greater than (that is, more recent than) the specified ID. There are limits to
        /// the number of Tweets which can be accessed through the API. If the limit of Tweets has occured since the
        /// <code>since_id</code>, the <code>since_id</code> will be forced to the oldest ID available.
        /// </summary>
        public long SinceId { get; set; }

        /// <summary>
        /// Returns results with an ID less than (that is, older than) or equal to the specified ID.
        /// </summary>
        public long MaxId { get; set; }

        /// <summary>
        /// The <code>entities</code> node will be omitted when set to <code>false</code>.
        /// </summary>
        public bool IncludeEntities { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TwitterGetFavoritesOptions() {
            IncludeEntities = true;
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (UserId > 0) qs.Set("user_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) qs.Set("screen_name", ScreenName);
            if (Count > 0) qs.Set("count", Count);
            if (SinceId > 0) qs.Set("since_id", SinceId);
            if (MaxId > 0) qs.Set("max_id", MaxId);
            if (!IncludeEntities) qs.Set("include_entities", "0");
            return qs;
        }

        #endregion

    }

}