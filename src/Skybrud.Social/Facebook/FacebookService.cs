using System;
using Skybrud.Social.Facebook.Endpoints;
using Skybrud.Social.Facebook.OAuth;

namespace Skybrud.Social.Facebook {
    
    /// <summary>
    /// Class working as an entry point to the Facebook Graph API.
    /// </summary>
    public class FacebookService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client for communication with the Facebook API.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        /// <summary>
        /// Gets a reference to the accounts endpoint.
        /// </summary>
        public FacebookAccountsEndpoint Accounts { get; private set; }

        /// <summary>
        /// Gets a reference to the albums endpoint.
        /// </summary>
        public FacebookAlbumsEndpoint Albums { get; private set; }

        /// <summary>
        /// Gets a reference to the apps endpoint.
        /// </summary>
        public FacebookAppsEndpoint Apps { get; private set; }

        /// <summary>
        /// Gets a reference to the debug endpoint.
        /// </summary>
        public FacebookDebugEndpoint Debug { get; private set; }

        /// <summary>
        /// Gets a reference to the comments endpoint.
        /// </summary>
        public FacebookCommentsEndpoint Comments { get; private set; }

        /// <summary>
        /// Gets a reference to the events endpoint.
        /// </summary>
        public FacebookEventsEndpoint Events { get; private set; }

        /// <summary>
        /// Gets a reference to the feed endpoint.
        /// </summary>
        public FacebookFeedEndpoint Feed { get; private set; }

        /// <summary>
        /// Gets a reference to the likes endpoint.
        /// </summary>
        public FacebookLikesEndpoint Likes { get; private set; }

        /// <summary>
        /// Gets a reference to the links endpoint.
        /// </summary>
        public FacebookLinksEndpoint Links { get; private set; }

        /// <summary>
        /// Gets a reference to the pages endpoint.
        /// </summary>
        public FacebookPagesEndpoint Pages { get; private set; }

        /// <summary>
        /// Gets a reference to the photos endpoint.
        /// </summary>
        public FacebookPhotosEndpoint Photos { get; private set; }

        /// <summary>
        /// Gets a reference to the posts endpoint.
        /// </summary>
        public FacebookPostsEndpoint Posts { get; private set; }

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
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
            Feed = new FacebookFeedEndpoint(this);
            Likes = new FacebookLikesEndpoint(this);
            Links = new FacebookLinksEndpoint(this);
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
        /// <returns>Returns the created instance of <code>FacebookService</code>.</returns>
        public static FacebookService CreateFromAccessToken(string accessToken) {
            return new FacebookService {
                Client = new FacebookOAuthClient(accessToken)
            };
        }

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        /// <returns>Returns the created instance of <code>FacebookService</code>.</returns>
        public static FacebookService CreateFromOAuthClient(FacebookOAuthClient client) {
            if (client == null) throw new ArgumentNullException("client");
            return new FacebookService {
                Client = client
            };
        }

        #endregion

    }

}