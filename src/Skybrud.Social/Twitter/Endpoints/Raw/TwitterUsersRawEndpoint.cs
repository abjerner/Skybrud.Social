using System.Collections.Specialized;
using System.Globalization;
using Skybrud.Social.Twitter.Attributes;
using Skybrud.Social.Twitter.Enums;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints.Raw {
    
    public class TwitterUsersRawEndpoint {

        public TwitterOAuthClient Client { get; private set; }

        internal TwitterUsersRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        /// <summary>
        /// Gets the raw API response for a user with the specified ID. Any entities will not be included in the API response.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/users/show"/>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetUser(long id) {
            return GetUser(id, false);
        }

        /// <summary>
        /// Gets the raw API response for a user with the specified ID. 
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/users/show"/>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetUser(long id, bool includeEntities) {
            NameValueCollection qs = new NameValueCollection { { "user_id", id.ToString(CultureInfo.InvariantCulture) } };
            if (includeEntities) qs.Add("include_entities", "true");
            return GetUser(qs);
        }

        /// <summary>
        /// Gets the raw API response for a user with the specified screen name. Any entities will not be included in the API response.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/users/show"/>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetUser(string screenName) {
            return GetUser(screenName, false);
        }

        /// <summary>
        /// Gets the raw API response for a user with the specified screen name.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/users/show"/>
        [TwitterMethod(rateLimited: true, rate: "180/user, 180/app", authentication: TwitterAuthentication.Required)]
        public string GetUser(string screenName, bool includeEntities) {
            NameValueCollection qs = new NameValueCollection { { "screen_name", screenName } };
            if (includeEntities) qs.Add("include_entities", "true");
            return GetUser(qs);
        }

        /// <summary>
        /// Gets the raw API response for a user described by the specified <var>NameValueCollection</var>.
        /// </summary>
        /// <param name="qs">The <var>NameValueCollection</var> describing the user.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/users/show"/>
        private string GetUser(NameValueCollection qs) {
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/users/show.json", qs);
        }

        [TwitterMethod(rateLimited: true, rate: "180/user", authentication: TwitterAuthentication.Required)]
        public string Search(string query) {
            return Search(query, null);
        }

        [TwitterMethod(rateLimited: true, rate: "180/user", authentication: TwitterAuthentication.Required)]
        public string Search(string query, TwitterUsersSearchOptions options) {

            // Declare the query string
            SocialQueryString qs = new SocialQueryString();
            qs.Set("q", query);
            if (options != null) {
                qs.Set("page", options.Page, options.Page > 1);
                qs.Set("count", options.Count, options.Count != 20);
                qs.Set("include_entities", options.IncludeEntities, options.IncludeEntities != true);
            }

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/users/search.json", qs.NameValueCollection);

        }
    
    }

}
