namespace Skybrud.Social.Google.YouTube.Objects.PlaylistItem {

    public class YouTubePlaylistItemOptions {

        /// <summary>
        /// The <var>id</var> parameter specifies a comma-separated list of one or more unique
        /// playlist item IDs.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The <var>maxResults</var> parameter specifies the maximum number of items that should
        /// be returned in the result set (integer, 0-50).
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The <var>pageToken</var> parameter identifies a specific page in the result set that
        /// should be returned. In an API response, the <var>nextPageToken</var> and
        /// <var>prevPageToken</var> properties identify other pages that could be retrieved.
        /// </summary>
        public string PageToken { get; set; }

        /// <summary>
        /// The <var>playlistId</var> parameter specifies the unique ID of the playlist for which
        /// you want to retrieve playlist items. Note that even though this is an optional
        /// parameter, every request to retrieve playlist items must specify a value for either the
        /// <var>id</var> parameter or the <var>playlistId</var> parameter.
        /// </summary>
        public string PlaylistId { get; set; }

        /// <summary>
        /// The <var>videoId</var> parameter specifies that the request should return only the
        /// playlist items that contain the specified video.
        /// </summary>
        public string VideoId { get; set; }
    
    }

}