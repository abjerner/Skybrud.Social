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

        public DateTime created_at { get; private set; }
        
        public DateTime updated_at { get; private set; }

        public DateTime pushed_at { get; private set; }

        public string git_url { get; private set; }

        public string ssh_url { get; private set; }

        public string clone_url { get; private set; }

        public string svn_url { get; private set; }

        public string homepage { get; private set; }

        public long size { get; private set; }

        public int stargazers_count { get; private set; }

        public int watchers_count { get; private set; }

        public string language { get; private set; }

        public bool has_issues { get; private set; }

        public bool has_downloads  { get; private set; }

        public bool has_wiki  { get; private set; }

        public bool has_pages { get; private set; }

        public int forks_count { get; private set; }

        public string mirror_url { get; private set; }

        public int open_issues_count { get; private set; }

        public int forks { get; private set; }

        public int open_issues { get; private set; }

        public int watchers { get; private set; }

        public string default_branch { get; private set; }

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
                created_at = obj.GetDateTime("created_at"),
                updated_at = obj.GetDateTime("updated_at"),
                pushed_at = obj.GetDateTime("pushed_at"),
                git_url = obj.GetString("git_url"),
                ssh_url = obj.GetString("ssh_url"),
                clone_url = obj.GetString("clone_url"),
                svn_url = obj.GetString("svn_url"),
                homepage = obj.GetString("homepage"),
                size = obj.GetInt64("size"),
                stargazers_count = obj.GetInt32("stargazers_count"),
                watchers_count = obj.GetInt32("watchers_count"),
                language = obj.GetString("language"),
                has_issues = obj.GetBoolean("has_issues"),
                has_downloads = obj.GetBoolean("has_downloads"),
                has_wiki = obj.GetBoolean("has_wiki"),
                has_pages = obj.GetBoolean("has_pages"),
                forks_count = obj.GetInt32("forks_count"),
                mirror_url = obj.GetString("mirror_url"),
                open_issues_count = obj.GetInt32("open_issues_count"),
                forks = obj.GetInt32("forks"),
                open_issues = obj.GetInt32("open_issues"),
                watchers = obj.GetInt32("watchers"),
                default_branch = obj.GetString("default_branch")
            };
        }

        #endregion

    }

}