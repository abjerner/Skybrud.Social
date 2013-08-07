using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {
 
    public class FacebookDebugTokenResponse {

        public long AppId;
        public bool IsValid;

        public static FacebookDebugTokenResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        public static FacebookDebugTokenResponse Parse(JsonObject obj) {
            return new FacebookDebugTokenResponse {
                AppId = obj.GetLong("app_id"),
                IsValid = obj.GetBoolean("is_valid")
            };
        }

    }

}
