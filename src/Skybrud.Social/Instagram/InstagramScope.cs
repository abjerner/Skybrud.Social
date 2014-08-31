using System;

namespace Skybrud.Social.Instagram {

    [Flags]
    public enum InstagramScope {

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