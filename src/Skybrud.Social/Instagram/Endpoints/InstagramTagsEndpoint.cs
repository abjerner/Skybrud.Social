using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {
    
    public class InstagramTagsEndpoint {

        #region Properties

        public InstagramService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public InstagramTagsRawEndpoint Raw {
            get { return Service.Client.Tags; }
        }

        #endregion

        #region Constructors

        internal InstagramTagsEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        public InstagramTagResponse GetTagInfo(string tag) {
            return InstagramTagResponse.ParseJson(Raw.GetTagInfo(tag));
        }

        /// <summary>
        /// Gets a list of media from the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="minTagId"></param>
        /// <param name="maxTagId"></param>
        public InstagramRecentMediaResponse GetRecentMedia(string tag, string minTagId = null, string maxTagId = null) {
            return InstagramRecentMediaResponse.ParseJson(Raw.GetRecentMedia(tag, minTagId, maxTagId));
        }

        // TODO: Implement Search() method

        #endregion

    }

}
