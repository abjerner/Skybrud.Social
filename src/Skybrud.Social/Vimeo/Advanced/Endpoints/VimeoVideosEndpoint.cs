using System.Collections.Specialized;
using Skybrud.Social.Json;
using Skybrud.Social.Vimeo.Advanced.Responses;

namespace Skybrud.Social.Vimeo.Advanced.Endpoints {

    public class VimeoVideosEndpoint {

        public VimeoService Service { get; private set; }

        internal VimeoVideosEndpoint(VimeoService service) {
            Service = service;
        }

        /// <summary>
        /// API description: Get information on a video.
        /// </summary>
        /// <param name="videoId">The ID of the video.</param>
        /// <see cref="https://developer.vimeo.com/apis/advanced/methods/vimeo.videos.getInfo"/>
        public VimeoVideoResponse GetInfo(int videoId) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.videos.getInfo"},
                {"video_id", videoId + "" }
            };

            // Call the Vimeo API
            string response = Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

            // TODO: Validate the server response
            JsonObject json = JsonConverter.ParseObject(response);

            // Return the response object
            return VimeoVideoResponse.Parse(json);

        }

    }

}