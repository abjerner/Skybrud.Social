using System.Collections.Generic;
using System.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {

    public class BitBucketLinkCollection : SocialJsonObject {

        private Dictionary<string, BitBucketLink> _links;

        public BitBucketLink[] Links {
            get { return _links.Values.ToArray(); }
        }

        #region Constructors

        private BitBucketLinkCollection(JsonObject obj) : base(obj) { }

        #endregion

        public bool HasLink(string name) {
            return _links.ContainsKey(name);
        }

        public BitBucketLink GetLink(string name) {
            BitBucketLink link;
            return _links.TryGetValue(name, out link) ? link : null;
        }

        public static BitBucketLinkCollection Parse(JsonObject obj) {

            // Check if NULL
            if (obj == null) return null;

            return new BitBucketLinkCollection(obj) {
                _links = BitBucketLink.ParseMultiple(obj)
            };

        }

    }

}