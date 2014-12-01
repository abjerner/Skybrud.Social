using System.Collections.Specialized;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options;

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
            return GetTweets(new TwitterSearchTweetOptions {
                Query = query,
                Count = count
            });
        }

        /// <summary>
        /// Gets tweets matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The search options.</param>
        public string GetTweets(TwitterSearchTweetOptions options) {
            if (options == null) options = new TwitterSearchTweetOptions();
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/search/tweets.json", options.GetQuery().NameValueCollection);
        }

        #endregion

    }

}
