using System;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.User;
using Skybrud.Social.Facebook.Responses.Users;

namespace Skybrud.Social.Facebook.Endpoints {
    
    /// <summary>
    /// Class representing the implementation of the users endpoint.
    /// </summary>
    public class FacebookUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FacebookUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal FacebookUsersEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public FacebookUserResponse GetUser() {
            return GetUser("me");
        }

        /// <summary>
        /// Gets information about the user with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        public FacebookUserResponse GetUser(string id) {
            return FacebookUserResponse.ParseResponse(Raw.GetUser(id));
        }

        /// <summary>
        /// Gets information about the user matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookUserResponse GetUser(FacebookGetUserOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return FacebookUserResponse.ParseResponse(Raw.GetUser(options));
        }

        #endregion

    }

}