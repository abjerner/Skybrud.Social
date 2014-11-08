using Skybrud.Social.Json;
using Skybrud.Social.Vimeo.Advanced.Objects;

namespace Skybrud.Social.Vimeo.Advanced.Responses {
    
    public class VimeoVideosResponse : VimeoApiResponse {
        
        public int OnThisPage { get; private set; }
        public int Page { get; private set; }
        public int PerPage { get; private set; }
        public int Total { get; private set; }
        public VimeoVideo[] Videos { get; private set; }

        public static VimeoVideosResponse Parse(JsonObject obj) {

            // Check if NULL
            if (obj == null) return null;

            // Initialize the response object (and some basic parsing)
            VimeoVideosResponse response = new VimeoVideosResponse();
            response.ParseResponse(obj);

            // Get the "videos" object
            JsonObject videos = obj.GetObject("videos");
            if (videos == null) return null;

            // More parsing
            response.OnThisPage = videos.GetInt32("on_this_page");
            response.Page = videos.GetInt32("page");
            response.PerPage = videos.GetInt32("perpage");
            response.Total = videos.GetInt32("total");
            response.Videos = ParseVideos(videos);

            // Return the response object
            return response;
        
        }
        
        private static VimeoVideo[] ParseVideos(JsonObject obj) {
            if (obj.IsArray("video")) return obj.GetArray("video", VimeoVideo.Parse);
            if (obj.IsObject("video")) return new[] { obj.GetObject("video", VimeoVideo.Parse) };
            return new VimeoVideo[0];
        }

    }

}