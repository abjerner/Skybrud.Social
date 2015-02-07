using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Responses;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterAccountEndpoint {

        /// <summary>
        /// A reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public TwitterAccountRawEndpoint Raw {
            get { return Service.Client.Account; }
        }

        internal TwitterAccountEndpoint(TwitterService service) {
            Service = service;
        }

        /// <summary>
        /// Verify and get information about the user authenticated user (requires an access token).
        /// </summary>
        public TwitterUserResponse VerifyCredentials() {
            return TwitterUserResponse.ParseResponse(Raw.VerifyCredentials());
        }
    
    }

}