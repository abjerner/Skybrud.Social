using System.Linq;
using Skybrud.Social.Json;
using Skybrud.Social.Vimeo.Advanced.Objects;

namespace Skybrud.Social.Vimeo.Advanced.Responses {
    
    public class VimeoVideoResponse : VimeoApiResponse {

        public VimeoVideo Video { get; private set; }

        public static VimeoVideoResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            VimeoVideoResponse response = new VimeoVideoResponse();
            response.ParseResponse(obj);
            response.Video = obj.GetArray("video", VimeoVideo.Parse).FirstOrDefault();
            return response;
        }

    }

}