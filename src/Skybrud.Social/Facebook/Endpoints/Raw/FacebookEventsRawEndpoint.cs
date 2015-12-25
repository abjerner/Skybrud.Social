using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options.Events;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the events endpoint.
    /// </summary>
    public class FacebookEventsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookEventsRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the event with the specified <code>id</code>.
        /// </summary>
        /// <param name="eventId">The ID of the event.</param>
        public SocialHttpResponse GetEvent(string eventId) {
            return Client.DoAuthenticatedGetRequest("/" + eventId);
        }

        /// <summary>
        /// Gets a list of events for a user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID or name) of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetEvents(string identifier, FacebookEventsOptions options) {
            return Client.DoAuthenticatedGetRequest("/" + identifier + "/events", options);
        }

        #endregion

    }

}