using System;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Xml;

namespace Skybrud.Social.Http {
    
    /// <summary>
    /// Class representing a response from a call to a server. Generally this class (or other classes inheriting from
    /// this class) should be used to represent the object oriented (parsed) response wrapping an instance of
    /// <see cref="SocialHttpResponse"/> (raw response).
    /// </summary>
    public class SocialResponse {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying raw response.
        /// </summary>
        public SocialHttpResponse Response { get; }

        /// <summary>
        /// Gets the status code returned by the server.
        /// </summary>
        public HttpStatusCode StatusCode => Response.StatusCode;

        /// <summary>
        /// Gets the status description returned by the server.
        /// </summary>
        public string StatusDescription => Response.StatusDescription;

        /// <summary>
        /// Gets the HTTP method of the request to the server.
        /// </summary>
        public string Method => Response.Method;

        /// <summary>
        /// Gets the content type of the response.
        /// </summary>
        public string ContentType => Response.ContentType;

        /// <summary>
        /// Gets a collection of headers returned by the server.
        /// </summary>
        public SocialHttpHeaderCollection Headers => Response.Headers;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified raw <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        protected SocialResponse(SocialHttpResponse response) {
            Response = response;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <see cref="JObject"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>An instance of <see cref="JObject"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected static JObject ParseJsonObject(string json) {
            return JsonUtils.ParseJsonObject(json);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected static T ParseJsonObject<T>(string json, Func<JObject, T> func) {
            return JsonUtils.ParseJsonObject(json, func);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <see cref="JArray"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>Returns an instance of <see cref="JArray"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected static JArray ParseJsonArray(string json) {
            return JsonUtils.ParseJsonArray(json);
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an array of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <typeparamref name="T"/>.</param>
        /// <returns>An array of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected static T[] ParseJsonArray<T>(string json, Func<JObject, T> func) {
            return JsonUtils.ParseJsonArray(json, func);
        }

        /// <summary>
        /// Parses the specified <paramref name="xml"/> into an instance of <see cref="XElement"/>.
        /// </summary>
        /// <param name="xml">The XML to be parsed.</param>
        /// <returns>An instance of <see cref="XElement"/>.</returns>
        protected static XElement ParseXmlElement(string xml) {
            return XmlUtils.ParseXmlElement(xml);
        }

        /// <summary>
        /// Parses the specified <paramref name="xml"/> into an instance of <see cref="XElement"/>, which is then converted
        /// into an instance of <typeparamref name="T"/> using the specified <paramref name="callback"/> function.
        /// </summary>
        /// <typeparam name="T">The type of the instance to be returned.</typeparam>
        /// <param name="xml">The XML to be parsed.</param>
        /// <param name="callback">The callback function used for converting the parsed <see cref="XElement"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the specified <paramref name="xml"/>.</returns>
        protected static T ParseXmlElement<T>(string xml, Func<XElement, T> callback) {
            return XmlUtils.ParseXmlElement(xml, callback);
        }

        #endregion

    }

}