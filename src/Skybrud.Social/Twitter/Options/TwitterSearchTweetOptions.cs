using System;
using Skybrud.Social.Http;
using Skybrud.Social.Twitter.Enums;

namespace Skybrud.Social.Twitter.Options {
    
    public class TwitterSearchTweetOptions {

        #region Properties

        /// <summary>
        /// The search query of 500 characters maximum, including operators. Queries may additionally be limited by
        /// complexity.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Optional. Specifies what type of search results you would prefer to receive. The current default is
        /// <code>mixed</code>.
        /// </summary>
        public TwitterSearchTweetResultType ResultType { get; set; }

        /// <summary>
        /// The number of tweets to return per page, up to a maximum of <code>100</code>. Defaults to <code>15</code>. 
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Returns tweets generated before the given date. Keep in mind that the search index may not go back as far
        /// as the date you specify here.
        /// </summary>
        public DateTime? Until { get; set; }

        /// <summary>
        /// Returns results with an ID greater than (that is, more recent than) the specified ID. There are limits to
        /// the number of Tweets which can be accessed through the API. If the limit of Tweets has occured since the
        /// <code>since_id</code>, the <code>since_id</code> will be forced to the oldest ID available.
        /// </summary>
        public long SinceId { get; set; }

        /// <summary>
        /// Returns results with an ID less than (that is, older than) or equal to the specified ID.
        /// </summary>
        public long MaxId { get; set; }

        /// <summary>
        /// The <code>entities</code> node will be disincluded when set to <code>false</code>.
        /// </summary>
        public bool IncludeEntities { get; set; }

        #endregion

        #region Constructor

        public TwitterSearchTweetOptions() {
            Count = 0;
            IncludeEntities = true;
        }

        #endregion

        #region Methods

        public SocialQueryString GetQuery() {

            string resultType = ResultType.ToString().ToLower();
            
            SocialQueryString query = new SocialQueryString();
            if (!String.IsNullOrWhiteSpace(Query)) query.Set("q", Query);
            if (resultType != "mixed") query.Set("result_type", resultType);
            if (Count > 0) query.Set("count", Count);
            if (Until != null) query.Set("until", Until.Value.ToString("yyyy-MM-dd"));
            if (SinceId > 0) query.Set("since_id", SinceId);
            if (MaxId > 0) query.Set("max_id", MaxId);
            if (!IncludeEntities) query.Set("include_entities", "false");
            return query;
        
        }

        #endregion

    }

}
