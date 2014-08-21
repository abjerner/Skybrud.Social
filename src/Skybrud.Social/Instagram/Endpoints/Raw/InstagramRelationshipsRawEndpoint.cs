using Skybrud.Social.Instagram.OAuth;

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
        public string Follows(long userId) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/users/" + userId + "/follows?access_token=" + Client.AccessToken);
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public string FollowedBy(long userId) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/users/" + userId + "/followed-by?access_token=" + Client.AccessToken);
        }

        #endregion

    }

}
