using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Http {
    
    /// <summary>
    /// Class representing a response from a call to a server. Generally this class (or other classes inheriting from
    /// this class) should be used to represent the object oriented (parsed) response wrapping an instance of
    /// <code>SocialHttpResponse</code> (raw response).
    /// </summary>
    public class SocialResponse {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying raw response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets the status code returned by the server.
        /// </summary>
        public HttpStatusCode StatusCode {
            get { return Response.StatusCode; }
        }

        /// <summary>
        /// Gets the status description returned by the server.
        /// </summary>
        public string StatusDescription {
            get { return Response.StatusDescription; }
        }

        /// <summary>
        /// Gets the HTTP method of the request to the server.
        /// </summary>
        public string Method {
            get { return Response.Method; }
        }

        /// <summary>
        /// Gets the content type of the response.
        /// </summary>
        public string ContentType {
            get { return Response.ContentType; }
        }

        /// <summary>
        /// Gets a collection of headers returned by the server.
        /// </summary>
        public WebHeaderCollection Headers {
            get { return Response.Headers; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified raw <code>response</code>.
        /// </summary>
        /// <param name="response">The instance of <code>SocialHttpResponse</code> representing the raw response.</param>
        protected SocialResponse(SocialHttpResponse response) {
            Response = response;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Parses the specified <code>json</code> string into an instance of <code>JObject</code>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>Returns an instance of <code>JObject</code> parsed from the specified <code>json</code> string.</returns>
        protected static JObject ParseJsonObject(string json) {
            return SocialUtils.ParseJsonObject(json);
        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an instance of <code>T</code>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <code>JObject</code> into an instance of <code>T</code>.</param>
        /// <returns>Returns an instance of <code>T</code> parsed from the specified <code>json</code> string.</returns>
        protected static T ParseJsonObject<T>(string json, Func<JObject, T> func) {
            return SocialUtils.ParseJsonObject(json, func);
        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an instance of <code>JArray</code>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>Returns an instance of <code>JArray</code> parsed from the specified <code>json</code> string.</returns>
        protected static JArray ParseJsonArray(string json) {
            return SocialUtils.ParseJsonArray(json);
        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an array of <code>T</code>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <code>JObject</code> into an instance of <code>T</code>.</param>
        /// <returns>Returns an array of <code>T</code> parsed from the specified <code>json</code> string.</returns>
        protected static T[] ParseJsonArray<T>(string json, Func<JObject, T> func) {
            return SocialUtils.ParseJsonArray(json, func);
        }

        #endregion

    }

}