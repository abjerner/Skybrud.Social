using System;
using Skybrud.Social.Google.YouTube.Objects.Channels;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Google.YouTube.Options {
    
    public class YouTubeChannelsOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets which properties that should be returned.
        /// </summary>
        public YouTubeChannelPartsCollection Part { get; set; }

        /// <summary>
        /// Gets or sets whether only channel(s) with this username should be returned.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount if items to return on each page.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// Gets or sets whether only channels by the authenticated user should be returned.
        /// </summary>
        public bool Mine { get; set; }

        /// <summary>
        /// Gets or sets the page token.
        /// </summary>
        public string PageToken { get; set; }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString query = new SocialQueryString();
            if (Part != null) query.Add("part", Part.ToString());
            if (!String.IsNullOrWhiteSpace(Username)) query.Add("forUsername", Username);
            if (MaxResults > 0) query.Add("maxResults", MaxResults);
            if (Mine) query.Add("mine", "true");
            if (!String.IsNullOrWhiteSpace(PageToken)) query.Add("pageToken", PageToken);
            return query;
        }

        #endregion

    }

}