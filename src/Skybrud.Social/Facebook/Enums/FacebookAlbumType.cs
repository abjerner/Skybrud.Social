namespace Skybrud.Social.Facebook.Enums {
    
    /// <summary>
    /// Enumeration describing the type of an album.
    /// </summary>
    public enum FacebookAlbumType {

        /// <summary>
        /// Indicates that the album wasn't specified AKA the <code>type</code> was missing in the JSON returned by the
        /// Facebook Graph API.
        /// </summary>
        Unspecified,

        App,
        Cover,
        Profile,
        Mobile,
        Wall,
        Normal,
        Album
    }

}
