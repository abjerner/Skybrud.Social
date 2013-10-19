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
        /// <param name="minId"></param>
        /// <param name="maxId"></param>
        public InstagramRecentMediaResponse GetRecentMedia(string tag, string minId = null, string maxId = null) {
            return InstagramRecentMediaResponse.ParseJson(Raw.GetRecentMedia(tag, minId, maxId));
        }

        // TODO: Implement Search() method

        #endregion

    }

}
