using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <see cref="http://instagram.com/developer/endpoints/tags/"/>
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
            return InstagramTagResponse.ParseResponse(Raw.GetTagInfo(tag));
        }

        /// <summary>
        /// Gets a list of media from the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="minTagId"></param>
        /// <param name="maxTagId"></param>
        public InstagramRecentMediaResponse GetRecentMedia(string tag, string minTagId = null, string maxTagId = null) {
            return InstagramRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(tag, minTagId, maxTagId));
        }

        /// <summary>
        /// Gets a list of media from the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="count">Count of tagged media to return.</param>
        /// <param name="minTagId">Return media before this min_tag_id</param>
        /// <param name="maxTagId">Return media after this max_tag_id</param>
        public InstagramRecentMediaResponse GetRecentMedia(string tag, int count, string minTagId = null, string maxTagId = null) {
            return InstagramRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(tag, count, minTagId, maxTagId));
        }

        // TODO: Implement Search() method

        #endregion

    }

}