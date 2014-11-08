using System;
using Skybrud.Social.Instagram.Endpoints;
using Skybrud.Social.Instagram.OAuth;

namespace Skybrud.Social.Instagram {
    
    public class InstagramService {

        #region Properties

        /// <summary>
        /// The internal OAuth client for communication with the Instagram API.
        /// </summary>
        public InstagramOAuthClient Client { get; private set; }

        public InstagramLocationsEndpoint Locations { get; private set; }
        public InstagramMediaEndpoint Media { get; private set; }
        public InstagramRelationshipsEndpoint Relationships { get; private set; }
        public InstagramTagsEndpoint Tags { get; private set; }
        public InstagramUsersEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        private InstagramService() {
            Locations = new InstagramLocationsEndpoint(this);
            Media = new InstagramMediaEndpoint(this);
            Relationships = new InstagramRelationshipsEndpoint(this);
            Tags = new InstagramTagsEndpoint(this);
            Users = new InstagramUsersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified access token. Internally a new OAuth client will be
        /// initialized from the access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static InstagramService CreateFromAccessToken(string accessToken) {
            return new InstagramService {
                Client = new InstagramOAuthClient(accessToken)
            };
        }

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static InstagramService CreateFromOAuthClient(InstagramOAuthClient client) {

            // This should never be null
            if (client == null) throw new ArgumentNullException("client");

            // Initialize the service
            return new InstagramService {
                Client = client
            };

        }

        #endregion

    }

}