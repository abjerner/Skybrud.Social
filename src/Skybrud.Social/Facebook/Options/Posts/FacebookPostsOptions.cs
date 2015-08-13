using System;
using Skybrud.Social.Facebook.Options.Pagination;

namespace Skybrud.Social.Facebook.Options.Posts {

    /// <summary>
    /// Class representing the options for a call to the Facebook Graph API to get a list of posts.
    /// </summary>
    [Obsolete("Use the FacebookGetPostsOptions instead.")]
    public class FacebookPostsOptions : FacebookTimeBasedPaginationOptions { }

}
