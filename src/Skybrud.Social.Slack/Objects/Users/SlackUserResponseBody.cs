using Skybrud.Social.Json;

namespace Skybrud.Social.Slack.Objects.Users {
    
    public class SlackUserResponseBody : SlackObject {

        #region Properties

        /// <summary>
        /// Gets a reference to the requested user.
        /// </summary>
        public SlackUser User { get; private set; }
        
        #endregion

        #region Constructors

        private SlackUserResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>SlackUserResponseBody</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static SlackUserResponseBody Parse(JsonObject obj) {
            if (obj == null) return null;
            return new SlackUserResponseBody(obj) {
                User = obj.GetObject("user", SlackUser.Parse)
            };
        }

        #endregion

    }

}