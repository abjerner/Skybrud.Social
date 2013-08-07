using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using Skybrud.Social.Twitter.Attributes;
using Skybrud.Social.Twitter.Enums;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter {
    
    /// <summary>
    /// Class representing the Twitter API. Use this class for retrieving the raw data.
    /// </summary>
    /// <see cref="https://dev.twitter.com/docs/api/1.1"/>
    [Obsolete("Use the Client property in the TwitterService class instead.")]
    public class TwitterRestApi {

        #region Properties

        protected TwitterService Service { get; set; }

        /// <summary>
        /// Specifies whether API calls should be made HTTPS or HTTP. HTTPS will be
        /// used by default.
        /// </summary>
        public bool UseHttps { get; set; }

        public string Protocol {
            get { return UseHttps ? "https://" : "http://"; }
        }

        #endregion

        #region Constructor(s)

        internal TwitterRestApi(TwitterService service) {
            Service = service;
            UseHttps = true;
        }

        #endregion

        #region Users

        #region Get information about a single user

        /// <summary>
        /// Gets the raw API response for a user with the specified ID. Any entities will not be included in the API response.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/users/show"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetUserAsRawJson(long id) {
            return Service.Client.GetUser(id);
        }

        /// <summary>
        /// Gets the raw API response for a user with the specified ID. 
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/users/show"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetUserAsRawJson(long id, bool includeEntities) {
            return Service.Client.GetUser(id, includeEntities);
        }

        /// <summary>
        /// Gets the raw API response for a user with the specified screen name. Any entities will not be included in the API response.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/users/show"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetUserAsRawJson(string screenName) {
            return Service.Client.GetUser(screenName);
        }

        /// <summary>
        /// Gets the raw API response for a user with the specified screen name.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/users/show"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetUserAsRawJson(string screenName, bool includeEntities) {
            return Service.Client.GetUser(screenName, includeEntities);
        }

        #endregion

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
        public string GetTweetAsRawJson(long id) {
            return Service.Client.GetTweet(id);
        }

        /// <summary>
        /// Gets the raw API response for a tweet with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the tweet.</param>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/show/:id"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetTweetAsRawJson(long id, TwitterStatusMessageOptions options) {
            return Service.Client.GetTweet(id, options);
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
        public string GetUserTimelineAsRawJson(long userId) {
            return Service.Client.GetUserTimeline(userId);
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 300/app", authentication: TwitterAuthentication.Required)]
        public string GetUserTimelineAsRawJson(long userId, TwitterUserTimelineOptions options) {
            return Service.Client.GetUserTimeline(userId, options);
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 300/app", authentication: TwitterAuthentication.Required)]
        public string GetUserTimelineAsRawJson(string screenName) {
            return Service.Client.GetUserTimeline(screenName);
        }

        /// <summary>
        /// Get the raw API response for a user's timeline.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "180/user, 300/app", authentication: TwitterAuthentication.Required)]
        public string GetUserTimelineAsRawJson(string screenName, TwitterUserTimelineOptions options) {
            return Service.Client.GetUserTimeline(screenName, options);
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
        public string GetPlaceAsRawJson(string id) {
            return Service.Client.GetPlace(id);
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
        public string GetReverseLookupAsRawJson(double latitude, double longitude) {
            return Service.Client.ReverseGeocode(latitude, longitude);
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
        public string GetReverseLookupAsRawJson(double latitude, double longitude, TwitterReverseGeocodeOptions options) {
            return Service.Client.ReverseGeocode(latitude, longitude);
        }

        #endregion

        #endregion

        #region Request logic

        public string ThisIsSparta(string method, string baseUrl) {
            return ThisIsSparta(method, baseUrl, null, null);
        }
        
        public string ThisIsSparta(string method, string baseUrl, NameValueCollection queryString) {
            return ThisIsSparta(method, baseUrl, queryString, null);
        }

        public string ThisIsSparta(string method, string baseUrl, NameValueCollection queryString, NameValueCollection body) {

            throw new NotImplementedException("IN YOUR FACE!!! BOOM!!!");

            // Initialize an empty NameValueCollection if queryString is empty
            if (queryString == null) queryString = new NameValueCollection();

            // Generate the URL
            string url = baseUrl + "?" + SocialUtils.NameValueCollectionToQueryString(queryString);

            // Initialize the OAuth object
            TwitterOAuthClient oauth = new TwitterOAuthClient {
                ConsumerKey = Service.Info.ConsumerKey,
                ConsumerSecret = Service.Info.ConsumerSecret,
                Nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks + "")),
                Timestamp = SocialUtils.GetCurrentUnixTimestamp() + "",
                Token = Service.Info.AccessToken,
                TokenSecret = Service.Info.AccessTokenSecret,
                Version = "1.0"
            };

            // Generate the signature
            string signature = oauth.GenerateSignature(method, url, queryString, body);

            // Generate the header from the OAuth values and the signature
            string header = oauth.GenerateHeaderString(signature);

            // Initialize the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", header);

            // Set the method
            request.Method = method;

            try {

                // Get the response
                HttpWebResponse rsp = (HttpWebResponse) request.GetResponse();

                // Read the content
                StreamReader reader = new StreamReader(rsp.GetResponseStream());
                return reader.ReadToEnd();

            } catch (WebException ex) {

                // Read the content
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                return reader.ReadToEnd();

            }

        }

        #endregion

        public static DateTime ParseDateTime(string date) {
            return DateTime.ParseExact(date, "ddd MMM dd HH:mm:ss K yyyy", new CultureInfo("en-US"));
        }

        public static DateTime ParseDateTimeUtc(string date) {
            return DateTime.ParseExact(date, "ddd MMM dd HH:mm:ss K yyyy", new CultureInfo("en-US"), DateTimeStyles.AdjustToUniversal);
        }

    }

}
