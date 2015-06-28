using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Twitter.Options.Lists {
    
    /// <summary>
    /// Options for a call to the Twitter API for getting the members of a given list.
    /// </summary>
    /// <see>
    ///     <cref>https://dev.twitter.com/rest/reference/get/lists/members</cref>
    /// </see>
    public class TwitterGetMembersOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the list.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the slug of the list.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets the ID of the owning user.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the screen name of the owning user.
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of members to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the cursor for the page to be returned.
        /// </summary>
        public long Cursor { get; set; }

        /// <summary>
        /// The <code>entities</code> node will be disincluded when set to <code>false</code>.
        /// </summary>
        public bool IncludeEntities { get; set; }

        /// <summary>
        /// When set to <code>true</code> statuses will not be included in the returned user objects.
        /// </summary>
        public bool SkipStatus { get; set; }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (Id > 0) qs.Set("list_id", UserId);
            if (!String.IsNullOrWhiteSpace(Slug)) qs.Set("slug", Slug);
            if (UserId > 0) qs.Set("owner_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) qs.Set("owner_screen_name", ScreenName);
            if (Count > 0) qs.Set("count", Count);
            if (Cursor > 0) qs.Set("cursor", Cursor);
            if (!IncludeEntities) qs.Set("include_entities", "0");
            if (SkipStatus) qs.Set("skip_status", "1");
            return qs;
        }

        #endregion

    }

}