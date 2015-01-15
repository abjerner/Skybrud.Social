using System;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;

namespace Skybrud.Social.Instagram.Endpoints.Raw {
    
    /// <summary>
    /// Class for handling the raw communication with the tags endpoint.
    /// </summary>
    /// <see cref="http://instagram.com/developer/endpoints/tags/"/>
    public class InstagramTagsRawEndpoint {

        #region Properties

        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramTagsRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with information about the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        public SocialHttpResponse GetTagInfo(string tag) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/tags/" + tag);
        }

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with media from the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="minTagId"></param>
        /// <param name="maxTagId"></param>
        public SocialHttpResponse GetRecentMedia(string tag, string minTagId = null, string maxTagId = null) {

            // Declare the query string
            SocialQueryString qs = new SocialQueryString();

            // Add any optional parameters
            if (!String.IsNullOrWhiteSpace(minTagId)) qs.Add("min_tag_id", minTagId);
            if (!String.IsNullOrWhiteSpace(maxTagId)) qs.Add("max_tag_id", maxTagId);

            // Perform the call to the API
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/tags/" + tag + "/media/recent/", qs);

        }

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with media from the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="count">Count of tagged media to return.</param>
        /// <param name="minTagId"></param>
        /// <param name="maxTagId"></param>
        public SocialHttpResponse GetRecentMedia(string tag, int count, string minTagId = null, string maxTagId = null)
        {

            // Declare the query string
            SocialQueryString qs = new SocialQueryString();

            // Add any optional parameters
            qs.Add("count", count);
            if (!String.IsNullOrWhiteSpace(minTagId)) qs.Add("min_tag_id", minTagId);
            if (!String.IsNullOrWhiteSpace(maxTagId)) qs.Add("max_tag_id", maxTagId);

            // Perform the call to the API
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/tags/" + tag + "/media/recent/", qs);

        }
        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. Short tags will be treated as exact matches.
        /// </summary>
        /// <param name="tag">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        public SocialHttpResponse Search(string tag) {

            // Declare the query string
            SocialQueryString qs = new SocialQueryString();
            qs.Add("q", tag);

            // Perform the call to the API
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/tags/search/", qs);

        }

        #endregion

    }

}
