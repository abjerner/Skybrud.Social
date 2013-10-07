using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using Skybrud.Social.Google.Analytics;
using Skybrud.Social.OAuth;
using Skybrud.Social.Twitter.Attributes;
using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Enums;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.OAuth {
    
    /// <summary>
    /// Class for handling the communication with the Twitter API. The class ha
    /// methods for handling OAuth logins using a three-legged approach as well
    /// as logic for calling the methods decribed in the Twitter API (not all
    /// has been implemented yet).
    /// </summary>
    public class TwitterOAuthClient : OAuthClient {

        private TwitterUsersRawEndpoint _users;

        #region Properties

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        public TwitterUsersRawEndpoint Users {
            get { return _users ?? (_users = new TwitterUsersRawEndpoint(this)); }
        }

        #endregion

        #region Constructors

        public TwitterOAuthClient() : this(null, null, null, null, null) {
            // Call overloaded constructor
        }

        public TwitterOAuthClient(string consumerKey, string consumerSecret) : this(consumerKey, consumerSecret, null, null, null) {
            // Call overloaded constructor
        }

        public TwitterOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret) : this(consumerKey, consumerSecret, token, tokenSecret, null) {
            // Call overloaded constructor
        }

        public TwitterOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret, string callback) {
        
            // Common properties
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Token = token;
            TokenSecret = tokenSecret;
            Callback = callback;

            // Specific to Twitter
            RequestTokenUrl = "https://api.twitter.com/oauth/request_token";
            AuthorizeUrl = "https://api.twitter.com/oauth/authorize";
            AccessTokenUrl = "https://api.twitter.com/oauth/access_token";
        
        }

        #endregion

        #region Account

        public string VerifyCredentials() {
            HttpStatusCode status;
            return VerifyCredentials(out status);
        }

        public string VerifyCredentials(out HttpStatusCode status) {
            return DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/account/verify_credentials.json", null, null, out status);
        }

        #endregion

        #region Statuses

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
            return DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/statuses/show.json", qs, null);

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
            return DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/statuses/user_timeline.json", qs, null);

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
            return DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/statuses/user_timeline.json", qs, null);

        }

        #endregion

        #endregion

        #region Geo

        #region Get information about a place

        /// <summary>
        /// Gets the raw API response for a place with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the place.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/geo/id/:place_id"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "15/user", authentication: TwitterAuthentication.UserContext)]
        public string GetPlace(string id) {
            return DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/geo/id/" + id + ".json", null, null);
        }

        #endregion

        #region Get places from a reverse lookup

        /// <summary>
        /// Given a latitude and a longitude, searches for up to 20 places that can be used as
        /// a <var>place_id</var> when updating a status. This request is an informative call
        /// and will deliver generalized results about geography.
        /// </summary>
        /// <param name="latitude">The latitude to search around. This parameter will be ignored
        /// unless it is inside the range -90.0 to +90.0 (North is positive) inclusive. It will
        /// also be ignored if there isn't a corresponding <var>long</var> parameter.</param>
        /// <param name="longitude">The longitude to search around. The valid ranges for longitude
        /// is -180.0 to +180.0 (East is positive) inclusive. This parameter will be ignored if
        /// outside that range, if it is not a number, if <var>geo_enabled</var> is disabled, or
        /// if there not a corresponding <var>lat</var> parameter.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/geo/reverse_geocode"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "15/user", authentication: TwitterAuthentication.UserContext)]
        public string ReverseGeocode(double latitude, double longitude) {
            return ReverseGeocode(latitude, longitude, null);
        }

        /// <summary>
        /// Given a latitude and a longitude, searches for up to 20 places that can be used as
        /// a <var>place_id</var> when updating a status. This request is an informative call
        /// and will deliver generalized results about geography.
        /// </summary>
        /// <param name="latitude">The latitude to search around. This parameter will be ignored
        /// unless it is inside the range -90.0 to +90.0 (North is positive) inclusive. It will
        /// also be ignored if there isn't a corresponding <var>long</var> parameter.</param>
        /// <param name="longitude">The longitude to search around. The valid ranges for longitude
        /// is -180.0 to +180.0 (East is positive) inclusive. This parameter will be ignored if
        /// outside that range, if it is not a number, if <var>geo_enabled</var> is disabled, or
        /// if there not a corresponding <var>lat</var> parameter.</param>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/geo/reverse_geocode"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "15/user", authentication: TwitterAuthentication.UserContext)]
        public string ReverseGeocode(double latitude, double longitude, TwitterReverseGeocodeOptions options) {

            // Define the query string
            NameValueCollection qs = new NameValueCollection {
                {"lat", latitude.ToString(CultureInfo.InvariantCulture)},
                {"long", longitude.ToString(CultureInfo.InvariantCulture)}
            };

            // Add optional parameters
            if (options != null) {
                if (options.Accurary != null && options.Accurary != "0m") qs.Add("accuracy", options.Accurary);
                if (options.Granularity != default(TwitterGranularity)) qs.Add("granularity", options.Granularity.ToString().ToLower());
                if (options.MaxResults > 0) qs.Add("max_results", options.MaxResults + "");
            }

            // Make the call to the API
            return DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/geo/reverse_geocode.json", qs, null);

        }

        #endregion

        #endregion

    }

}
