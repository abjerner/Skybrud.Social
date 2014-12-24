using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookUsersEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
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
        public FacebookResponse<FacebookUser> GetUser() {
            return GetUser("me");
        }

        /// <summary>
        /// Gets information about a user with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        public FacebookResponse<FacebookUser> GetUser(string id) {
            return FacebookHelpers.ParseResponse(Raw.GetUser(id), FacebookUser.Parse);
        }

        #endregion

    }

}
