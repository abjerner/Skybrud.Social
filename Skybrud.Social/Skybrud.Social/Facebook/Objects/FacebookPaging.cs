using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookPaging {
    
        public string After;
        public string Before;
        public string Previous;
        public string Next;

        public static FacebookPaging Parse(JsonObject obj) {
            FacebookPaging paging = new FacebookPaging();
            if (obj != null) {
                paging.Previous = obj.GetString("previous");
                paging.Next = obj.GetString("next");
            }
            return paging;
        }

    }

}