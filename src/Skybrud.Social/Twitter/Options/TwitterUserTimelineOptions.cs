using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Twitter.Options {

    public class TwitterUserTimelineOptions : IGetOptions {

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
        /// Returns results with an ID greater than (that is, more recent than) the specified ID. There are limits to
        /// the number of Tweets which can be accessed  through the API. If the limit of Tweets has occured since the
        /// <code>since_id</code>, the <code>since_id</code> will be forced to the oldest ID available.
        /// </summary>
        public long SinceId { get; set; }

        /// <summary>
        /// Specifies the number of tweets to try and retrieve, up to a maximum of 200 per distinct request. The value
        /// of count is best thought of as a limit to the number of tweets to return because suspended or deleted
        /// content is removed after the count has been applied.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Returns results with an ID less than (that is, older than) or equal to the specified ID.
        /// </summary>
        public long MaxId { get; set; }

        /// <summary>
        /// When set to true, each tweet returned in a timeline will include a user object including only the status
        /// authors numerical ID. Omit this parameter to receive the complete user object.
        /// </summary>
        public bool TrimUser { get; set; }

        /// <summary>
        /// This parameter will prevent replies from appearing in the returned timeline. Using
        /// <code>exclude_replies</code> with the <code>count</code> parameter will mean you will receive up-to count
        /// tweets — this is because the <code>count</code> parameter retrieves that many tweets before filtering out
        /// retweets and replies.
        /// </summary>
        public bool ExcludeReplies { get; set; }

        /// <summary>
        /// This parameter enhances the contributors element of the status response to include the screen_name of the
        /// contributor. By default only the user_id of the contributor is included.
        /// </summary>
        public bool ContributorDetails { get; set; }

        /// <summary>
        /// When set to <code>false</code>, the timeline will strip any native retweets  (though they will still count
        /// toward both the maximal length of the timeline and the slice selected by the count parameter).
        /// 
        /// Note: If you're using the <code>trim_user</code> parameter in conjunction with <code>include_rts</code>,
        /// the retweets will still contain a full user object.
        /// </summary>
        public bool IncludeRetweets { get; set; }

        #endregion

        #region Constructors

        public TwitterUserTimelineOptions() {
            IncludeRetweets = true;
        }

        public TwitterUserTimelineOptions(long userId) {
            UserId = userId;
            IncludeRetweets = true;
        }

        public TwitterUserTimelineOptions(long userId, int count) {
            UserId = userId;
            Count = count;
            IncludeRetweets = true;
        }

        public TwitterUserTimelineOptions(string screenName) {
            ScreenName = screenName;
            IncludeRetweets = true;
        }

        public TwitterUserTimelineOptions(string screenName, int count) {
            ScreenName = screenName;
            Count = count;
            IncludeRetweets = true;
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {

            // Define the query string
            SocialQueryString qs = new SocialQueryString();

            // Add optional parameters
            if (UserId > 0) qs.Set("user_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) qs.Set("screen_name", ScreenName);
            if (SinceId > 0) qs.Set("since_id", SinceId);
            if (Count > 0) qs.Set("count", Count);
            if (MaxId > 0) qs.Set("max_id", MaxId);
            if (TrimUser) qs.Set("trim_user", "true");
            if (ExcludeReplies) qs.Set("exclude_replies", "true");
            if (ContributorDetails) qs.Set("contributor_details", "true");
            if (!IncludeRetweets) qs.Set("include_rts", "false");

            return qs;

        }

        #endregion

    }

}