using System.Collections.Generic;
using System.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {

    public class BitBucketLinkCollection {

        private Dictionary<string, BitBucketLink> _links;

        public BitBucketLink[] Links {
            get { return _links.Values.ToArray(); }
        }

        private BitBucketLinkCollection() {
            // make constructor private
        }

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

            return new BitBucketLinkCollection {
                _links = BitBucketLink.ParseMultiple(obj)
            };

        }

    }

}