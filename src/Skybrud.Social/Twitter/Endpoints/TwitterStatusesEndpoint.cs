using System;
using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Objects;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterStatusesEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public TwitterStatusesRawEndpoint Raw {
            get { return Service.Client.Statuses; }
        }

        #endregion

        #region Constructor(s)

        internal TwitterStatusesEndpoint(TwitterService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        #region GetStatusMessage(...)

        /// <summary>
        /// Alias of GetStatusMessage(). Gets information about a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        public TwitterStatusMessage GetTweet(long statusId) {
            return GetStatusMessage(statusId, null);
        }

        /// <summary>
        /// Alias of GetStatusMessage(). Gets information about a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <param name="options">Options affecting the response from the Twitter API.</param>
        public TwitterStatusMessage GetTweet(long statusId, TwitterStatusMessageOptions options = null) {
            return GetStatusMessage(statusId, options);
        }

        /// <summary>
        /// Gets information about a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        public TwitterStatusMessage GetStatusMessage(long statusId) {
            return GetStatusMessage(statusId, null);
        }

        /// <summary>
        /// Gets information about a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <param name="options">Options affecting the response from the Twitter API.</param>
        public TwitterStatusMessage GetStatusMessage(long statusId, TwitterStatusMessageOptions options) {
            return TwitterStatusMessage.ParseJson(Raw.GetStatusMessage(statusId, options).Body);
        }

        #endregion

        #region GetUserTimeline(...)

        public TwitterTimeline GetUserTimeline(long userId, int count) {
            return TwitterTimeline.ParseJson(Raw.GetUserTimeline(userId, new TwitterTimelineOptions(count)).Body);
        }

        public TwitterTimeline GetUserTimeline(long userId, TwitterTimelineOptions options = null) {
            return TwitterTimeline.ParseJson(Raw.GetUserTimeline(userId, options).Body);
        }

        public TwitterTimeline GetUserTimeline(string screenName, int count) {
            return TwitterTimeline.ParseJson(Raw.GetUserTimeline(screenName, new TwitterTimelineOptions(count)).Body);
        }

        public TwitterTimeline GetUserTimeline(string screenName, TwitterTimelineOptions options = null) {
            return TwitterTimeline.ParseJson(Raw.GetUserTimeline(screenName, options).Body);
        }

        [Obsolete("Use method GetUserTimeline(...) instead for consistent naming")]
        public TwitterTimeline UserTimeline(long userId, int count) {
            return TwitterTimeline.ParseJson(Raw.GetUserTimeline(userId, new TwitterTimelineOptions(count)).Body);
        }

        [Obsolete("Use method GetUserTimeline(...) instead for consistent naming")]
        public TwitterTimeline UserTimeline(long userId, TwitterTimelineOptions options = null) {
            return TwitterTimeline.ParseJson(Raw.GetUserTimeline(userId, options).Body);
        }

        [Obsolete("Use method GetUserTimeline(...) instead for consistent naming")]
        public TwitterTimeline UserTimeline(string screenName, int count) {
            return TwitterTimeline.ParseJson(Raw.GetUserTimeline(screenName, new TwitterTimelineOptions(count)).Body);
        }

        [Obsolete("Use method GetUserTimeline(...) instead for consistent naming")]
        public TwitterTimeline UserTimeline(string screenName, TwitterTimelineOptions options = null) {
            return TwitterTimeline.ParseJson(Raw.GetUserTimeline(screenName, options).Body);
        }

        #endregion

        #region GetHomeTimeline(...)

        /// <summary>
        /// Gets a collection of the most recent Tweets and retweets posted by the authenticating
        /// user and the users they follow.
        /// </summary>
        public TwitterTimeline GetHomeTimeline() {
            return GetHomeTimeline(null);
        }

        /// <summary>
        /// Gets a collection of the most recent Tweets and retweets posted by the authenticating
        /// user and the users they follow. 
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public TwitterTimeline GetHomeTimeline(TwitterTimelineOptions options) {
            return TwitterTimeline.ParseJson(Raw.GetHomeTimeline(options).Body);
        }

        #endregion

        #region GetMentionsTimeline(...)

        /// <summary>
        /// Gets a collection of the most recent Tweets and retweets posted by the authenticating user and the users they follow. 
        /// </summary>
        public TwitterTimeline GetMentionsTimeline() {
            return GetMentionsTimeline(null);
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing a users's @screen_name) for the authenticating user.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public TwitterTimeline GetMentionsTimeline(TwitterTimelineOptions options) {
            return TwitterTimeline.ParseJson(Raw.GetMentionsTimeline(options).Body);
        }

        #endregion

        #region GetRetweetsOfMe(...)

        /// <summary>
        /// Returns the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        public TwitterTimeline GetRetweetsOfMe() {
            return GetRetweetsOfMe(null);
        }

        /// <summary>
        /// Returns the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public TwitterTimeline GetRetweetsOfMe(TwitterTimelineOptions options) {
            return TwitterTimeline.ParseJson(Raw.GetRetweetsOfMe(options).Body);
        }

        #endregion

        #region PostStatusMessage(...)

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        public TwitterStatusMessage PostStatusMessage(string status) {
            return PostStatusMessage(status, null);
        }

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        /// <param name="replyTo">The ID of the status message to reply to.</param>
        public TwitterStatusMessage PostStatusMessage(string status, long? replyTo) {
            return TwitterStatusMessage.ParseJson(Raw.PostStatusMessage(status, replyTo));
        }

        #endregion

        #endregion

    }

}