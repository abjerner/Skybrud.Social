using Skybrud.Social.Http;

namespace Skybrud.Social.Instagram.Exceptions {

    public class InstagramOAuthAccessTokenException : InstagramOAuthException {

        public InstagramOAuthAccessTokenException(SocialHttpResponse response, int code, string type, string message) : base(response, code, type, message) { }

    }

}