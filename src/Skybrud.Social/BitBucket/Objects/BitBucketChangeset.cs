using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {
    
    public class BitBucketChangeset : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Unique ID for the changeset – this is an abbreviated SHA code.
        /// </summary>
        public string Node { get; private set; }

        /// <summary>
        /// The username defined locally and included in the commit passed to the Bitbucket service.
        /// </summary>
        public string RawAuthor { get; private set; }

        /// <summary>
        /// Universal time stamp applied to the change.
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// The Bitbucket account associated with the changeset.
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// A forty-character changeset hash – this is the unabbreviated SHA value.
        /// </summary>
        public string RawNode { get; private set; }

        /// <summary>
        /// The commit message.
        /// </summary>
        public string Message { get; private set; }

        #endregion

        #region Constructors

        private BitBucketChangeset(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static BitBucketChangeset Parse(JsonObject obj) {
            if (obj == null) return null;
            return new BitBucketChangeset(obj) {
                Node = obj.GetString("node"),
                RawAuthor = obj.GetString("raw_author"),
                Timestamp = DateTime.Parse(obj.GetString("utctimestamp")),
                Author = obj.GetString("author"),
                RawNode = obj.GetString("raw_node"),
                Message = obj.GetString("message")
            };
        }

        #endregion
    
    }

}