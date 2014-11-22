namespace Skybrud.Social.Facebook.Options {
    
    /// <summary>
    /// Description from Facebook: Time pagination is used to navigate through results data using Unix timestamps which
    /// point to specific times in a list of data.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/using-graph-api/v2.2#time</cref>
    /// </see>
    public class FacebookTimeBasedPaginationOptions {

        /// <summary>
        /// Gets or sets the number of individual objects that are returned in each page.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the timestamp that points to the start of the range of time-based data.
        /// </summary>
        public int Since { get; set; }

        /// <summary>
        /// Gets or sets the timestamp that points to the end of the range of time-based data.
        /// </summary>
        public int Until { get; set; }

    }

}
