using System.Collections.Generic;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {
    
    public class BitBucketLink : SocialJsonObject {

        #region Properties

        public string Name { get; private set; }

        public string Href { get; private set; }

        #endregion

        #region Constructors

        private BitBucketLink(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static Dictionary<string, BitBucketLink> ParseMultiple(JsonObject obj) {

            // Check if NULL
            if (obj == null) return null;

            // Initialize the dictionary
            Dictionary<string, BitBucketLink> links = new Dictionary<string, BitBucketLink>();

            // Iterate through the specified object
            foreach (string key in obj.Dictionary.Keys) {
                JsonObject value = obj.GetObject(key);
                if (value == null) continue;
                links.Add(key, new BitBucketLink(obj) {
                    Name = key,
                    Href = value.GetString("href")
                });
            }
            
            // Return the dictionary
            return links;

        }

        #endregion

    }

}