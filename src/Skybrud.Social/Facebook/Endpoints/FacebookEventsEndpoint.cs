using Skybrud.Social.Facebook.Collections;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookEventsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FacebookEventsRawEndpoint Raw {
            get { return Service.Client.Events; }
        }

        #endregion

        #region Constructors

        internal FacebookEventsEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the event with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the event.</param>
        public FacebookResponse<FacebookEvent> GetEvent(string id) {
            return FacebookHelpers.ParseResponse(Raw.GetEvent(id), FacebookEvent.Parse);
        }

        /// <summary>
        /// Gets a list of events of a user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        public FacebookResponse<FacebookEventsCollection> GetEvents(string identifier) {
            return GetEvents(identifier, new FacebookEventsOptions());
        }

        /// <summary>
        /// Gets a list of events of a user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        public FacebookResponse<FacebookEventsCollection> GetEvents(string identifier, int limit) {
            return GetEvents(identifier, new FacebookEventsOptions {
                Limit = limit
            });
        }

        /// <summary>
        /// Gets a list of events of a user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID of the object.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookResponse<FacebookEventsCollection> GetEvents(string identifier, FacebookEventsOptions options) {
            return FacebookHelpers.ParseResponse(Raw.GetEvents(identifier, options), FacebookEventsCollection.Parse);
        }

        #endregion

    }

}