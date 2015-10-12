using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Instagram API for a resource that couldn't be found.
    /// </summary>
    public class InstagramNotFoundException : InstagramException {

        internal InstagramNotFoundException(SocialHttpResponse response, InstagramMetaData meta) : base(response, meta) { }

    }

}