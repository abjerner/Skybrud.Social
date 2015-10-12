using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Options.Relationships;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <summary>
    /// Class representing the implementation of the relationships endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/relationships/</cref>
    /// </see>
    public class InstagramRelationshipsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
        public InstagramService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public InstagramRelationshipsRawEndpoint Raw {
            get { return Service.Client.Relationships; }
        }

        #endregion

        #region Constructors

        internal InstagramRelationshipsEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the list of users this user follows.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramUsersResponse Follows(long userId) {
            return Follows(userId, new InstagramFollowsOptions());
        }

        /// <summary>
        /// Get the list of users this user follows.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of users to return.</param>
        public InstagramUsersResponse Follows(long userId, int count) {
            return Follows(userId, new InstagramFollowsOptions(count));
        }

        /// <summary>
        /// Get the list of users this user follows.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public InstagramUsersResponse Follows(long userId, InstagramFollowsOptions options) {
            return InstagramUsersResponse.ParseResponse(Raw.Follows(userId, options));
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramUsersResponse FollowedBy(long userId) {
            return FollowedBy(userId, new InstagramFollowedByOptions());
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of users to return.</param>
        public InstagramUsersResponse FollowedBy(long userId, int count) {
            return FollowedBy(userId, new InstagramFollowedByOptions(count));
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public InstagramUsersResponse FollowedBy(long userId, InstagramFollowedByOptions options) {
            return InstagramUsersResponse.ParseResponse(Raw.FollowedBy(userId, options));
        }

        #endregion

    }

}