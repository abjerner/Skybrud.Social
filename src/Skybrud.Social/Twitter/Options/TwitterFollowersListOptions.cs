using System.Collections.Specialized;
using System.Globalization;

namespace Skybrud.Social.Twitter.Options {

    public class TwitterFollowersListOptions {

        #region Constants

        public const int DefaultCursor = -1;
        public const int DefaultCount = 20;
        public const bool DefaultSkipStatus = false;
        public const bool DefaultIncludeUserEntities = true;

        #endregion

        #region Properties

        /// <summary>
        /// Causes the results to be broken into pages. If no cursor is
        /// provided, a value of <code>-1</code> will be assumed, which is the
        /// first "page".
        /// 
        /// The response from the API will include a <code>previous_cursor</code>
        /// and <code>next_cursor</code> to allow paging back and forth.
        /// </summary>
        public long Cursor { get; set; }

        /// <summary>
        /// The number of users to return per page, up to a maximum of 200.
        /// Defaults to 20.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// When set to <em>true</em> statuses will not be included in the
        /// returned user objects.
        /// </summary>
        public bool SkipStatus { get; set; }

        /// <summary>
        /// The user object entities node will be disincluded when set to
        /// <code>false</code>.
        /// </summary>
        public bool IncludeUserEntities { get; set; }
        
        #endregion

        #region Constructors

        public TwitterFollowersListOptions() {
            Cursor = DefaultCursor;
            Count = DefaultCount;
            SkipStatus = DefaultSkipStatus;
            IncludeUserEntities = DefaultIncludeUserEntities;
        }

        #endregion

        #region Methods

        public void UpdateNameValueCollection(NameValueCollection nvc) {

            if (Cursor != DefaultCursor) {
                nvc.Add("cursor", Cursor.ToString(CultureInfo.InvariantCulture));
            }

            if (Count != DefaultCount) {
                nvc.Add("count", Count.ToString(CultureInfo.InvariantCulture));
            }

            if (SkipStatus != DefaultSkipStatus) {
                nvc.Add("skip_status", SkipStatus ? "1" : "0");
            }

            if (IncludeUserEntities != DefaultIncludeUserEntities) {
                nvc.Add("include_user_entities", IncludeUserEntities ? "1" : "0");
            }
            
        }

        #endregion

    }

}
