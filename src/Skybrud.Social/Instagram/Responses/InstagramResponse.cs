using System;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramResponse {

        /// <summary>
        /// Gets a reference to the underlying response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        protected InstagramResponse(SocialHttpResponse response) {
            Response = response;
        }

    }

    public class InstagramResponse<T> : InstagramResponse {

        public InstagramResponseBody<T> Body { get; private set; }

        protected InstagramResponse(SocialHttpResponse response) : base(response) { }

        #region Static methods

        public static InstagramResponse<T> ParseResponse(SocialHttpResponse response, Func<JsonObject, T> func) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) {
                // TODO: Use an exception type specific to Instagram
                throw new Exception("Invalid response received from the Instagram API");
            }

            // Get the "meta" object
            JsonObject meta = obj.GetObject("meta");

            // In special cases the root object is meta ()
            if (meta == null && obj.HasValue("code")) {
                meta = obj;
            }

            // Check for any errors
            if (meta != null && meta.HasValue("code")) {

                // Get some values from the "meta" object
                int code = meta.GetInt32("code");
                string type = meta.GetString("error_type");
                string message = meta.GetString("error_message");

                // If "code" is 200, everything went fine :D
                if (code != 200) {

                    // Now throw some exceptions
                    if (type == "OAuthException") throw new InstagramOAuthException(code, type, message);
                    if (type == "OAuthAccessTokenException") throw new InstagramOAuthAccessTokenException(code, type, message);
                    if (type == "APINotFoundError") throw new InstagramNotFoundException(code, type, message);

                    throw new InstagramException(code, type, message);

                }

            }
            
            // Initialize the response object
            return new InstagramResponse<T>(response) {
                Body = new InstagramResponseBody<T> {
                    Data = obj.GetObject("data", func)
                }
            };

        }

        #endregion

    }

    public class InstagramResponseBody<T> {

        public object Meta { get; set; }
        
        public T Data { get; set; } 

    }

}
