using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Responses.Users;

namespace Skybrud.Social.Facebook.Endpoints {
    
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

        #endregion

    }

}