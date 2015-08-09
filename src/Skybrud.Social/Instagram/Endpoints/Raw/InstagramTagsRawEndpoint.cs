using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options.Tags;

namespace Skybrud.Social.Instagram.Endpoints.Raw {
    
    /// <summary>
    /// Class for handling the raw communication with the tags endpoint.
    /// </summary>
    /// <see cref="http://instagram.com/developer/endpoints/tags/"/>
    public class InstagramTagsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
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
            return GetRecentMedia(tag, new InstagramTagRecentMediaOptions {
                MinTagId = minTagId,
                MaxTagId = maxTagId
            });
        }

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with media from the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <param name="minTagId"></param>
        /// <param name="maxTagId"></param>
        public SocialHttpResponse GetRecentMedia(string tag, int count, string minTagId = null, string maxTagId = null) {
            return GetRecentMedia(tag, new InstagramTagRecentMediaOptions {
                Count = count,
                MinTagId = minTagId,
                MaxTagId = maxTagId
            });
        }

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with media from the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetRecentMedia(string tag, InstagramTagRecentMediaOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/tags/" + tag + "/media/recent/", options);
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
