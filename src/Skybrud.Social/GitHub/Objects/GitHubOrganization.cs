using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects {

    public class GitHubOrganization : SocialJsonObject {

        #region Properties

        public string Login { get; private set; }

        public int Id { get; private set; }

        public string Url { get; private set; }

        public string ReposUrl { get; private set; }

        public string EventsUrl { get; private set; }

        public string MembersUrl { get; private set; }

        public string PublicMembersUrl { get; private set; }

        public string AvatarUrl { get; private set; }

        public string Name { get; private set; }

        public string Company { get; private set; }

        public string Blog { get; private set; }

        public string Location { get; private set; }

        public string Email { get; private set; }

        public int PublicRepos { get; private set; }

        public int PublicGists { get; private set; }

        public int Followers { get; private set; }

        public int Following { get; private set; }

        public string HtmlUrl { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        // The API also specified the property "type", but I'm not sure an organization can be any
        // other type than "Organization", so the property is omitted here for now.

        #endregion

        #region Constructor

        private GitHubOrganization(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubOrganization Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GitHubOrganization(obj) {
                Login = obj.GetString("login"),
                Id = obj.GetInt32("id"),
                Url = obj.GetString("url"),
                ReposUrl = obj.GetString("repos_url"),
                EventsUrl = obj.GetString("events_url"),
                MembersUrl = obj.GetString("members_url"),
                PublicMembersUrl = obj.GetString("public_members_url"),
                AvatarUrl = obj.GetString("avatar_url"),
                Name = obj.GetString("name"),
                Company = obj.GetString("company"),
                Blog = obj.GetString("blog"),
                Location = obj.GetString("location"),
                Email = obj.GetString("email"),
                PublicRepos = obj.GetInt32("public_repos"),
                PublicGists = obj.GetInt32("public_gists"),
                Followers = obj.GetInt32("followers"),
                Following = obj.GetInt32("following"),
                HtmlUrl = obj.GetString("html_url"),
                CreatedAt = obj.GetDateTime("created_at"),
                UpdatedAt = obj.GetDateTime("updated_at")
            };
        }

        #endregion

    }

}
