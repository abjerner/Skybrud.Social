using System.Collections.Specialized;
using Skybrud.Social.Twitter.OAuth;

namespace Skybrud.Social.Twitter.Endpoints.Raw {
    
    public class TwitterSearchRawEndpoint {

        public TwitterOAuthClient Client { get; private set; }

        internal TwitterSearchRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #region SearchTweets(...)

        /// <summary>
        /// Gets tweets matching the specified <code>query</code>.
        /// </summary>
        /// <param name="query">The search query.</param>
        public string GetTweets(string query) {
            return GetTweets(query, 0);
        }

        /// <summary>
        /// Gets tweets matching the specified <code>query</code>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="count">The maximum amount of tweets to return (default: 15, max: 100).</param>
        public string GetTweets(string query, int count) {
            
            // Define the query string
            NameValueCollection qs = new NameValueCollection { { "q", query } };
            if (count > 0) qs.Add("count", count + "");

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/search/tweets.json", qs);
        
        }

        #endregion

    }

}
