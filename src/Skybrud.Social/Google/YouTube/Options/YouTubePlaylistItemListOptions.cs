using System;
using Skybrud.Social.Google.YouTube.Objects.PlaylistItems;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Google.YouTube.Options {

    public class YouTubePlaylistItemListOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets which properties that should be returned.
        /// </summary>
        public YouTubePlaylistItemPartsCollection Part { get; set; }

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

        /// <summary>
        /// Gets or sets a playlist ID if only playlist items for a specific playlist should be returned.
        /// </summary>
        public string PlaylistId { get; set; }

        /// <summary>
        /// Gets or sets a video ID if only playlist items for the specific video should be returned.
        /// </summary>
        public string VideoId { get; set; }

        #endregion

        #region Constructors

        public YouTubePlaylistItemListOptions() {
            Part = YouTubePlaylistItemPart.Basic;
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString query = new SocialQueryString();
            if (Part != null) query.Add("part", Part.ToString());
            if (Ids != null && Ids.Length > 0) query.Add("id", String.Join(",", Ids));
            if (MaxResults > 0) query.Add("maxResults", MaxResults);
            if (!String.IsNullOrWhiteSpace(PageToken)) query.Add("pageToken", PageToken);
            if (!String.IsNullOrWhiteSpace(PlaylistId)) query.Add("playlistId", PlaylistId);
            if (!String.IsNullOrWhiteSpace(VideoId)) query.Add("videoId", VideoId);
            return query;
        }

        #endregion

    }

}