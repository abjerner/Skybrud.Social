using System;
using Skybrud.Social.Instagram.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {
    
    public abstract class InstagramResponse {

        public static void ValidateResponse(JsonObject obj) {

            // Check whether "obj" is null
            if (obj == null) throw new ArgumentNullException("obj");

            // Get the "meta" object
            JsonObject meta = obj.GetObject("meta");

            // There should always be an "meta" object
            if (meta == null) throw new Exception("Invalid response received from server");

            // Get some values from the "meta" object
            int code = meta.GetInt("code");
            string type = meta.GetString("error_type");
            string message = meta.GetString("error_message");

            // If "code" is 200, everything went fine :D
            if (code == 200) return;

            // Now throw some exceptions
            if (type == "OAuthAccessTokenException") throw new InstagramOAuthAccessTokenException(code, type, message);
            if (type == "APINotFoundError") throw new InstagramNotFoundException(code, type, message);
            throw new InstagramException(code, type, message);

        }
    
    }

}
