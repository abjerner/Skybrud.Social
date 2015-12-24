using System;

namespace Skybrud.Social.Instagram {

    /// <summary>
    /// Enum class representing the scopes of the Instagram API.
    /// </summary>
    [Flags]
    [Obsolete("Use static class InstagramScopes instead for accesssing known scopes.")]
    public enum InstagramScope {

        // TODO: Remove in v1.0

        /// <summary>
        /// To read any and all data related to a user (e.g. following/followed-by lists, photos, etc.) (granted by default).
        /// </summary>
        Basic = 0,

        /// <summary>
        /// To create or delete comments on a user’s behalf.
        /// </summary>
        Comments = 1,

        /// <summary>
        /// To follow and unfollow users on a user’s behalf.
        /// </summary>
        Relationships = 2,

        /// <summary>
        /// To like and unlike items on a user’s behalf.
        /// </summary>
        Likes = 4
    
    }

}