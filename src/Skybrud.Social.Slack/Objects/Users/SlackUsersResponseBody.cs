using Skybrud.Social.Json;

namespace Skybrud.Social.Slack.Objects.Users {
    
    public class SlackUsersResponseBody : SlackObject {

        #region Properties

        /// <summary>
        /// Gets a reference to the members of the team.
        /// </summary>
        public SlackUser[] Members { get; private set; }
        
        #endregion

        #region Constructors

        private SlackUsersResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>SlackUsersResponseBody</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static SlackUsersResponseBody Parse(JsonObject obj) {
            if (obj == null) return null;
            return new SlackUsersResponseBody(obj) {
                Members = obj.GetArray("members", SlackUser.Parse)
            };
        }

        #endregion

    }

}