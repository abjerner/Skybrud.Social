using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {
    
    public class BitBucketAuthorUser : SocialJsonObject {

        #region Properties

        /// <summary>
        /// The username of the user.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// The display name of the user.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// A collection of links related to the user.
        /// </summary>
        public BitBucketLinkCollection Links { get; private set; }

        /// <summary>
        /// A link poiting to the user's profile in the API.
        /// </summary>
        public BitBucketLink LinkSelf {
            get { return Links.GetLink("self"); }
        }

        /// <summary>
        /// A link pointing to the user's profile at the BitBucket website.
        /// </summary>
        public BitBucketLink LinkHtml {
            get { return Links.GetLink("html"); }
        }

        #endregion

        #region Constructors

        private BitBucketAuthorUser(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static BitBucketAuthorUser Parse(JsonObject obj) {

            // Check if NULL
            if (obj == null) return null;

            // Initialize the user object
            return new BitBucketAuthorUser(obj) {
                Username = obj.GetString("username"),
                DisplayName = obj.GetString("display_name"),
                Links = obj.GetObject("links", BitBucketLinkCollection.Parse)
            };

        }

        #endregion

    }

}