using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {
    
    public class BitBucketUserRepository : SocialJsonObject {

        #region Properties

        public string Slug { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Logo { get; private set; }
        public string Type { get; private set; }
        public string Owner { get; private set; }
        public string Creator { get; private set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }

        public string WebUrl {
            get { return "https://bitbucket.org/" + Owner + "/" + Slug; }
        }

        #endregion

        #region Constructors

        private BitBucketUserRepository(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>BitBucketUserRepository</var> from the JSON file at the specified
        /// <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static BitBucketUserRepository LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>BitBucketUserRepository</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static BitBucketUserRepository ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>BitBucketUserRepository</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static BitBucketUserRepository Parse(JsonObject obj) {
            if (obj == null) return null;
            return new BitBucketUserRepository(obj) {
                Slug = obj.GetString("slug"),
                Name = obj.GetString("name"),
                Description = obj.GetString("description"),
                Logo = obj.GetString("logo"),
                Owner = obj.GetString("owner"),
                Creator = obj.GetString("creator"),
                Type = obj.GetString("scm"),
                CreatedOn = DateTime.Parse(obj.GetString("created_on")),
                LastUpdated = DateTime.Parse(obj.GetString("last_updated"))
            };
        }

        #endregion
    
    }

}
