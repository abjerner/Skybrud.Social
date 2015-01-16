using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options.Tags {
    
    public class InstagramTagRecentMediaOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of media to return.
        /// </summary>
        public int Count { get; set; }

        public string MinTagId { get; set; }

        public string MaxTagId { get; set; }

        #endregion

        #region Constructors

        public InstagramTagRecentMediaOptions() { }

        public InstagramTagRecentMediaOptions(int count) {
            Count = count;
        }

        public InstagramTagRecentMediaOptions(string minTagId, string maxTagId) {
            MinTagId = minTagId;
            MaxTagId = maxTagId;
        }

        public InstagramTagRecentMediaOptions(int count, string minTagId, string maxTagId) {
            Count = count;
            MinTagId = minTagId;
            MaxTagId = maxTagId;
        }

        #endregion

        #region Member methods

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