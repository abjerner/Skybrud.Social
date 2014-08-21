namespace Skybrud.Social.Twitter.Options {

    public class TwitterUsersSearchOptions {

        #region Properties

        /// <summary>
        /// Specifies the page of results to retrieve.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The number of potential user results to retrieve per page. This
        /// value has a maximum of 20.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The entities node will be disincluded from embedded tweet objects
        /// when set to <code>false</code>.
        /// </summary>
        public bool IncludeEntities { get; set; }

        #endregion

        #region Constructor

        public TwitterUsersSearchOptions() {
            Page = 1;
            Count = 20;
            IncludeEntities = true;
        }

        #endregion

    }

}
