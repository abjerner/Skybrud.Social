using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options {

    /// <summary>
    /// Class representing the search options for getting a list of recent media.
    /// </summary>
    public class InstagramMediaSearchOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Count of media to return.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Return media later than this <code>min_id</code>.
        /// </summary>
        public string MinId { get; set; }

        /// <summary>
        /// Return media earlier than this <code>max_id</code>.
        /// </summary>
        public string MaxId { get; set; }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <code>SocialQueryString</code> representing the GET parameters.
        /// </summary>
        public SocialQueryString GetQueryString() {
            SocialQueryString query = new SocialQueryString();
            if (Count > 0) query.Add("count", Count);
            if (MinId != null) query.Add("min_id", MinId);
            if (MaxId != null) query.Add("max_id", MaxId);
            return query;
        }

        #endregion

    }

}