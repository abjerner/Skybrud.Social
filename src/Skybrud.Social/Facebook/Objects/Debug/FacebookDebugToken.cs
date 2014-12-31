using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Debug {
    
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.2/debug_token#read</cref>
    /// </see>
    public class FacebookDebugToken : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the data wrapper around the result.
        /// </summary>
        public FacebookDebugTokenData Data { get; private set; }

        #endregion
        
        #region Constructors

        private FacebookDebugToken(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookDebugToken Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookDebugToken(obj) {
                Data = obj.GetObject("data", FacebookDebugTokenData.Parse)
            };
        }

        #endregion

    }

}