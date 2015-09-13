using Skybrud.Social.Json;

namespace Skybrud.Social.Slack.Objects.Authentication {
    
    public class SlackAuthenticationTest : SlackObject {

        #region Properties

        public string Url { get; private set; }

        public string Team { get; private set; }

        public string User { get; private set; }

        public string TeamId { get; private set; }

        public string UserId { get; private set; }

        #endregion

        #region Constructors

        private SlackAuthenticationTest(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>SlackAuthenticationTest</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static SlackAuthenticationTest Parse(JsonObject obj) {
            if (obj == null) return null;
            return new SlackAuthenticationTest(obj) {
                Url = obj.GetString("url"),
                Team = obj.GetString("team"),
                User = obj.GetString("user"),
                TeamId = obj.GetString("team_id"),
                UserId = obj.GetString("user_id")
            };
        }

        #endregion

    }

}