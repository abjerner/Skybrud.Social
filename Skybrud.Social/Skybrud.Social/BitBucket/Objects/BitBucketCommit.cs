using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {
    
    public class BitBucketCommit {

        private JsonObject _json;

        #region Properties

        /// <summary>
        /// The SHA hash identifying the commit.
        /// </summary>
        public string Hash { get; private set; }

        /// <summary>
        /// The date of the commit.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// The commit message specified by the author.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Brief information of the repository.
        /// </summary>
        public BitBucketRepositoryInfo Repository { get; private set; }
        
        /// <summary>
        /// Brief information about the author of the commit.
        /// </summary>
        public BitBucketAuthor Author { get; private set; }

        /// <summary>
        /// A collection of links related to the commit.
        /// </summary>
        public BitBucketLinkCollection Links { get; private set; }

        #endregion

        #region Constructor(s)

        private BitBucketCommit() {
            // make default constructor private
        } 

        #endregion

        #region Member methods

        public string ToJson() {
            return _json == null ? null : _json.ToJson();
        }

        #endregion

        #region Static methods

        public static BitBucketCommit ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        public static BitBucketCommit Parse(JsonObject obj) {

            // Check if NULL
            if (obj == null) return null;

            // Initialize the object
            return new BitBucketCommit {
                _json = obj,
                Hash = obj.GetString("hash"),
                Date = DateTime.Parse(obj.GetString("date")),
                Message = obj.GetString("message"),
                Repository = obj.GetObject("repository", BitBucketRepositoryInfo.Parse),
                Author = obj.GetObject("author", BitBucketAuthor.Parse),
                Links = obj.GetObject("links", BitBucketLinkCollection.Parse)
            };

        }

        #endregion

    }

}
