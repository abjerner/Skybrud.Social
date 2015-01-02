using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options {

    public class InstagramMediaSearchOptions : IGetOptions {
        
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

        public SocialQueryString GetQueryString() {
            SocialQueryString query = new SocialQueryString();
            if (Count > 0) query.Add("count", Count);
            if (MinId != null) query.Add("min_id", MinId);
            if (MaxId != null) query.Add("max_id", MaxId);
            return query;
        }
    
    }

}