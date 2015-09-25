using System;
using Skybrud.Social.Facebook.Options.Pagination;

namespace Skybrud.Social.Facebook.Options.Feed {

    /// <summary>
    /// Class representing the options for a call to the Facebook Graph API to get a list of items from a feed.
    /// </summary>
    [Obsolete("Use the FacebookGetFeedOptions instead.")]
    public class FacebookFeedOptions : FacebookTimeBasedPaginationOptions { }

}