using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options;
using Skybrud.Social.Twitter.Responses;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterStatusesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public TwitterStatusesRawEndpoint Raw {
            get { return Service.Client.Statuses; }
        }

        #endregion

        #region Constructors

        internal TwitterStatusesEndpoint(TwitterService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        public TwitterStatusMessageResponse GetStatusMessage(long statusId) {
            return TwitterStatusMessageResponse.ParseResponse(Raw.GetStatusMessage(new TwitterStatusMessageOptions(statusId)));
        }

        /// <summary>
        /// Gets information about a status message (tweet) with the specified ID.
        /// </summary>
        /// <param name="options">Options affecting the response from the Twitter API.</param>
        public TwitterStatusMessageResponse GetStatusMessage(TwitterStatusMessageOptions options) {
            return TwitterStatusMessageResponse.ParseResponse(Raw.GetStatusMessage(options));
        }

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        public TwitterStatusMessageResponse PostStatusMessage(string status) {
            return TwitterStatusMessageResponse.ParseResponse(Raw.PostStatusMessage(status));
        }

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="status">The status message to send.</param>
        /// <param name="replyTo">The ID of the status message to reply to.</param>
        public TwitterStatusMessageResponse PostStatusMessage(string status, long? replyTo) {
            return TwitterStatusMessageResponse.ParseResponse(Raw.PostStatusMessage(status, replyTo));
        }

        /// <summary>
        /// Posts the specified status message.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public TwitterStatusMessageResponse PostStatusMessage(TwitterPostStatusMessageOptions options) {
            return TwitterStatusMessageResponse.ParseResponse(Raw.PostStatusMessage(options));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        public TwitterTimelineResponse GetUserTimeline(long userId, int count) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetUserTimeline(userId, count));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterTimelineResponse GetUserTimeline(long userId) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetUserTimeline(userId));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterTimelineResponse GetUserTimeline(string screenName) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetUserTimeline(screenName));
        }

        /// <summary>
        /// Gets the timeline of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="count">The maximum amount of tweets to return.</param>
        public TwitterTimelineResponse GetUserTimeline(string screenName, int count) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetUserTimeline(screenName, count));
        }

        /// <summary>
        /// Gets the timeline of a user with the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public TwitterTimelineResponse GetUserTimeline(TwitterUserTimelineOptions options) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetUserTimeline(options));
        }

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating
        /// user and the users they follow.
        /// </summary>
        public TwitterTimelineResponse GetHomeTimeline() {
            return TwitterTimelineResponse.ParseResponse(Raw.GetHomeTimeline());
        }

        /// <summary>
        /// Gets a collection of the most recent tweets and retweets posted by the authenticating
        /// user and the users they follow.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to return.</param>
        public TwitterTimelineResponse GetHomeTimeline(int count) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetHomeTimeline(count));
        }

        /// <summary>
        /// Gets a collection of the most recent Tweets and retweets posted by the authenticating
        /// user and the users they follow. 
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public TwitterTimelineResponse GetHomeTimeline(TwitterTimelineOptions options) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetHomeTimeline(options));
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticating user.
        /// </summary>
        public TwitterTimelineResponse GetMentionsTimeline() {
            return TwitterTimelineResponse.ParseResponse(Raw.GetMentionsTimeline());
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticating user.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to return.</param>
        public TwitterTimelineResponse GetMentionsTimeline(int count) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetMentionsTimeline(count));
        }

        /// <summary>
        /// Gets the most recent mentions (tweets containing the users's @screen_name) for the authenticating user.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public TwitterTimelineResponse GetMentionsTimeline(TwitterTimelineOptions options) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetMentionsTimeline(options));
        }

        /// <summary>
        /// Returns the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        public TwitterTimelineResponse GetRetweetsOfMe() {
            return TwitterTimelineResponse.ParseResponse(Raw.GetRetweetsOfMe());
        }

        /// <summary>
        /// Returns the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="count">The maximum amount of tweets to return.</param>
        public TwitterTimelineResponse GetRetweetsOfMe(int count) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetRetweetsOfMe(count));
        }

        /// <summary>
        /// Returns the most recent tweets authored by the authenticating user that have been retweeted by others.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public TwitterTimelineResponse GetRetweetsOfMe(TwitterTimelineOptions options) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetRetweetsOfMe(options));
        }

        #endregion

    }

}