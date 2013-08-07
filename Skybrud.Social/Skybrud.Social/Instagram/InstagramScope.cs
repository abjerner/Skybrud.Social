using System;

namespace Skybrud.Social.Instagram {

    [Flags]
    public enum InstagramScope {
        Basic = 1,
        Comments = 2,
        Relationships = 4,
        Likes = 8
    }

}