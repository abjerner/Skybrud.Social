using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options.Common {

    /// <summary>
    /// Class representing the options for getting a list of recent media.
    /// </summary>
    /// <see>
    ///     <cref>http://instagram.com/developer/endpoints/users/#get_users_media_recent</cref>
    ///     <cref>http://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
    /// </see>
    public class InstagramRecentMediaOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of media to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Only media before this timestamp is returned.
        /// </summary>
        // TODO: Not sure whether this is inclusive or exclusive.
        public DateTime? MaxTimestamp { get; set; }

        /// <summary>
        /// Only media after this timestamp is returned.
        /// </summary>
        // TODO: Not sure whether this is inclusive or exclusive.
        public DateTime? MinTimestamp { get; set; }

        /// <summary>
        /// Only media after this ID is returned.
        /// </summary>
        // TODO: Not sure whether this is inclusive or exclusive.
        public string MinId { get; set; }

        /// <summary>
        /// Only media before this ID is returned.
        /// </summary>
        // TODO: Not sure whether this is inclusive or exclusive.
        public string MaxId { get; set; }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <code>SocialQueryString</code> representing the GET parameters.
        /// </summary>
        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (Count > 0) qs.Add("count", Count);
            if (MaxTimestamp != null) qs.Add("max_timestamp", SocialUtils.GetUnixTimeFromDateTime(MaxTimestamp.Value));
            if (MinTimestamp != null) qs.Add("min_timestamp", SocialUtils.GetUnixTimeFromDateTime(MinTimestamp.Value));
            if (MinId != null) qs.Add("min_id", MinId);
            if (MaxId != null) qs.Add("max_id", MaxId);
            return qs;
        }

        #endregion

    }

}