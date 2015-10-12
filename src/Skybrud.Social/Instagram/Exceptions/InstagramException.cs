using System;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Common;

namespace Skybrud.Social.Instagram.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Instagram API.
    /// </summary>
    public class InstagramException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <code>SocialHttpResponse</code>.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets information about rate limiting.
        /// </summary>
        public InstagramRateLimiting RateLimiting { get; private set; }

        /// <summary>
        /// Gets the meta data of the response.
        /// </summary>
        public InstagramMetaData Meta { get; private set; }

        #endregion

        #region Constructors

        internal InstagramException(SocialHttpResponse response, InstagramMetaData meta) : base(meta.ErrorMessage) {
            Response = response;
            RateLimiting = InstagramRateLimiting.GetFromResponse(response);
            Meta = meta;
        }

        #endregion

    }

}