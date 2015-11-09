using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Debug {
    
    /// <summary>
    /// Class representing the response body of a call to get metadata about a given access token.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.5/debug_token#read</cref>
    /// </see>
    public class FacebookDebugToken : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets a referennce to the metadata about the access token.
        /// </summary>
        public FacebookDebugTokenData Data { get; private set; }

        #endregion
        
        #region Constructors

        private FacebookDebugToken(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>FacebookDebugToken</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>FacebookDebugToken</code>, or <code>null</code> if <code>obj</code>
        /// is <code>null</code>.</returns>
        public static FacebookDebugToken Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookDebugToken(obj) {
                Data = obj.GetObject("data", FacebookDebugTokenData.Parse)
            };
        }

        #endregion

    }

}