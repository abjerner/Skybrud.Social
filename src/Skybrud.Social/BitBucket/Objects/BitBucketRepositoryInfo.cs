using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {

    public class BitBucketRepositoryInfo : SocialJsonObject {

        #region Properties

        /// <summary>
        /// The full name of the repository. The full name can be described as "{accountName}/{repoSlug}".
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// A collection of links related to the repository.
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

        private BitBucketRepositoryInfo(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static BitBucketRepositoryInfo Parse(JsonObject obj) {
            if (obj == null) return null;
            return new BitBucketRepositoryInfo(obj) {
                FullName = obj.GetString("full_name"),
                Links = obj.GetObject("links", BitBucketLinkCollection.Parse)
            };
        }

        #endregion

    }

}