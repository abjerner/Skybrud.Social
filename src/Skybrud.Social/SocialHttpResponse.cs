using System.IO;
using System.Net;
using Skybrud.Social.Json;

namespace Skybrud.Social {
    
    public class SocialHttpResponse {

        public HttpWebResponse Response { get; private set; }
        public WebException Exception { get; private set; }

        public HttpStatusCode StatusCode {
            get { return Response.StatusCode; }
        }

        public string StatusDescription {
            get { return Response.StatusDescription; }
        }

        public string Method {
            get { return Response.Method; }
        }

        public string ContentType {
            get { return Response.ContentType; }
        }

        public WebExceptionStatus WebStatus {
            get { return Exception == null ? WebExceptionStatus.Success : Exception.Status; }
        }
        
        internal SocialHttpResponse(HttpWebResponse response) {
            Response = response;
        }

        internal SocialHttpResponse(HttpWebResponse response, WebException exception) {
            Response = response;
            Exception = exception;
        }

        /// <summary>
        /// Gets the response body as a RAW string.
        /// </summary>
        public string GetBodyAsString() {
            using (Stream stream = Response.GetResponseStream()) {
                using (StreamReader reader = new StreamReader(stream)) {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Gets the response body as an instance of either <var>JsonObject</var> or
        /// <var>JsonArray</var>.
        /// </summary>
        public IJsonObject GetBodyAsJson() {
            return JsonConverter.Parse(GetBodyAsString());
        }

        /// <summary>
        /// Gets the response body as an instance of <var>JsonObject</var>.
        /// </summary>
        public JsonObject GetBodyAsJsonObject() {
            return GetBodyAsJson() as JsonObject;
        }

        /// <summary>
        /// Gets the response body as an instance of <var>JsonArray</var>.
        /// </summary>
        public JsonArray GetBodyAsJsonArray() {
            return GetBodyAsJson() as JsonArray;
        }

    }

}