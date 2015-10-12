using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Instagram API.
    /// </summary>
    public class InstagramOAuthException : InstagramException {

        /// <summary>
        /// Initializes a new exception based on the specified <code>response</code> and <code>meta</code> data.
        /// </summary>
        /// <param name="response">The response the exception should be based on.</param>
        /// <param name="meta">The meta data with information about the exception.</param>
        public InstagramOAuthException(SocialHttpResponse response, InstagramMetaData meta) : base(response, meta) { }

    }

}