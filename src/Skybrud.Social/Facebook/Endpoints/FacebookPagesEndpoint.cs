using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookPagesEndpoint {

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookPagesRawEndpoint Raw {
            get { return Service.Client.Pages; }
        }

        internal FacebookPagesEndpoint(FacebookService service) {
            Service = service;
        }

        #region Methods

        /// <summary>
        /// Gets information about a photo with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the photo.</param>
        public FacebookResponse<FacebookPage> GetPage(string id) {
            return FacebookHelpers.ParseResponse(Raw.GetPage(id), FacebookPage.Parse);
        }

        #endregion

    }

}
