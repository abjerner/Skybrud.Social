namespace Skybrud.Social.Facebook.Options {
    
    /// <summary>
    /// Class with options for cursor-based pagination.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/using-graph-api/v2.2#cursors</cref>
    /// </see>
    public class FacebookCursorBasedPaginationOptions {

        /// <summary>
        /// Gets or sets the number of individual objects that are returned in each page.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the cursor that points to the start of the page of data that has been returned.
        /// </summary>
        public string Before { get; set; }

        /// <summary>
        /// Gets or sets the cursor that points to the end of the page of data that has been returned.
        /// </summary>
        public string After { get; set; }
    
    }

}
