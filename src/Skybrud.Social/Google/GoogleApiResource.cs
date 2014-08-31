using Skybrud.Social.Json;

namespace Skybrud.Social.Google {
    
    public class GoogleApiResource : GoogleApiObject {

        public string Kind { get; protected set; }
        public string ETag { get; protected set; }

        protected GoogleApiResource(JsonObject obj) : base(obj) {}

    }

}