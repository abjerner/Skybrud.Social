using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options;
using Skybrud.Social.Twitter.Responses;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterUsersEndpoint {

        /// <summary>
        /// A reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public TwitterUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        internal TwitterUsersEndpoint(TwitterService service) {
            Service = service;
        }

        public TwitterUserResponse Show(long userId) {
            return TwitterUserResponse.ParseResponse(Raw.GetUser(userId, false));
        }

        public TwitterUserResponse Show(long userId, bool includeEntities) {
            return TwitterUserResponse.ParseResponse(Raw.GetUser(userId, includeEntities));
        }

        public TwitterUserResponse Show(string screenName) {
            return TwitterUserResponse.ParseResponse(Raw.GetUser(screenName, false));
        }

        public TwitterUserResponse Show(string screenName, bool includeEntities) {
            return TwitterUserResponse.ParseResponse(Raw.GetUser(screenName, includeEntities));
        }

        /// <summary>
        /// Alias of <var>Show</var>.
        /// </summary>
        public TwitterUserResponse GetUser(long userId) {
            return TwitterUserResponse.ParseResponse(Raw.GetUser(userId, false));
        }

        /// <summary>
        /// Alias of <var>Show</var>.
        /// </summary>
        public TwitterUserResponse GetUser(long userId, bool includeEntities) {
            return TwitterUserResponse.ParseResponse(Raw.GetUser(userId, includeEntities));
        }

        /// <summary>
        /// Alias of <var>Show</var>.
        /// </summary>
        public TwitterUserResponse GetUser(string screenName) {
            return TwitterUserResponse.ParseResponse(Raw.GetUser(screenName, false));
        }

        /// <summary>
        /// Alias of <var>Show</var>.
        /// </summary>
        public TwitterUserResponse GetUser(string screenName, bool includeEntities) {
            return TwitterUserResponse.ParseResponse(Raw.GetUser(screenName, includeEntities));
        }
        
        /// <summary>
        /// Provides a simple, relevance-based search interface to public user
        /// accounts on Twitter. Try querying by topical interest, full name,
        /// company name, location, or other criteria. Exact match searches are
        /// not supported.
        /// </summary>
        /// <param name="query">The search query to run against people search.</param>
        public TwitterUsersSearchResponse Search(string query) {
            return Search(query, null);
        }

        /// <summary>
        /// Provides a simple, relevance-based search interface to public user
        /// accounts on Twitter. Try querying by topical interest, full name,
        /// company name, location, or other criteria. Exact match searches are
        /// not supported.
        /// </summary>
        /// <param name="query">The search query to run against people search.</param>
        /// <param name="options">The search options.</param>
        public TwitterUsersSearchResponse Search(string query, TwitterUsersSearchOptions options) {
            return TwitterUsersSearchResponse.ParseJson(Raw.Search(query, options));
        }

    }

}
