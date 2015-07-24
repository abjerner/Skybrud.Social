using System;
using Skybrud.Social.Google.OAuth;

namespace Skybrud.Social.Google.YouTube {
    
    /// <summary>
    /// Class representing a scope in the YouTube API.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/guides/auth/server-side-web-apps#Obtaining_Access_Tokens</cref>
    /// </see>
    public class YouTubeScope : GoogleScope {

        #region Readonly properties

        /// <summary>
        /// Manage your YouTube account.
        /// </summary>
        [Obsolete("Use YouTubeScopes.Manage instead.")]
        public static readonly YouTubeScope Manage = YouTubeScopes.Manage;

        /// <summary>
        /// View your YouTube account.
        /// </summary>
        [Obsolete("Use YouTubeScopes.Readonly instead.")]
        public static readonly YouTubeScope Readonly = YouTubeScopes.Readonly;

        /// <summary>
        /// Upload YouTube videos and manage your YouTube videos.
        /// </summary>
        [Obsolete("Use YouTubeScopes.Upload instead.")]
        public static readonly YouTubeScope Upload = YouTubeScopes.Upload;

        /// <summary>
        /// Retrieve the auditDetails part in a channel resource.
        /// </summary>
        [Obsolete("Use YouTubeScopes.PartnerChannelAudit instead.")]
        public static readonly YouTubeScope PartnerChannelAudit = YouTubeScopes.PartnerChannelAudit;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new scope with the specified <code>name</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public YouTubeScope(string name) : base(name) { }

        /// <summary>
        /// Initializes a new scope with the specified <code>name</code> and <code>description</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public YouTubeScope(string name, string description) : base(name, description) { }

        #endregion

    }

}