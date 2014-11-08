using Skybrud.Social.Json;
using Skybrud.Social.Vimeo.Advanced.Objects;

namespace Skybrud.Social.Vimeo.Advanced.Responses {
    
    public class VimeoChannelsResponse : VimeoApiResponse {

        public int OnThisPage { get; private set; }
        public int Page { get; private set; }
        public int PerPage { get; private set; }
        public int Total { get; private set; }
        public VimeoChannel[] Channels { get; private set; }

        public static VimeoChannelsResponse Parse(JsonObject obj) {

            // Check if NULL
            if (obj == null) return null;

            // Initialize the response object (and some basic parsing)
            VimeoChannelsResponse response = new VimeoChannelsResponse();
            response.ParseResponse(obj);

            // Get the "channels" object
            JsonObject channels = obj.GetObject("channels");
            if (channels == null) return null;

            // More parsing
            response.OnThisPage = channels.GetInt32("on_this_page");
            response.Page = channels.GetInt32("page");
            response.PerPage = channels.GetInt32("perpage");
            response.Total = channels.GetInt32("total");
            response.Channels = ParseChannels(channels);

            // Return the response object
            return response;

        }

        private static VimeoChannel[] ParseChannels(JsonObject obj) {
            if (obj.IsArray("channel")) return obj.GetArray("channel", VimeoChannel.Parse);
            if (obj.IsObject("channel")) return new[] { obj.GetObject("channel", VimeoChannel.Parse) };
            return new VimeoChannel[0];
        }

    }
}
