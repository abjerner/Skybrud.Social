using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects {
    
    public class GitHubRepositorySummary : SocialJsonObject {

        #region Properties

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string FullName { get; private set; }

        public bool IsPrivate { get; private set; }

        public string HtmlUrl { get; private set; }

        public string Description { get; private set; }

        public bool IsFork { get; private set; }

        public string Url { get; private set; }

        public DateTime CreatedAt { get; private set; }
        
        public DateTime UpdatedAt { get; private set; }

        public DateTime PushedAt { get; private set; }

        public string GitUrl { get; private set; }

        public string SshUrl { get; private set; }

        public string CloneUrl { get; private set; }

        public string SvnUrl { get; private set; }

        public string Homepage { get; private set; }

        public long Size { get; private set; }

        public int StargazersCount { get; private set; }

        public int WatchersCount { get; private set; }

        public string Language { get; private set; }

        public bool HasIssues { get; private set; }

        public bool HasDownloads  { get; private set; }

        public bool HasWiki  { get; private set; }

        public bool HasPages { get; private set; }

        public int ForksCount { get; private set; }

        public string MirrorUrl { get; private set; }

        public int OpenIssuesCount { get; private set; }

        public int Forks { get; private set; }

        public int OpenIssues { get; private set; }

        public int Watchers { get; private set; }

        public string DefaultBranch { get; private set; }

        #endregion

        #region Constructor

        private GitHubRepositorySummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubRepositorySummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GitHubRepositorySummary(obj) {
                Id = obj.GetInt32("id"),
                Name = obj.GetString("name"),
                FullName = obj.GetString("full_name"),
                IsPrivate = obj.GetBoolean("private"),
                HtmlUrl = obj.GetString("html_url"),
                Description = obj.GetString("description"),
                IsFork = obj.GetBoolean("fork"),
                Url = obj.GetString("url"),
                CreatedAt = obj.GetDateTime("created_at"),
                UpdatedAt = obj.GetDateTime("updated_at"),
                PushedAt = obj.GetDateTime("pushed_at"),
                GitUrl = obj.GetString("git_url"),
                SshUrl = obj.GetString("ssh_url"),
                CloneUrl = obj.GetString("clone_url"),
                SvnUrl = obj.GetString("svn_url"),
                Homepage = obj.GetString("homepage"),
                Size = obj.GetInt64("size"),
                StargazersCount = obj.GetInt32("stargazers_count"),
                WatchersCount = obj.GetInt32("watchers_count"),
                Language = obj.GetString("language"),
                HasIssues = obj.GetBoolean("has_issues"),
                HasDownloads = obj.GetBoolean("has_downloads"),
                HasWiki = obj.GetBoolean("has_wiki"),
                HasPages = obj.GetBoolean("has_pages"),
                ForksCount = obj.GetInt32("forks_count"),
                MirrorUrl = obj.GetString("mirror_url"),
                OpenIssuesCount = obj.GetInt32("open_issues_count"),
                Forks = obj.GetInt32("forks"),
                OpenIssues = obj.GetInt32("open_issues"),
                Watchers = obj.GetInt32("watchers"),
                DefaultBranch = obj.GetString("default_branch")
            };
        }

        #endregion

    }

}