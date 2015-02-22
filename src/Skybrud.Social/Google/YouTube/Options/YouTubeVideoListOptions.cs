using System;
using Skybrud.Social.Google.YouTube.Objects.Videos;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Google.YouTube.Options {

    public class YouTubeVideoListOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets which properties that should be returned.
        /// </summary>
        public YouTubeVideoPartsCollection Part { get; set; }

        /// <summary>
        /// Gets or sets a list of IDs for the playlist items to be returned.
        /// </summary>
        public string[] Ids { get; set; }

        /// <summary>
        /// The <var>maxResults</var> parameter specifies the maximum number of items that should
        /// be returned in the result set (integer, 0-50).
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// Gets or sets the page token.
        /// </summary>
        public string PageToken { get; set; }

        #endregion

        #region Constructors

        public YouTubeVideoListOptions() {
            Part = YouTubeVideoPart.Basic;
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString query = new SocialQueryString();
            if (Part != null) query.Add("part", Part.ToString());
            if (Ids != null && Ids.Length > 0) query.Add("id", String.Join(",", Ids));
            if (MaxResults > 0) query.Add("maxResults", MaxResults);
            if (!String.IsNullOrWhiteSpace(PageToken)) query.Add("pageToken", PageToken);
            return query;
        }

        #endregion

    }

}