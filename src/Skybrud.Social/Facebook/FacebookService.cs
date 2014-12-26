using System;
using Skybrud.Social.Facebook.Endpoints;
using Skybrud.Social.Facebook.OAuth;

namespace Skybrud.Social.Facebook {

    public class FacebookService {

        #region Properties

        /// <summary>
        /// The internal OAuth client for communication with the Facebook API.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        public FacebookAccountsEndpoint Accounts { get; private set; }
        public FacebookAlbumsEndpoint Albums { get; private set; }
        public FacebookAppsEndpoint Apps { get; private set; }
        public FacebookDebugEndpoint Debug { get; private set; }
        public FacebookCommentsEndpoint Comments { get; private set; }
        public FacebookEventsEndpoint Events { get; private set; }
        public FacebookLikesEndpoint Likes { get; private set; }
        public FacebookLinksEndpoint Links { get; private set; }
        public FacebookMethodsEndpoint Methods { get; private set; }
        public FacebookPagesEndpoint Pages { get; private set; }
        public FacebookPhotosEndpoint Photos { get; private set; }
        public FacebookPostsEndpoint Posts { get; private set; }
        public FacebookUsersEndpoint Users { get; private set; }

        #endregion

        #region Constructor(s)

        private FacebookService() {
            Accounts = new FacebookAccountsEndpoint(this);
            Albums = new FacebookAlbumsEndpoint(this);
            Apps = new FacebookAppsEndpoint(this);
            Debug = new FacebookDebugEndpoint(this);
            Comments = new FacebookCommentsEndpoint(this);
            Events = new FacebookEventsEndpoint(this);
            Likes = new FacebookLikesEndpoint(this);
            Links = new FacebookLinksEndpoint(this);
            Methods = new FacebookMethodsEndpoint(this);
            Pages = new FacebookPagesEndpoint(this);
            Photos = new FacebookPhotosEndpoint(this);
            Posts = new FacebookPostsEndpoint(this);
            Users = new FacebookUsersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified access token. Internally a new OAuth client will be
        /// initialized from the access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static FacebookService CreateFromAccessToken(string accessToken) {
            return new FacebookService {
                Client = new FacebookOAuthClient(accessToken)
            };
        }

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static FacebookService CreateFromOAuthClient(FacebookOAuthClient client) {

            // This should never be null
            if (client == null) throw new ArgumentNullException("client");

            // Initialize the service
            FacebookService service = new FacebookService {
                Client = client
            };

            // Set the endpoints etc.
            service.Methods = new FacebookMethodsEndpoint(service);

            // Return the service
            return service;
        
        }

        #endregion

    }

}