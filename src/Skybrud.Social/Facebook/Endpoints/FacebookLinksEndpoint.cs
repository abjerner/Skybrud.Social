using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Responses;

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

        public FacebookResponse<FacebookLink> GetPage(string id) {
            return FacebookHelpers.ParseResponse(Raw.GetLink(id), FacebookLink.Parse);
        }

        // TODO: Implement GetLinks method

        #endregion

    }

}
