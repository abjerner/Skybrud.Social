namespace Skybrud.Social.LinkedIn {

    public class LinkedInConstants {
        
        /// <summary>
        /// The default fields used when fetching basic profile info.
        /// </summary>
        /// <see cref="https://developer.linkedin.com/docs/fields/basic-profile" />
        public static readonly string[] BasicProfileDefaultFields = new[] {
            "id",
            "firstName",
            "lastName",
            "headline",
            "num-connections",
            "num-connections-capped",
            "summary",
            "pictureUrl",
            "public-profile-url"
        };

        /// <summary>
        /// The default fields used when fetching group posts.
        /// </summary>
        /// <see cref="https://developer.linkedin.com/documents/groups-fields"/>
        public static readonly string[] GroupPostsDefaultFields = new[] {
            "id",
            "type",
            "site-group-post-url",
            "creation-timestamp",
            "title",
            "summary",
            "creator",
            "likes",
            "comments",
            "attachment:(image-url,content-domain,content-url,title,summary)",
            "relation-to-viewer"
        };
    
    }

}
