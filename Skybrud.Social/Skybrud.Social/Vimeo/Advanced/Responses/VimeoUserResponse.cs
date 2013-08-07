using Skybrud.Social.Json;
using Skybrud.Social.Vimeo.Advanced.Objects;

namespace Skybrud.Social.Vimeo.Advanced.Responses {

    public class VimeoUserResponse : VimeoApiResponse {

        public VimeoUser Person { get; private set; }

        public static VimeoUserResponse Parse(JsonObject obj) {

            // Check if NULL
            if (obj == null) return null;

            // Initialize the response object (and some basic parsing)
            VimeoUserResponse response = new VimeoUserResponse();
            response.ParseResponse(obj);

            // Get the "videos" object
            JsonObject videos = obj.GetObject("videos");
            if (videos == null) return null;

            // More parsing
            response.Person = obj.GetObject("person", VimeoUser.Parse);

            // Return the response object
            return response;

        }

    }

}