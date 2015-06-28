using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Twitter.Options.Lists {
    
    /// <summary>
    /// Options for a call to the Twitter API for getting the lists a given user is the member of.
    /// </summary>
    /// <see>
    ///     <cref>https://dev.twitter.com/rest/reference/get/lists/memberships</cref>
    /// </see>
    public class TwitterGetMembershipsOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the owning user.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the screen name of the owning user.
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of lists to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the cursor for the page to be returned.
        /// </summary>
        public long Cursor { get; set; }

        /// <summary>
        /// When set to <code>true</code>, will return just lists the authenticating user owns, and the user
        /// represented by user_id or screen_name is a member of.
        /// </summary>
        public bool FilterToOwnedLists { get; set; }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (UserId > 0) qs.Set("user_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) qs.Set("screen_name", ScreenName);
            if (Count > 0) qs.Set("count", Count);
            if (Cursor > 0) qs.Set("cursor", Cursor);
            if (FilterToOwnedLists) qs.Set("filter_to_owned_lists", "1");
            return qs;
        }

        #endregion

    }

}