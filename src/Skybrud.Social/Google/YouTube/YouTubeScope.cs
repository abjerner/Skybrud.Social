using Skybrud.Social.Google.OAuth;

namespace Skybrud.Social.Google.YouTube {
    
    public class YouTubeScope : GoogleScope {

        #region Readonly properties

        /// <summary>
        /// Manage your YouTube account.
        /// </summary>
        public static readonly YouTubeScope Manage = new YouTubeScope(
            "https://www.googleapis.com/auth/youtube",
            "Manage your YouTube account."
        );

        /// <summary>
        /// View your YouTube account.
        /// </summary>
        public static readonly YouTubeScope Readonly = new YouTubeScope(
            "https://www.googleapis.com/auth/youtube.readonly",
            "View your YouTube account."
        );

        /// <summary>
        /// Upload YouTube videos and manage your YouTube videos.
        /// </summary>
        public static readonly YouTubeScope Upload = new YouTubeScope(
            "https://www.googleapis.com/auth/youtube.upload",
            "Upload YouTube videos and manage your YouTube videos."
        );

        /// <summary>
        /// Retrieve the auditDetails part in a channel resource.
        /// </summary>
        public static readonly YouTubeScope PartnerChannelAudit = new YouTubeScope(
            "https://www.googleapis.com/auth/youtubepartner-channel-audit",
            "Retrieve the auditDetails part in a channel resource."
        );

        #endregion

        #region Constructor

        public YouTubeScope(string name) : base(name) { }

        public YouTubeScope(string name, string description) : base(name, description) { }

        #endregion

    }

}