using System;
using Skybrud.Social.Http;
using Skybrud.Social.Microsoft.OAuth;

namespace Skybrud.Social.Microsoft.WindowsLive.Endpoints.Raw {
    
    /// <summary>
    /// Raw implementation of the Windows Live endpoint.
    /// </summary>
    public class WindowsLiveRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public MicrosoftOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal WindowsLiveRawEndpoint(MicrosoftOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public SocialHttpResponse GetSelf() {
            return Client.DoAuthenticatedGetRequest("https://apis.live.net/v5.0/me");
        }

        public SocialHttpResponse GetUser(string userId) {
            if (String.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException("userId");
            return Client.DoAuthenticatedGetRequest("https://apis.live.net/v5.0/" + userId);
        }

        #endregion

    }

}