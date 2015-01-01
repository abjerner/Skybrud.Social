using System;
using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Options;
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
        /// The the most recent media of the authenticated user.
        /// </summary>
        public InstagramRecentMediaResponse GetRecentMedia() {
            return InstagramRecentMediaResponse.ParseJson(Raw.GetRecentMedia());
        }

        /// <summary>
        /// The the most recent media of the authenticated user.
        /// </summary>
        /// <param name="options">The search options with any optional parameters.</param>
        public InstagramRecentMediaResponse GetRecentMedia(InstagramMediaSearchOptions options) {
            return InstagramRecentMediaResponse.ParseJson(Raw.GetRecentMedia(options));
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
        /// Gets the most recent media of the user with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The search options with any optional parameters.</param>
        public InstagramRecentMediaResponse GetRecentMedia(long userId, InstagramMediaSearchOptions options) {
            return InstagramRecentMediaResponse.ParseJson(Raw.GetRecentMedia(userId, options));
        }

        #region Obsolete

        [Obsolete("Use GetSelfRecentMedia() instead")]
        public InstagramRecentMediaResponse GetMedia() {
            return GetRecentMedia();
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        [Obsolete("Use GetRecentMedia() instead")]
        public InstagramRecentMediaResponse GetMedia(long userId) {
            return GetRecentMedia(userId, 0);
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">Count of media to return.</param>
        [Obsolete("Use GetRecentMedia() instead")]
        public InstagramRecentMediaResponse GetMedia(long userId, int count) {
            return InstagramRecentMediaResponse.ParseJson(Raw.GetRecentMedia(userId, count));
        }

        #endregion

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        public InstagramUsersResponse Search(string query) {
            return InstagramUsersResponse.ParseJson(Raw.Search(query).Body);
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        /// <param name="count">Number of users to return.</param>
        public InstagramUsersResponse Search(string query, int count) {
            return InstagramUsersResponse.ParseJson(Raw.Search(query, count).Body);
        }

        #endregion

    }

}
