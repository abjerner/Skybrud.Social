using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Responses;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterAccountEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public TwitterAccountRawEndpoint Raw {
            get { return Service.Client.Account; }
        }

        #endregion

        #region Constructors

        internal TwitterAccountEndpoint(TwitterService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Verify and get information about the user authenticated user (requires an access token).
        /// </summary>
        public TwitterUserResponse VerifyCredentials() {
            return TwitterUserResponse.ParseResponse(Raw.VerifyCredentials());
        }

        #endregion

    }

}