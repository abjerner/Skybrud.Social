using System;
using System.Globalization;
using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Options.Users;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <summary>
    /// Class representing the implementation of the users endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/</cref>
    /// </see>
    public class InstagramUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
        public InstagramService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
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
        /// Gets the feed of the authenticated user.
        /// </summary>
        public InstagramUserFeedResponse GetUserFeed() {
            return GetUserFeed(new InstagramUserFeedOptions());
        }

        /// <summary>
        /// Gets the feed of the authenticated user.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public InstagramUserFeedResponse GetUserFeed(InstagramUserFeedOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return InstagramUserFeedResponse.ParseResponse(Raw.GetUserFeed(options));
        }

        /// <summary>
        /// Gets information about the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramUserResponse GetUser(long userId) {
            return InstagramUserResponse.ParseResponse(Raw.GetUser(userId.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Gets information about the user with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        [Obsolete("Use the GetInfo() instead.")]
        public InstagramUserResponse GetInfo(long id) {
            // TODO: Remove for v1.0
            return InstagramUserResponse.ParseResponse(Raw.GetUser(id.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Gets the the most recent media of the authenticated user.
        /// </summary>
        public InstagramRecentMediaResponse GetRecentMedia() {
            return InstagramRecentMediaResponse.ParseResponse(Raw.GetRecentMedia("self"));
        }

        /// <summary>
        /// Gets the the most recent media of the authenticated user.
        /// </summary>
        /// <param name="options">The search options with any optional parameters.</param>
        public InstagramRecentMediaResponse GetRecentMedia(InstagramUserRecentMediaOptions options) {
            return InstagramRecentMediaResponse.ParseResponse(Raw.GetRecentMedia("self", options));
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramRecentMediaResponse GetRecentMedia(long userId) {
            return InstagramRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(userId.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        public InstagramRecentMediaResponse GetRecentMedia(long userId, int count) {
            return InstagramRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(userId.ToString(CultureInfo.InvariantCulture), count));
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The search options with any optional parameters.</param>
        public InstagramRecentMediaResponse GetRecentMedia(long userId, InstagramUserRecentMediaOptions options) {
            return InstagramRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(userId.ToString(CultureInfo.InvariantCulture), options));
        }

        /// <summary>
        /// Gets a list of media liked by the authenticated user.
        /// </summary>
        public InstagramLikedMediaResponse GetLikedMedia() {
            return InstagramLikedMediaResponse.ParseResponse(Raw.GetLikedMedia());
        }

        /// <summary>
        /// Gets a list of media liked by the authenticated user.
        /// </summary>
        /// <param name="count">The maximum amount of media to be returned.</param>
        public InstagramLikedMediaResponse GetLikedMedia(int count) {
            return InstagramLikedMediaResponse.ParseResponse(Raw.GetLikedMedia(count));
        }

        /// <summary>
        /// Gets a list of media liked by the authenticated user.
        /// </summary>
        /// <param name="options">The search options with any optional parameters.</param>
        public InstagramLikedMediaResponse GetLikedMedia(InstagramUserLikedMediaOptions options) {
            return InstagramLikedMediaResponse.ParseResponse(Raw.GetLikedMedia(options));
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
        /// <param name="count">The maximum amount of users to be returned.</param>
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