using Skybrud.Social.Http;

namespace Skybrud.Social.Instagram.Exceptions {
    
    public class InstagramOAuthException : InstagramException {

        public InstagramOAuthException(SocialHttpResponse response, int code, string type, string message) : base(response, code, type, message) { }

    }

}