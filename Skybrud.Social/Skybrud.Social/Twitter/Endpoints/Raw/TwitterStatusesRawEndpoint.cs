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
        /// Gets the raw API response for a tweet with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the tweet.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/show/:id"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetTweet(long id) {
            return GetTweet(id, null);
        }

        /// <summary>
        /// Gets the raw API response for a tweet with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the tweet.</param>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/show/:id"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetTweet(long id, TwitterStatusMessageOptions options) {

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
        public string GetUserTimeline(long userId, TwitterUserTimelineOptions options) {

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
        public string GetUserTimeline(string screenName, TwitterUserTimelineOptions options) {

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
    
    }

}
