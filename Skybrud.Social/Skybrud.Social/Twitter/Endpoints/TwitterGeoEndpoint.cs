using Skybrud.Social.Twitter.Endpoints.Raw;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterGeoEndpoint {

        /// <summary>
        /// A reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public TwitterGeoRawEndpoint Raw {
            get { return Service.Client.Geo; }
        }

        internal TwitterGeoEndpoint(TwitterService service) {
            Service = service;
        }

    }

}
