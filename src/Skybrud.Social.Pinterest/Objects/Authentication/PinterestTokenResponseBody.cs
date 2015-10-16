using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;
using Skybrud.Social.Pinterest.Scopes;

namespace Skybrud.Social.Pinterest.Objects.Authentication {
    
    public class PinterestTokenResponseBody : PinterestObject {

        #region Properties

        public string AccessToken { get; private set; }

        public string TokenType { get; private set; }

        public PinterestScope[] Scope { get; private set; }
        
        #endregion

        #region Constructors

        private PinterestTokenResponseBody(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>PinterestTokenResponseBody</code> from the specified <code>JObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to parse.</param>
        public static PinterestTokenResponseBody Parse(JObject obj) {
            
            if (obj == null) return null;
            
            // Parse the rest of the response
            return new PinterestTokenResponseBody(obj) {
                AccessToken = obj.GetString("access_token"),
                TokenType = obj.GetString("token_type"),
                Scope = GetStringArray(obj, "scope", x => PinterestScope.GetScope(x) ?? PinterestScope.RegisterScope(x))
            };
        
        }

        private static T[] GetStringArray<T>(JObject obj, string propertyName, Func<string, T> func) {
            JArray array = obj.GetArray(propertyName);
            return array == null ? new T[0] : (from item in array select func(item.ToString())).ToArray();
        }

        #endregion

    }

}