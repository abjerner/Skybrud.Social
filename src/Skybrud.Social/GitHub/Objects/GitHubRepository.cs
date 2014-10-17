using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects {
    
    public class GitHubRepository : SocialJsonObject {

        #region Properties

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string FullName { get; private set; }

        public bool IsPrivate { get; private set; }

        public string HtmlUrl { get; private set; }

        public string Description { get; private set; }

        public bool IsFork { get; private set; }

        public string Url { get; private set; }

        #endregion

        #region Constructor

        private GitHubRepository(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubRepository Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GitHubRepository(obj) {
                Id = obj.GetInt32("id"),
                Name = obj.GetString("name"),
                FullName = obj.GetString("full_name"),
                IsPrivate = obj.GetBoolean("private"),
                HtmlUrl = obj.GetString("html_url"),
                Description = obj.GetString("description"),
                IsFork = obj.GetBoolean("fork"),
                Url = obj.GetString("url")
            };
        }

        #endregion

    }

}
