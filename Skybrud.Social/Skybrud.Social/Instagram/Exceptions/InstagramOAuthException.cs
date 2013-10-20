namespace Skybrud.Social.Instagram.Exceptions {
    
    public class InstagramOAuthException : InstagramException {
        
        public InstagramOAuthException(int code, string type, string message) : base(code, type, message) {
            // do nothing
        }

    }

}