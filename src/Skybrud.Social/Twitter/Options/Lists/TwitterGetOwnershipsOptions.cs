using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Twitter.Options.Lists {

    /// <summary>
    /// Options for a call to the Twitter API for getting the list owned by a given user.
    /// </summary>
    public class TwitterGetOwnershipsOptions : IGetOptions {

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

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (UserId > 0) qs.Set("user_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) qs.Set("screen_name", ScreenName);
            if (Count > 0) qs.Set("count", Count);
            if (Cursor > 0) qs.Set("cursor", Cursor);
            return qs;
        }

        #endregion

    }

}