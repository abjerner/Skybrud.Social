using System;
using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects.Commits {
    
    public class GitHubCommitFile : SocialJsonObject {

        #region Properties

        [JsonProperty("filename")]
        public string Filename { get; private set; }

        [JsonProperty("additions")]
        public int Additions { get; private set; }
        
        [JsonProperty("deletions")]
        public int Deletions { get; private set; }

        [JsonProperty("changes")]
        public int Changes { get; private set; }

        [JsonProperty("status")]
        public GitHubCommitFileStatus Status { get; private set; }

        [JsonProperty("raw_url")]
        public string RawUrl { get; private set; }

        [JsonProperty("blob_url")]
        public string BlobUrl { get; private set; }

        [JsonProperty("patch")]
        public string Patch { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitFile(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubCommitFile Parse(JsonObject obj) {
            
            if (obj == null) return null;

            // Parse the file status
            GitHubCommitFileStatus status;
            string strStatus = obj.GetString("status");
            switch (strStatus) {
                case "added": status = GitHubCommitFileStatus.Added; break;
                case "modified": status = GitHubCommitFileStatus.Modified; break;
                case "renamed": status = GitHubCommitFileStatus.Renamed; break;
                case "removed": status = GitHubCommitFileStatus.Removed; break;
                default: throw new Exception("Unknown status \"\" - please create an issue it can be fixed https://github.com/abjerner/Skybrud.Social/issues/new");
            }

            return new GitHubCommitFile(obj) {
                Filename = obj.GetString("filename"),
                Additions = obj.GetInt32("additions"),
                Deletions = obj.GetInt32("deletions"),
                Changes = obj.GetInt32("changes"),
                Status = status,
                RawUrl = obj.GetString("raw_url"),
                BlobUrl = obj.GetString("blob_url"),
                Patch = obj.GetString("patch")
            };
        
        }

        #endregion

    }

}
