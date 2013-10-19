using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {

    public class InstagramRelationshipsEndpoint {

        #region Properties

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
        public InstagramUserSummariesResponse Follows(long userId) {
            return InstagramUserSummariesResponse.ParseJson(Raw.Follows(userId));
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramUserSummariesResponse FollowedBy(long userId) {
            return InstagramUserSummariesResponse.ParseJson(Raw.FollowedBy(userId));
        }

        #endregion

    }

}
