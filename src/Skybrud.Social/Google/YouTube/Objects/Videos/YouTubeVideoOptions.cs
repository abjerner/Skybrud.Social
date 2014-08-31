namespace Skybrud.Social.Google.YouTube.Objects.Videos {
    
    public class YouTubeVideoOptions {

        /// <summary>
        /// Gets or sets list of the YouTube video ID(s) for the resource(s) that should be
        /// retrieved. In a <var>video</var> resource, the <var>id</var> property specifies the
        /// video's ID.
        /// </summary>
        public string[] Ids { get; set; }

        /// <summary>
        /// The <var>maxResults</var> parameter specifies the maximum number of items that should
        /// be returned in the result set.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The <var>pageToken</var> parameter identifies a specific page in the result set that
        /// should be returned. In an API response, the <var>nextPageToken</var> and
        /// <var>prevPageToken</var> properties identify other pages that could be retrieved.
        /// </summary>
        public string PageToken { get; set; }

    }

}
