namespace Skybrud.Social.LinkedIn {

    public class LinkedInConstants {
        
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
