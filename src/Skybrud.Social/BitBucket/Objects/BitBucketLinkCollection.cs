using System.Collections.Generic;
using System.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {

    public class BitBucketLinkCollection : SocialJsonObject {

        #region Private fields

        private Dictionary<string, BitBucketLink> _links;

        #endregion

        #region Properties

        public BitBucketLink[] Links {
            get { return _links.Values.ToArray(); }
        }

        #endregion

        #region Constructors

        private BitBucketLinkCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Member methods

        public bool HasLink(string name) {
            return _links.ContainsKey(name);
        }

        public BitBucketLink GetLink(string name) {
            BitBucketLink link;
            return _links.TryGetValue(name, out link) ? link : null;
        }

        #endregion

        #region Static methods

        public static BitBucketLinkCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new BitBucketLinkCollection(obj) {
                _links = BitBucketLink.ParseMultiple(obj)
            };
        }

        #endregion

    }

}