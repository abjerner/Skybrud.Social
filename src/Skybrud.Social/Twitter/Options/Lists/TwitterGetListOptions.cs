using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Twitter.Options.Lists {

    /// <summary>
    /// Options for a call to the Twitter API for getting a information about a list.
    /// </summary>
    public class TwitterGetListOptions : IGetOptions {

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

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (Id > 0) qs.Set("list_id", UserId);
            if (!String.IsNullOrWhiteSpace(Slug)) qs.Set("slug", Slug);
            if (UserId > 0) qs.Set("owner_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) qs.Set("owner_screen_name", ScreenName);
            return qs;
        }

        #endregion

    }

}