using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Exceptions {

    public class InstagramNotFoundException : InstagramException {

        internal InstagramNotFoundException(SocialHttpResponse response, InstagramMetaData meta) : base(response, meta) { }

    }

}