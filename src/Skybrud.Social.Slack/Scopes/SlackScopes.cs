namespace Skybrud.Social.Slack.Scopes {

    /// <see>
    ///     <cref>https://api.slack.com/docs/oauth#auth_scopes</cref>
    /// </see>
    public class SlackScopes {

        #region Constants

        /// <summary>
        /// Allows applications to confirm your identity.
        /// </summary>
        public static readonly SlackScope Identify = new SlackScope("identify", "Allows applications to confirm your identity.");

        /// <summary>
        /// Allows applications to read any messages and state that the user can see.
        /// </summary>
        public static readonly SlackScope Read = new SlackScope("read", "Allows applications to read any messages and state that the user can see.");

        /// <summary>
        /// Allows applications to write messages and create content on behalf of the user.
        /// </summary>
        public static readonly SlackScope Post = new SlackScope("post", "Allows applications to write messages and create content on behalf of the user.");

        /// <summary>
        /// Allows applications to connect to slack as a client, and post messages on behalf of the user.
        /// </summary>
        public static readonly SlackScope Client = new SlackScope("client", "Allows applications to connect to slack as a client, and post messages on behalf of the user.");

        /// <summary>
        /// Allows applications to perform administrative actions, requires the authed user is an admin.
        /// </summary>
        public static readonly SlackScope Admin = new SlackScope("admin", "Allows applications to perform administrative actions, requires the authed user is an admin.");

        #endregion

    }

}