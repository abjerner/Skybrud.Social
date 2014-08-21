namespace Skybrud.Social.Google.YouTube {
    
    public class YouTubeScope {

        #region Readonly properties

        /// <summary>
        /// Manage your YouTube account.
        /// </summary>
        public static readonly YouTubeScope Manage = new YouTubeScope("https://www.googleapis.com/auth/youtube");

        /// <summary>
        /// View your YouTube account.
        /// </summary>
        public static readonly YouTubeScope Readonly = new YouTubeScope("https://www.googleapis.com/auth/youtube.readonly");

        /// <summary>
        /// Upload YouTube videos and manage your YouTube videos.
        /// </summary>
        public static readonly YouTubeScope Upload = new YouTubeScope("https://www.googleapis.com/auth/youtube.upload");

        /// <summary>
        /// Retrieve the auditDetails part in a channel resource.
        /// </summary>
        public static readonly YouTubeScope PartnerChannelAudit = new YouTubeScope("https://www.googleapis.com/auth/youtubepartner-channel-audit");

        #endregion

        #region Member properties

        public string Name { get; private set; }

        #endregion

        #region Constructor

        public YouTubeScope(string name) {
            Name = name;
        }

        #endregion

        #region Member methods

        public override string ToString() {
            return Name;
        }

        #endregion

    }

}