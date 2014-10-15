using System.IO;
using System.Net;
using Skybrud.Social.Json;

namespace Skybrud.Social {
    
    /// <summary>
    /// Wrapper class for <code>HttpWebResponse</code>.
    /// </summary>
    public class SocialHttpResponse {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <code>HttpWebResponse</code>.
        /// </summary>
        public HttpWebResponse Response { get; private set; }

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

        public WebHeaderCollection Headers {
            get { return Response.Headers; }
        }

        #endregion

        #region Constructor

        private SocialHttpResponse(HttpWebResponse response) {
            Response = response;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the response body as a RAW string.
        /// </summary>
        public string GetBodyAsString() {
            using (Stream stream = Response.GetResponseStream()) {
                if (stream == null) return null;
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
            string str = GetBodyAsString();
            return str == null ? null : JsonConverter.Parse(str);
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

        #endregion

        #region Static methods

        public static SocialHttpResponse GetFromWebResponse(HttpWebResponse response) {
            return response == null ? null : new SocialHttpResponse(response);
        }

        #endregion

    }

}