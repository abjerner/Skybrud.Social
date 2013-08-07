namespace Skybrud.Social.Instagram.Exceptions {

    public class InstagramNotFoundException : InstagramException {

        internal InstagramNotFoundException(int code, string type, string message) : base(code, type, message) {
            // do nothing
        }

    }

}
