using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Exceptions {
    
    public class InstagramOAuthException : InstagramException {

        public InstagramOAuthException(SocialHttpResponse response, InstagramMetaData meta) : base(response, meta) { }

    }

}