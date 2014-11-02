using System;
using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects {
    
    public class GitHubCommitAuthor : SocialJsonObject {

        #region Properties

        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("email")]
        public string Email { get; private set; }
        
        [JsonProperty("date")]
        public DateTime Date { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitAuthor(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubCommitAuthor Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GitHubCommitAuthor(obj) {
                Name = obj.GetString("name"),
                Email = obj.GetString("email"),
                Date = obj.GetDateTime("date")
            };
        }

        #endregion

    }

}