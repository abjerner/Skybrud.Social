using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {
    
    /// <summary>
    /// Class representing the implementation of the tags endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/</cref>
    /// </see>
    public class InstagramTagsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
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

        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. Short tags will be treated as exact matches.
        /// </summary>
        /// <param name="tag">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        public InstagramSearchTagsResponse Search(string tag) {
            return InstagramSearchTagsResponse.ParseResponse(Raw.Search(tag));
        }

        #endregion

    }

}