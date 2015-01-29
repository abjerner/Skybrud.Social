using Skybrud.Social.Http;

namespace Skybrud.Social.Instagram.Exceptions {

    public class InstagramNotFoundException : InstagramException {

        internal InstagramNotFoundException(SocialHttpResponse response, int code, string type, string message) : base(response, code, type, message) { }

    }

}