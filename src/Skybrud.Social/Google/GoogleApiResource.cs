using Skybrud.Social.Json;

namespace Skybrud.Social.Google {
    
    public class GoogleApiResource : GoogleApiObject {

        public string Kind { get; private set; }
        public string ETag { get; private set; }

        protected GoogleApiResource(JsonObject obj) : base(obj) {
            Kind = obj.GetString("kind");
            ETag = obj.GetString("etag");
        }

    }

}
