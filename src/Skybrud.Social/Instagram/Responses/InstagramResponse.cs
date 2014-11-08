using System;
using Skybrud.Social.Instagram.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public abstract class InstagramResponse : SocialJsonObject {

        #region Constructors

        protected InstagramResponse(JsonObject obj) : base(obj) {}

        #endregion

        #region Static methods

        public static void ValidateResponse(JsonObject obj) {

            // Check whether "obj" is null
            if (obj == null) throw new ArgumentNullException("obj");

            // Get the "meta" object
            JsonObject meta = obj.GetObject("meta");

            // In special cases the root object is meta ()
            if (meta == null && obj.HasValue("code")) {
                meta = obj;
            }

            // In some special cases like during the OAuth authentication, the
            // root object is actually the "meta" object if any errors occur
            if (meta == null) {

                // Get some values from the "obj" object
                int code = obj.GetInt32("code");
                string type = obj.GetString("error_type");
                string message = obj.GetString("error_message");

                if (obj.HasValue("code")) {
                    if (type == "OAuthException") throw new InstagramOAuthException(code, type, message);
                    throw new InstagramException(code, type, message);
                }

                // Should be OK by now
                return;

            }
            
            // Most responses will have a meta object along with a response code
            if (meta.HasValue("code")) {

                // Get some values from the "meta" object
                int code = meta.GetInt32("code");
                string type = meta.GetString("error_type");
                string message = meta.GetString("error_message");

                // If "code" is 200, everything went fine :D
                if (code == 200) return;

                // Now throw some exceptions
                if (type == "OAuthException") throw new InstagramOAuthException(code, type, message);
                if (type == "OAuthAccessTokenException") throw new InstagramOAuthAccessTokenException(code, type, message);
                if (type == "APINotFoundError") throw new InstagramNotFoundException(code, type, message);

                throw new InstagramException(code, type, message);

            }

            throw new Exception("Invalid response received from server");

        }

        #endregion

    }

}
