namespace Skybrud.Social.Instagram.Scopes {

    /// <summary>
    /// Static class with known scopes of the Instagram API.
    /// </summary>
    public static class InstagramScopes {

        /// <summary>
        /// To read any and all data related to a user (e.g. following/followed-by lists, photos, etc.) (granted by default).
        /// </summary>
        public static readonly InstagramScope Basic = new InstagramScope("basic");

        /// <summary>
        /// Grants your app read access to public content of other Instagram users.
        /// </summary>
        public static readonly InstagramScope PublicContent = new InstagramScope("public_content");

        /// <summary>
        /// To create or delete comments on a user’s behalf.
        /// </summary>
        public static readonly InstagramScope Comments = new InstagramScope("comments");

        /// <summary>
        /// To follow and unfollow users on a user’s behalf.
        /// </summary>
        public static readonly InstagramScope Relationships = new InstagramScope("relationships");

        /// <summary>
        /// To like and unlike items on a user’s behalf.
        /// </summary>
        public static readonly InstagramScope Likes = new InstagramScope("likes");

    }

}