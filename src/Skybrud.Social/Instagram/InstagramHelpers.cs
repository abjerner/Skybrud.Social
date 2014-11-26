using System;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Responses;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram {

    public static class InstagramHelpers {

        /// <summary>
        /// Helper method for parsing an API response. The type of T doesn't have to be specified
        /// explicitly, making this method simpler to use.
        /// </summary>
        /// <typeparam name="T">The type of the object the response should wrap.</typeparam>
        /// <param name="response">The response received from the API.</param>
        /// <param name="func">The delegate used for parsing the response body.</param>
        public static InstagramResponse<T> ParseResponse<T>(SocialHttpResponse response, Func<JsonObject, T> func) {
            return InstagramResponse<T>.ParseResponse(response, func);
        }

    }

}
