using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Events;
using Skybrud.Social.Facebook.Responses.Events;

namespace Skybrud.Social.Facebook.Endpoints {

    /// <summary>
    /// Class representing the implementation of the events endpoint.
    /// </summary>
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
        public FacebookEventResponse GetEvent(string id) {
            return FacebookEventResponse.ParseResponse(Raw.GetEvent(id));
        }

        /// <summary>
        /// Gets a list of events of a user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        public FacebookEventsResponse GetEvents(string identifier) {
            return GetEvents(identifier, new FacebookEventsOptions());
        }

        /// <summary>
        /// Gets a list of events of a user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        public FacebookEventsResponse GetEvents(string identifier, int limit) {
            return GetEvents(identifier, new FacebookEventsOptions {
                Limit = limit
            });
        }

        /// <summary>
        /// Gets a list of events of a user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID of the object.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookEventsResponse GetEvents(string identifier, FacebookEventsOptions options) {
            return FacebookEventsResponse.ParseResponse(Raw.GetEvents(identifier, options));
        }

        #endregion

    }

}