namespace Skybrud.Social.Pinterest.Scopes {

    public static class PinterestScopes {

        /// <summary>
        /// Grants read access to the pins, boards and likes of the authenticated user.
        /// </summary>
        public static readonly PinterestScope ReadPublic = new PinterestScope("read_public");

        /// <summary>
        /// Grants write access to the pins, boards and likes of the authenticated user.
        /// </summary>
        public static readonly PinterestScope WritePublic = new PinterestScope("write_public");

        /// <summary>
        /// Grants read access to the what the authenticated user is following.
        /// </summary>
        public static readonly PinterestScope ReadRelationships = new PinterestScope("read_relationships");

        /// <summary>
        /// Grants write access to the what the authenticated user is following.
        /// </summary>
        public static readonly PinterestScope WriteRelationships = new PinterestScope("write_relationships");

    }

}