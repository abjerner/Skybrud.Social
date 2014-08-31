using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {
    
    public class FacebookPhotosResponse {

        public FacebookPhoto[] Data {
            get; private set;
        }

        public FacebookPaging Paging {
            get; private set;
        }

        public static FacebookPhotosResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        public static FacebookPhotosResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookException.Parse);
            return new FacebookPhotosResponse {
                Data = FacebookPhoto.ParseMultiple(obj.GetArray("data")),
                Paging = FacebookPaging.Parse(obj.GetObject("paging"))
            };
        
        }

        public FacebookPhotosResponse Next(FacebookService service) {
            return Paging.Next == null ? null : Parse(SocialUtils.DoHttpGetRequestAndGetBodyAsJsonObject(Paging.Next + "&access_token=" + service.AccessToken));
        }
    
    }

}