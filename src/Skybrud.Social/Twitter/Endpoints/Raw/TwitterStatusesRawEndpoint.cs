using System.Collections.Specialized;
using System.Globalization;
using Skybrud.Social.Twitter.Attributes;
using Skybrud.Social.Twitter.Enums;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints.Raw {
    
    public class TwitterStatusesRawEndpoint {

        public TwitterOAuthClient Client { get; private set; }

        internal TwitterStatusesRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #region Get information about a single tweet

        /// <summary>
        /// Alias of GetStatusMessage(). Gets the raw API response for a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the status message.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/show/:id"/>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetTweet(long id) {
            return GetStatusMessage(id, null);
        }

        /// <summary>
        /// Alias of GetStatusMessage(). Gets the raw API response for a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the status message.</param>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/show/:id"/>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetTweet(long id, TwitterStatusMessageOptions options) {
            return GetStatusMessage(id, options);
        }

        /// <summary>
        /// Gets the raw API response for a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the status message.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/show/:id"/>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetStatusMessage(long id) {
            return GetStatusMessage(id, null);
        }

        /// <summary>
        /// Gets the raw API response for a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the status message.</param>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/show/:id"/>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetStatusMessage(long id, TwitterStatusMessageOptions options) {

            // Define the query string
            NameValueCollection qs = new NameValueCollection { { "id", id.ToString(CultureInfo.InvariantCulture) } };
            if (options != null) {
                if (options.TrimUser) qs.Add("trim_user", "true");
                if (options.IncludeMyRetweet) qs.Add("include_my_retweet", "true");
                if (options.IncludeEntities) qs.Add("include_entities", "true");
            }

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/statuses/show.json", qs);

        }

        #endregion

        #region Gets the timeline for a specific user

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 300/app", authentication: TwitterAuthentication.Required)]
        public string GetUserTimeline(long userId) {
            return GetUserTimeline(userId, null);
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 300/app", authentication: TwitterAuthentication.Required)]
        public string GetUserTimeline(long userId, TwitterTimelineOptions options) {

            // Define the query string
            NameValueCollection qs = new NameValueCollection { { "user_id", userId + "" } };

            // Add optional parameters
            if (options != null) {
                if (options.SinceId > 0) qs.Add("since_id", options.SinceId + "");
                if (options.Count > 0) qs.Add("count", options.Count + "");
                if (options.MaxId > 0) qs.Add("max_id", options.MaxId + "");
                if (options.TrimUser) qs.Add("trim_user", "true");
                if (options.ExcludeReplies) qs.Add("exclude_replies", "true");
                if (options.ContributorDetails) qs.Add("contributor_details", "true");
                if (!options.IncludeRetweets) qs.Add("include_rts", "false");
            }

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/statuses/user_timeline.json", qs);

        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 300/app", authentication: TwitterAuthentication.Required)]
        public string GetUserTimeline(string screenName) {
            return GetUserTimeline(screenName, null);
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 300/app", authentication: TwitterAuthentication.Required)]
        public string GetUserTimeline(string screenName, TwitterTimelineOptions options) {

            // Define the query string
            NameValueCollection qs = new NameValueCollection { { "screen_name", screenName } };

            // Add optional parameters
            if (options != null) {
                if (options.SinceId > 0) qs.Add("since_id", options.SinceId + "");
                if (options.Count > 0) qs.Add("count", options.Count + "");
                if (options.MaxId > 0) qs.Add("max_id", options.MaxId + "");
                if (options.TrimUser) qs.Add("trim_user", "true");
                if (options.ExcludeReplies) qs.Add("exclude_replies", "true");
                if (options.ContributorDetails) qs.Add("contributor_details", "true");
                if (!options.IncludeRetweets) qs.Add("include_rts", "false");
            }

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/statuses/user_timeline.json", qs);

        }

        #endregion

        #region GetHomeTimeline(...)

        /// <summary>
        /// Gets a collection of the most recent Tweets and retweets posted by the authenticating
        /// user and the users they follow.
        /// </summary>
        public string GetHomeTimeline() {
            return GetHomeTimeline(null);
        }

        /// <summary>
        /// Gets a collection of the most recent Tweets and retweets posted by the authenticating
        /// user and the users they follow. 
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public string GetHomeTimeline(TwitterTimelineOptions options) {

            // Initialize the query string
            NameValueCollection qs = new NameValueCollection();

            // Add optional parameters
            if (options != null) {
                if (options.SinceId > 0) qs.Add("since_id", options.SinceId + "");
                if (options.Count > 0) qs.Add("count", options.Count + "");
                if (options.MaxId > 0) qs.Add("max_id", options.MaxId + "");
                if (options.TrimUser) qs.Add("trim_user", "true");
                if (options.ExcludeReplies) qs.Add("exclude_replies", "true");
                if (options.ContributorDetails) qs.Add("contributor_details", "true");
            }

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/statuses/home_timeline.json", qs);

        }

        #endregion

        #region GetMentionsTimeline(...)

        /// <summary>
        /// Gets a collection of the most recent Tweets and retweets posted by the authenticating user and the users they follow. 
        /// </summary>
        public string GetMentionsTimeline() {
            return GetMentionsTimeline(null);
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing a users's @screen_name) for the authenticating user.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public string GetMentionsTimeline(TwitterTimelineOptions options) {

            // Initialize the query string
            NameValueCollection qs = new NameValueCollection();

            // Add optional parameters
            if (options != null) {
                if (options.SinceId > 0) qs.Add("since_id", options.SinceId + "");
                if (options.Count > 0) qs.Add("count", options.Count + "");
                if (options.MaxId > 0) qs.Add("max_id", options.MaxId + "");
                if (options.TrimUser) qs.Add("trim_user", "true");
                if (options.ExcludeReplies) qs.Add("exclude_replies", "true");
                if (options.ContributorDetails) qs.Add("contributor_details", "true");
            }

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/statuses/mentions_timeline.json", qs);

        }

        #endregion

        #region GetRetweetsOfMe(...)

        /// <summary>
        /// Returns the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        public string GetRetweetsOfMe() {
            return GetRetweetsOfMe(null);
        }

        /// <summary>
        /// Returns the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public string GetRetweetsOfMe(TwitterTimelineOptions options) {

            // Initialize the query string
            NameValueCollection qs = new NameValueCollection();

            // Add optional parameters
            if (options != null) {
                if (options.SinceId > 0) qs.Add("since_id", options.SinceId + "");
                if (options.Count > 0) qs.Add("count", options.Count + "");
                if (options.MaxId > 0) qs.Add("max_id", options.MaxId + "");
                if (options.TrimUser) qs.Add("trim_user", "true");
                if (options.ExcludeReplies) qs.Add("exclude_replies", "true");
                if (options.ContributorDetails) qs.Add("contributor_details", "true");
            }

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/statuses/retweets_of_me.json", qs);

        }

        #endregion

        #region PostStatusMessage(...)

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        public string PostStatusMessage(string status) {
            return PostStatusMessage(status, null);
        }

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        /// <param name="replyTo">The ID of the status message to reply to.</param>
        public string PostStatusMessage(string status, long? replyTo) {

            // Construct the POST data
            NameValueCollection postData = new NameValueCollection {{"status", status}};
            if (replyTo != null) postData.Add("in_reply_to_status_id", replyTo.ToString());

            // Make the call to the API
            return Client.DoHttpRequestAsString("POST", "https://api.twitter.com/1.1/statuses/update.json", null, postData);

        }

        #endregion

    }

}
