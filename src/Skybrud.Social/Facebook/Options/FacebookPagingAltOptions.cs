namespace Skybrud.Social.Facebook.Options {
    
    public class FacebookPagingAltOptions {

        /// <summary>
        /// The amount of entries per page.
        /// </summary>
        public int Limit { get; set; }

        public string Before { get; set; }

        public string After { get; set; }
    
    }

}
