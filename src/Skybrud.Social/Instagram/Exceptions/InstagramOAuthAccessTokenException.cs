using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Exceptions {

    public class InstagramOAuthAccessTokenException : InstagramOAuthException {

        public InstagramOAuthAccessTokenException(SocialHttpResponse response, InstagramMetaData meta) : base(response, meta) { }

    }

}