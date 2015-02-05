using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options;
using Skybrud.Social.Twitter.Responses;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterSearchEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public TwitterSearchRawEndpoint Raw {
            get { return Service.Client.Search; }
        }

        #endregion

        #region Constructor(s)

        internal TwitterSearchEndpoint(TwitterService service) {
            Service = service;
        }

        #endregion

        #region SearchTweets(...)

        /// <summary>
        /// Gets tweets matching the specified <code>query</code>.
        /// </summary>
        /// <param name="query">The search query.</param>
        public TwitterSearchTweetsResponse GetTweets(string query) {
            return TwitterSearchTweetsResponse.ParseJson(Raw.GetTweets(query).Body); 
        }

        /// <summary>
        /// Gets tweets matching the specified <code>query</code>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="count">The maximum amount of tweets to return (default: 15, max: 100).</param>
        public TwitterSearchTweetsResponse GetTweets(string query, int count) {
            return TwitterSearchTweetsResponse.ParseJson(Raw.GetTweets(query, count).Body); 
        }

        /// <summary>
        /// Gets tweets matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The search options.</param>
        public TwitterSearchTweetsResponse GetTweets(TwitterSearchTweetOptions options) {
            return TwitterSearchTweetsResponse.ParseJson(Raw.GetTweets(options).Body); 
        }

        #endregion

    }

}