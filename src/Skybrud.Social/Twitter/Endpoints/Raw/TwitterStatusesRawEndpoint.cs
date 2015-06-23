using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints.Raw {
    
    public class TwitterStatusesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwitterOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal TwitterStatusesRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the raw API response for a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/statuses/show/:id</cref>
        /// </see>
        public SocialHttpResponse GetStatusMessage(long statusId) {
            return GetStatusMessage(new TwitterStatusMessageOptions(statusId));
        }

        /// <summary>
        /// Gets the raw API response for a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/statuses/show/:id</cref>
        /// </see>
        public SocialHttpResponse GetStatusMessage(TwitterStatusMessageOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/statuses/show.json", options);
        }

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        public SocialHttpResponse PostStatusMessage(string status) {
            return PostStatusMessage(new TwitterPostStatusMessageOptions { Status = status });
        }

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        /// <param name="replyTo">The ID of the status message to reply to.</param>
        public SocialHttpResponse PostStatusMessage(string status, long? replyTo) {
            return PostStatusMessage(new TwitterPostStatusMessageOptions { Status = status, ReplyTo = replyTo });
        }

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse PostStatusMessage(TwitterPostStatusMessageOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoHttpPostRequest("https://api.twitter.com/1.1/statuses/update.json", options);
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline</cref>
        /// </see>
        public SocialHttpResponse GetUserTimeline(long userId) {
            return GetUserTimeline(new TwitterUserTimelineOptions(userId));
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline</cref>
        /// </see>
        public SocialHttpResponse GetUserTimeline(long userId, int count) {
            return GetUserTimeline(new TwitterUserTimelineOptions(userId, count));
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline</cref>
        /// </see>
        public SocialHttpResponse GetUserTimeline(string screenName) {
            return GetUserTimeline(new TwitterUserTimelineOptions(screenName));
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline</cref>
        /// </see>
        public SocialHttpResponse GetUserTimeline(string screenName, int count) {
            return GetUserTimeline(new TwitterUserTimelineOptions(screenName, count));
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline</cref>
        /// </see>
        public SocialHttpResponse GetUserTimeline(TwitterUserTimelineOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/statuses/user_timeline.json", options);
        }

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating
        /// user and the users they follow.
        /// </summary>
        public SocialHttpResponse GetHomeTimeline() {
            return GetHomeTimeline(new TwitterTimelineOptions());
        }

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating
        /// user and the users they follow.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to return.</param>
        public SocialHttpResponse GetHomeTimeline(int count) {
            return GetHomeTimeline(new TwitterTimelineOptions(count));
        }

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating
        /// user and the users they follow. 
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public SocialHttpResponse GetHomeTimeline(TwitterTimelineOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/statuses/home_timeline.json", options);
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticating user.
        /// </summary>
        public SocialHttpResponse GetMentionsTimeline() {
            return GetMentionsTimeline(new TwitterTimelineOptions());
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticating user.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to return.</param>
        public SocialHttpResponse GetMentionsTimeline(int count) {
            return GetMentionsTimeline(new TwitterTimelineOptions(count));
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticating user.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public SocialHttpResponse GetMentionsTimeline(TwitterTimelineOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/statuses/mentions_timeline.json", options);
        }

        /// <summary>
        /// Returns the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        public SocialHttpResponse GetRetweetsOfMe() {
            return GetRetweetsOfMe(new TwitterTimelineOptions());
        }

        /// <summary>
        /// Returns the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to return.</param>
        public SocialHttpResponse GetRetweetsOfMe(int count) {
            return GetRetweetsOfMe(new TwitterTimelineOptions(count));
        }

        /// <summary>
        /// Returns the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public SocialHttpResponse GetRetweetsOfMe(TwitterTimelineOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/statuses/retweets_of_me.json", options);
        }

        /// <summary>
        /// Retweets the tweet with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the tweet to be retweeted.</param>
        /// <returns>Returns the response from the API.</returns>
        public SocialHttpResponse Retweet(long id) {
            return Retweet(id, false);
        }

        /// <summary>
        /// Retweets the tweet with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the tweet to be retweeted.</param>
        /// <param name="trimUser">When set to <code>true</code>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>Returns the response from the API.</returns>
        public SocialHttpResponse Retweet(long id, bool trimUser) {
            return Client.DoHttpPostRequest("https://api.twitter.com/1.1/statuses/retweet/" + id + ".json" + (trimUser ? "?trim_user=true" : ""), null);
        }

        /// <summary>
        /// Destroys the status with the specified <code>id</code>. The authenticating user must be the author of the
        /// specified status. Returns the destroyed status if successful.
        /// </summary>
        /// <param name="id">The ID of the tweet to be destroyed.</param>
        /// <returns>Returns the response from the API.</returns>
        public SocialHttpResponse DestroyStatusMessage(long id) {
            return DestroyStatusMessage(id, false);
        }
        
        /// <summary>
        /// Destroys the status with the specified <code>id</code>. The authenticating user must be the author of the
        /// specified status. Returns the destroyed status if successful.
        /// </summary>
        /// <param name="id">The ID of the tweet to be destroyed.</param>
        /// <param name="trimUser">When set to <code>true</code>, each tweet returned in a timeline will include a user
        /// object including only the status authors numerical ID. Omit this parameter to receive the complete user
        /// object.</param>
        /// <returns>Returns the response from the API.</returns>
        public SocialHttpResponse DestroyStatusMessage(long id, bool trimUser) {
            return Client.DoHttpPostRequest("https://api.twitter.com/1.1/statuses/destroy/" + id + ".json" + (trimUser ? "?trim_user=true" : ""), null);
        }

        #endregion

    }

}