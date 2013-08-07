using System;
using System.Linq;
using Skybrud.Social.Instagram.Exceptions;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramMediaResponse : InstagramResponse {

        /// <summary>
        /// Gets an array of all media in the response.
        /// </summary>
        public InstagramMedia[] Data { get; private set; }

        /// <summary>
        /// Gets an array of all media in the response.
        /// </summary>
        public InstagramMedia[] Media {
            get { return Data; }
        }

        /// <summary>
        /// Gets an array of all images in the response.
        /// </summary>
        public InstagramImage[] Images {
            get { return Data.OfType<InstagramImage>().ToArray(); }
        }

        /// <summary>
        /// Gets an array of all videos in the response.
        /// </summary>
        public InstagramVideo[] Videos {
            get { return Data.OfType<InstagramVideo>().ToArray(); }
        }

        public string NextUrl { get; private set; }
        public string NextMaxId { get; private set; }

        public InstagramMediaResponse GetNextPage() {
            return NextUrl == null ? null : Parse(SocialUtils.DoHttpGetRequestAndGetBodyAsJsonObject(NextUrl));
        }

        public static InstagramMediaResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        public static InstagramMediaResponse Parse(JsonObject obj) {

            // Check if null
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(obj);

            // Get the "paging" object
            JsonObject pagination = obj.GetObject("pagination");

            // Parse the response
            return new InstagramMediaResponse {
                NextUrl = pagination == null ? null : pagination.GetString("next_url"),
                NextMaxId = pagination == null ? null : pagination.GetString("next_max_id"),
                Data = InstagramMedia.ParseMultiple(obj.GetArray("data"))
            };

        }

    }

}
