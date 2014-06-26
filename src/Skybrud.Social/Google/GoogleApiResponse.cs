using Skybrud.Social.Google.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google {
    
    public class GoogleApiResponse : GoogleApiResource {

        /// <summary>
        /// Validates the response and throws an exception if any API errors occur.
        /// </summary>
        /// <param name="obj">The object representing the response to validate.</param>
        public static void ValidateResponse(JsonObject obj) {
            if (!obj.HasValue("error")) return;
            JsonObject error = obj.GetObject("error");
            throw new GoogleApiException(error.GetInt("code"), error.GetString("message"));
        }

    }

}
