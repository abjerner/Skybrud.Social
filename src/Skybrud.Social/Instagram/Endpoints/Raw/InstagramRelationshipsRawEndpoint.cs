using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options;

namespace Skybrud.Social.Instagram.Endpoints.Raw {
    
    public class InstagramRelationshipsRawEndpoint {

        #region Properties

        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramRelationshipsRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the list of users this user follows.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse Follows(long userId, InstagramFollowsOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/" + userId + "/follows", options);
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse FollowedBy(long userId, InstagramFollowedByOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/" + userId + "/followed-by", options);
        }

        #endregion

    }

}