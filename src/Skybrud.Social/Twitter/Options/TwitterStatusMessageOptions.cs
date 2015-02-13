using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Twitter.Options {

    public class TwitterStatusMessageOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the status message to be found.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// When set to <code>true</code>, each tweet returned in a timeline will include a user object
        /// including only the status authors numerical ID. Omit this parameter to receive
        /// the complete user object.
        /// </summary>
        public bool TrimUser = false;

        /// <summary>
        /// When set to <code>true</code>, any Tweets returned that have been retweeted by the
        /// authenticating user will include an additional <code>current_user_retweet</code>
        /// node, containing the ID of the source status for the retweet.
        /// </summary>
        public bool IncludeMyRetweet = false;

        /// <summary>
        /// The entities node will be disincluded when set to <code>false</code>.
        /// </summary>
        public bool IncludeEntities = false;

        #endregion

        #region Constructors

        public TwitterStatusMessageOptions() { }

        public TwitterStatusMessageOptions(long statusId) {
            Id = statusId;
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString query = new SocialQueryString();
            query.Set("id", Id);
            if (TrimUser) query.Add("trim_user", "true");
            if (IncludeMyRetweet) query.Add("include_my_retweet", "true");
            if (IncludeEntities) query.Add("include_entities", "true");
            return query;
        }

        #endregion

    }

}