using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Responses;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookMethodsEndpoint {

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookMethodsRawEndpoint Raw {
            get { return Service.Client.Methods; }
        }

        internal FacebookMethodsEndpoint(FacebookService service) {
            Service = service;
        }

        #region GetStatusMessage

        /// <summary>
        /// Gets information about a status message with the specified <var>ID</var>.
        /// </summary>
        /// <param name="statusMessageId">The ID of the status message.</param>
        public FacebookStatusMessage GetStatusMessage(string statusMessageId) {
            return FacebookStatusMessage.Parse(JsonObject.ParseJson(Raw.GetObject(statusMessageId)));
        }

        #endregion

        #region Post status message

        /// <summary>
        /// Posts a status message to the wall of the authenticated user.
        /// </summary>
        /// <param name="message">The text of the status message.</param>
        /// <returns>Returns the ID of the created status message.</returns>
        public string PostStatusMessage(string message) {
            return PostStatusMessage("me", message);
        }
        
        /// <summary>
        /// Posts a status message to the wall of the specified <var>identifier</var>.
        /// </summary>
        /// <param name="identifier">The identifier of the user, page or similar.</param>
        /// <param name="message">The text of the status message.</param>
        /// <returns>Returns the ID of the created status message.</returns>
        public string PostStatusMessage(string identifier, string message) {

            // Make the call to the API
            string response = Raw.PostStatusMessage(identifier, message);

            // Parse the raw JSON response
            JsonObject obj = JsonConverter.ParseObject(response);

            // Some error checking
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookApiException.Parse);

            // Get the ID of the created link
            return obj.GetString("id");

        }

        #endregion
    
    }

}
