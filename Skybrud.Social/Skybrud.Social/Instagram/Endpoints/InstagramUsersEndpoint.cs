using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {

    public class InstagramUsersEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the Instagram service.
        /// </summary>
        public InstagramService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public InstagramUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal InstagramUsersEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public InstagramUserResponse GetSelf() {
            return InstagramUserResponse.ParseJson(Raw.GetSelf());
        }

        /// <summary>
        /// Gets information about a user by the specified ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        public InstagramUserResponse GetInfo(long id) {
            return InstagramUserResponse.ParseJson(Raw.GetUser(id));
        }

        /// <summary>
        /// The the most recent media of the current user.
        /// </summary>
        public InstagramRecentMediaResponse GetSelfRecentMedia() {
            return InstagramRecentMediaResponse.ParseJson(Raw.GetSelfRecentMedia());
        }
        
        /// <summary>
        /// The the most recent media of the current user.
        /// </summary>
        /// <param name="count">Count of media to return.</param>
        public InstagramRecentMediaResponse GetSelfRecentMedia(int count) {
            return InstagramRecentMediaResponse.ParseJson(Raw.GetSelfRecentMedia(count));
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramRecentMediaResponse GetRecentMedia(long userId) {
            return GetRecentMedia(userId, 0);
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">Count of media to return.</param>
        public InstagramRecentMediaResponse GetRecentMedia(long userId, int count) {
            return InstagramRecentMediaResponse.ParseJson(Raw.GetRecentMedia(userId, count));
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        public InstagramUsersResponse Search(string query) {
            return InstagramUsersResponse.ParseJson(Raw.Search(query, 0));
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        /// <param name="count">Number of users to return.</param>
        public InstagramUsersResponse Search(string query, int count) {
            return InstagramUsersResponse.ParseJson(Raw.Search(query, count));
        }

        #endregion

    }

}
