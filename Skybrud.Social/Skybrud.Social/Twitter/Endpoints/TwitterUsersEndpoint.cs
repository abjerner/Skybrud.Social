using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Objects;

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

        public TwitterUser Show(long userId) {
            return TwitterUser.ParseJson(Raw.GetUser(userId, false));
        }

        public TwitterUser Show(long userId, bool includeEntities) {
            return TwitterUser.ParseJson(Raw.GetUser(userId, includeEntities));
        }

        public TwitterUser Show(string screenName) {
            return TwitterUser.ParseJson(Raw.GetUser(screenName, false));
        }

        public TwitterUser Show(string screenName, bool includeEntities) {
            return TwitterUser.ParseJson(Raw.GetUser(screenName, includeEntities));
        }

        /// <summary>
        /// Alias of <var>Show</var>.
        /// </summary>
        public TwitterUser GetUser(long userId) {
            return TwitterUser.ParseJson(Raw.GetUser(userId, false));
        }

        /// <summary>
        /// Alias of <var>Show</var>.
        /// </summary>
        public TwitterUser GetUser(long userId, bool includeEntities) {
            return TwitterUser.ParseJson(Raw.GetUser(userId, includeEntities));
        }

        /// <summary>
        /// Alias of <var>Show</var>.
        /// </summary>
        public TwitterUser GetUser(string screenName) {
            return TwitterUser.ParseJson(Raw.GetUser(screenName, false));
        }

        /// <summary>
        /// Alias of <var>Show</var>.
        /// </summary>
        public TwitterUser GetUser(string screenName, bool includeEntities) {
            return TwitterUser.ParseJson(Raw.GetUser(screenName, includeEntities));
        }

    }

}
