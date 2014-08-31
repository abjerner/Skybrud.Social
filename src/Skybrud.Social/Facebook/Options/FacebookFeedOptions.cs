namespace Skybrud.Social.Facebook.Options {
    
    public class FacebookFeedOptions {

        /// <summary>
        /// The amount of entries per page.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Only entries after this timestamp will be fetched.
        /// </summary>
        public int Since { get; set; }

        /// <summary>
        /// Only entries before this timestamp will be fetched.
        /// </summary>
        public int Until { get; set; }

    }

}
