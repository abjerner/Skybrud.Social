using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Responses;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookLinksEndpoint {

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookLinksRawEndpoint Raw {
            get { return Service.Client.Links; }
        }

        internal FacebookLinksEndpoint(FacebookService service) {
            Service = service;
        }

        #region Methods

        public FacebookResponse<FacebookLink> GetLink(string id) {
            return FacebookHelpers.ParseResponse(Raw.GetLink(id), FacebookLink.Parse);
        }

        // TODO: Implement GetLinks method






        ///// <summary>
        ///// Posts a link with the specified options to the feed of the authenticated user. If successful, the ID of the created post is returned.
        ///// </summary>
        ///// <param name="options">The options for the link.</param>
        ///// <returns>Returns the ID of the created link.</returns>
        //public string PostLink(FacebookPostLinkOptions options) {
        //    return PostLink("me", options);
        //}

        ///// <summary>
        ///// Posts a link with the specified options.
        ///// </summary>
        ///// <param name="identifier">The identifier of the user, page or similar.</param>
        ///// <param name="options">The options for the link.</param>
        ///// <returns>Returns the ID of the created link.</returns>
        //public string PostLink(string identifier, FacebookPostLinkOptions options) {

        //    // Make the call to the API
        //    string response = Raw.PostLink(identifier, options);

        //    // Parse the raw JSON response
        //    JsonObject obj = JsonConverter.ParseObject(response);

        //    // Some error checking
        //    if (obj.HasValue("error")) throw obj.GetObject("error", FacebookApiException.Parse);

        //    // Get the ID of the created link
        //    return obj.GetString("id");

        //}



        #endregion

    }

}
