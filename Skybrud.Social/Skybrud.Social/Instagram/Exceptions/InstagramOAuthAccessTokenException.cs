namespace Skybrud.Social.Instagram.Exceptions {
    
    public class InstagramOAuthAccessTokenException : InstagramException {
        
        public InstagramOAuthAccessTokenException(int code, string type, string message) : base(code, type, message) {
            // do nothing
        }

    }

}