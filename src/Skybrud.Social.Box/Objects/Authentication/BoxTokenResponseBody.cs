using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Box.Objects.Authentication {
    
    /// <summary>
    /// Class representing the response body of a call to get an access token.
    /// </summary>
    public class BoxTokenResponseBody : BoxObject {

        #region Properties

        public string AccessToken { get; private set; }

        public TimeSpan ExpiresIn { get; private set; }

        public string TokenType { get; private set; }

        public string RefreshToken { get; private set; }

        #endregion

        #region Constructors

        private BoxTokenResponseBody(JObject obj) : base(obj) {
            AccessToken = obj.GetString("access_token");
            ExpiresIn = obj.GetDouble("expires_in", TimeSpan.FromSeconds);
            TokenType = obj.GetString("token_type");
            RefreshToken = obj.GetString("refresh_token");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>BoxTokenResponseBody</code> from the specified <code>JObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to parse.</param>
        public static BoxTokenResponseBody Parse(JObject obj) {
            return obj == null ? null : new BoxTokenResponseBody(obj);
        }

        #endregion

    }

}