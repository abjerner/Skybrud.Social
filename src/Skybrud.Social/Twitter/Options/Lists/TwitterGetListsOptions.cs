using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Twitter.Options.Lists {

    /// <summary>
    /// Options for a call to the Twitter API for getting a list of lists.
    /// </summary>
    public class TwitterGetListsOptions : IGetOptions {

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
        /// Gets or sets whether the list of lists should be returned in reverse order.
        /// </summary>
        public bool Reverse { get; set; }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (UserId > 0) qs.Set("user_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) qs.Set("screen_name", ScreenName);
            if (Reverse) qs.Set("reverse", "1");
            return qs;
        }

        #endregion

    }

}