using System;
using System.Collections.Specialized;
using System.Globalization;
using Skybrud.Social.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints.Raw {
    
    public class TwitterUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwitterOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal TwitterUsersRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the raw API response for a user with the specified ID. Any entities will not be included in the API response.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/users/show</cref>
        /// </see>
        public SocialHttpResponse GetUser(long id) {
            return GetUser(id, false);
        }

        /// <summary>
        /// Gets the raw API response for a user with the specified ID. 
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/users/show</cref>
        /// </see>
        public SocialHttpResponse GetUser(long id, bool includeEntities) {
            NameValueCollection qs = new NameValueCollection { { "user_id", id.ToString(CultureInfo.InvariantCulture) } };
            if (includeEntities) qs.Add("include_entities", "true");
            return GetUser(qs);
        }

        /// <summary>
        /// Gets the raw API response for a user with the specified screen name. Any entities will not be included in the API response.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/users/show</cref>
        /// </see>
        public SocialHttpResponse GetUser(string screenName) {
            return GetUser(screenName, false);
        }

        /// <summary>
        /// Gets the raw API response for a user with the specified screen name.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/users/show</cref>
        /// </see>
        public SocialHttpResponse GetUser(string screenName, bool includeEntities) {
            NameValueCollection qs = new NameValueCollection { { "screen_name", screenName } };
            if (includeEntities) qs.Add("include_entities", "true");
            return GetUser(qs);
        }

        /// <summary>
        /// Gets the raw API response for a user described by the specified <var>NameValueCollection</var>.
        /// </summary>
        /// <param name="qs">The <code>NameValueCollection</code> describing the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/users/show</cref>
        /// </see>
        private SocialHttpResponse GetUser(NameValueCollection qs) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/users/show.json", qs);
        }

        /// <summary>
        /// Provides a simple, relevance-based search interface to public user accounts on Twitter. Try querying by
        /// topical interest, full name, company name, location, or other criteria. Exact match searches are not
        /// supported.
        /// 
        /// Only the first 1,000 matching results are available.
        /// </summary>
        /// <param name="query">The search query to run against people search.</param>
        public SocialHttpResponse Search(string query) {
            return Search(new TwitterUsersSearchOptions {
                Query = query
            });
        }

        /// <summary>
        /// Provides a simple, relevance-based search interface to public user accounts on Twitter. Try querying by
        /// topical interest, full name, company name, location, or other criteria. Exact match searches are not
        /// supported.
        /// 
        /// Only the first 1,000 matching results are available.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse Search(TwitterUsersSearchOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/users/search.json", options);
        }

        #endregion

    }

}