namespace Skybrud.Social.Instagram.Options {

    /// <summary>
    /// Class representing the search options for a known location.
    /// </summary>
    public class InstagramLocationSearchOptions {

        /// <summary>
        /// If specified, only media uploaded after this UNIX timestamp will be returned. The
        /// timestamp is inclusive - meaning that media with the specified timestamp may be part of
        /// the response.
        /// </summary>
        public long MinTimestamp { get; set; }

        /// <summary>
        /// If specified, only media uploaded before this UNIX timestamp will be returned. The
        /// timestamp is exclusive - meaning that media with the specified timestamp will not be
        /// part of the response.
        /// </summary>
        public long MaxTimestamp { get; set; }

        /// <summary>
        /// If specified, only media uploaded after this ID will be returned. The media with the
        /// specified ID may also be a part of the response.
        /// </summary>
        public string MinId { get; set; }

        /// <summary>
        /// If specified, only media uploaded before this ID will be returned. The media with the
        /// specified ID will not be a part of the response.
        /// </summary>
        public string MaxId { get; set; }
    
    }

}