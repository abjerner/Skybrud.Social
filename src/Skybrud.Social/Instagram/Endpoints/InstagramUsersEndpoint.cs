using System.Globalization;
using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Options.Users;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <see cref="http://instagram.com/developer/endpoints/users/"/>
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
            return InstagramUserResponse.ParseResponse(Raw.GetUser("self"));
        }

        /// <summary>
        /// Gets information about a user by the specified ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        public InstagramUserResponse GetInfo(long id) {
            return InstagramUserResponse.ParseResponse(Raw.GetUser(id.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Gets the the most recent media of the authenticated user.
        /// </summary>
        public InstagramRecentMediaResponse GetRecentMedia() {
            return GetRecentMedia(new InstagramUserRecentMediaOptions());
        }

        /// <summary>
        /// Gets the the most recent media of the authenticated user.
        /// </summary>
        /// <param name="options">The search options with any optional parameters.</param>
        public InstagramRecentMediaResponse GetRecentMedia(InstagramUserRecentMediaOptions options) {
            return InstagramRecentMediaResponse.ParseJson(Raw.GetRecentMedia("self", options).Body);
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramRecentMediaResponse GetRecentMedia(long userId) {
            return GetRecentMedia(userId, new InstagramUserRecentMediaOptions());
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">Count of media to return.</param>
        public InstagramRecentMediaResponse GetRecentMedia(long userId, int count) {
            return GetRecentMedia(userId, new InstagramUserRecentMediaOptions {
                Count = count
            });
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The search options with any optional parameters.</param>
        public InstagramRecentMediaResponse GetRecentMedia(long userId, InstagramUserRecentMediaOptions options) {
            return InstagramRecentMediaResponse.ParseJson(Raw.GetRecentMedia(userId + "", options).Body);
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        public InstagramUsersResponse Search(string query) {
            return InstagramUsersResponse.ParseResponse(Raw.Search(query));
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        /// <param name="count">The maximum amount of users to return.</param>
        public InstagramUsersResponse Search(string query, int count) {
            return InstagramUsersResponse.ParseResponse(Raw.Search(query, count));
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public InstagramUsersResponse Search(InstagramUserSearchOptions options) {
            return InstagramUsersResponse.ParseResponse(Raw.Search(options));
        }

        #endregion

    }

}