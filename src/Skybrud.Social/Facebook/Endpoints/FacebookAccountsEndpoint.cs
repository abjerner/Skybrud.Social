using System;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Accounts;
using Skybrud.Social.Facebook.Responses.Accounts;

namespace Skybrud.Social.Facebook.Endpoints {

    /// <summary>
    /// Class representing the implementation of the accounts endpoint.
    /// </summary>
    public class FacebookAccountsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FacebookAccountsRawEndpoint Raw {
            get { return Service.Client.Accounts; }
        }

        #endregion

        #region Constructors

        internal FacebookAccountsEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about accounts associated with the current user by calling the <code>/me/accounts</code>
        /// method. This call requires a user access token.
        /// </summary>
        public FacebookAccountsResponse GetAccounts() {
            return FacebookAccountsResponse.ParseResponse(Raw.GetAccounts());
        }

        /// <summary>
        /// Gets information about accounts associated with the current user by calling the <code>/me/accounts</code>
        /// method. This call requires a user access token.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookAccountsResponse GetAccounts(FacebookGetAccountsOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return FacebookAccountsResponse.ParseResponse(Raw.GetAccounts());
        }

        #endregion

    }

}