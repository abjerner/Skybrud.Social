using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    /// <summary>
    /// Class representing the meta data returned by the Instagram API.
    /// </summary>
    public class InstagramMetaData : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the status code of the call.
        /// </summary>
        public int Code { get; private set; }

        /// <summary>
        /// Gets the type of the error or <code>null</code> if not specified.
        /// </summary>
        public string ErrorType { get; private set; }

        /// <summary>
        /// Gets the message of the error or <code>null</code> if not specified.
        /// </summary>
        public string ErrorMessage { get; private set; }

        #endregion

        #region Constructors

        private InstagramMetaData(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramMetaData</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramMetaData</code>.</returns>
        public static InstagramMetaData Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramMetaData(obj) {
                Code = obj.GetInt32("code"),
                ErrorType = obj.GetString("error_type"),
                ErrorMessage = obj.GetString("error_message")
            };
        }

        #endregion

    }

}