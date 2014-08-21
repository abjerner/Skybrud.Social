namespace Skybrud.Social.Instagram.Exceptions {

    public class InstagramOAuthAccessTokenException : InstagramOAuthException {
        
        public InstagramOAuthAccessTokenException(int code, string type, string message) : base(code, type, message) {
            // do nothing
        }

    }

}