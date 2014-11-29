using Skybrud.Social.Facebook.Collections;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookEventsEndpoint {

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookEventsRawEndpoint Raw {
            get { return Service.Client.Events; }
        }

        internal FacebookEventsEndpoint(FacebookService service) {
            Service = service;
        }

        #region Methods

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        public FacebookResponse<FacebookEventSummary> GetEvents(string identifier, int limit = 0) {
            return FacebookHelpers.ParseResponse(Raw.GetEvents(identifier, limit), FacebookEventSummary.Parse);
        }

        #endregion

    }

}
