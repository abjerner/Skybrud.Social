namespace Skybrud.Social.Instagram.Options {

    public class InstagramMediaSearchOptions {
        
        /// <summary>
        /// Count of media to return.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Return media later than this <var>min_id</var>.
        /// </summary>
        public string MinId { get; set; }

        /// <summary>
        /// Return media earlier than this <var>max_id</var>.
        /// </summary>
        public string MaxId { get; set; }
    
    }

}