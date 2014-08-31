using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {
    
    public class FacebookPhotosResponse : SocialJsonObject {

        public FacebookPhoto[] Data {
            get; private set;
        }

        public FacebookPaging Paging {
            get; private set;
        }
        
        #region Constructors

        private FacebookPhotosResponse(JsonObject obj) : base(obj) { }

        #endregion

        public static FacebookPhotosResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        public static FacebookPhotosResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookException.Parse);
            return new FacebookPhotosResponse(obj) {
                Data = obj.GetArray("data", FacebookPhoto.Parse),
                Paging = FacebookPaging.Parse(obj.GetObject("paging"))
            };
        }

        public FacebookPhotosResponse Next(FacebookService service) {
            return Paging.Next == null ? null : Parse(SocialUtils.DoHttpGetRequestAndGetBodyAsJsonObject(Paging.Next + "&access_token=" + service.Client.AccessToken));
        }
    
    }

}