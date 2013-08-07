using System.Net;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Endpoints {
    
    public class TwitterAccountEndpoint {

        protected TwitterService Service;

        internal TwitterAccountEndpoint(TwitterService service) {
            Service = service;
        }

        /// <summary>
        /// Verify and get information about the user (requires an access token).
        /// </summary>
        public TwitterUser VerifyCredentials() {

            // Make a call to the API
            HttpStatusCode status;
            string response = Service.Client.VerifyCredentials(out status);

            // Check for errors
            if (status != HttpStatusCode.OK) {
                throw TwitterException.Parse(response);
            }

            // Parse the response
            return TwitterUser.ParseJson(response);

        }
    
    }

}
