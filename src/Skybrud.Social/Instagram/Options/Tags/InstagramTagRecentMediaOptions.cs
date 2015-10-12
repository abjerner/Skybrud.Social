using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options.Tags {
    
    /// <summary>
    /// Class representing the options for getting a list of recent media of a given tag.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_media_recent</cref>
    /// </see>
    public class InstagramTagRecentMediaOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of media to return.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the minimum tag ID. Only media before this ID will be returned.
        /// </summary>
        public string MinTagId { get; set; }

        /// <summary>
        /// Gets or sets the maximum tag ID. Only media after this ID will be returned.
        /// </summary>
        public string MaxTagId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an instance with default options.
        /// </summary>
        public InstagramTagRecentMediaOptions() { }

        /// <summary>
        /// Initializes an instance with the specified <code>count</code>.
        /// </summary>
        /// <param name="count">The maximum amount of users to be returned.</param>
        public InstagramTagRecentMediaOptions(int count) {
            Count = count;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>minTagId</code> and <code>maxTagId</code>.
        /// </summary>
        /// <param name="minTagId">The minimum tag ID. Only media before this ID will be returned.</param>
        /// <param name="maxTagId">The maximum tag ID. Only media after this ID will be returned.</param>
        public InstagramTagRecentMediaOptions(string minTagId, string maxTagId) {
            MinTagId = minTagId;
            MaxTagId = maxTagId;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>minTagId</code> and <code>maxTagId</code>.
        /// </summary>
        /// <param name="count">The maximum amount of users to be returned.</param>
        /// <param name="minTagId">The minimum tag ID. Only media before this ID will be returned.</param>
        /// <param name="maxTagId">The maximum tag ID. Only media after this ID will be returned.</param>
        public InstagramTagRecentMediaOptions(int count, string minTagId, string maxTagId) {
            Count = count;
            MinTagId = minTagId;
            MaxTagId = maxTagId;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <code>SocialQueryString</code> representing the GET parameters.
        /// </summary>
        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (Count > 0) qs.Add("count", Count);
            if (!String.IsNullOrWhiteSpace(MinTagId)) qs.Add("min_tag_id", MinTagId);
            if (!String.IsNullOrWhiteSpace(MaxTagId)) qs.Add("max_tag_id", MaxTagId);
            return qs;
        }

        #endregion

    }

}