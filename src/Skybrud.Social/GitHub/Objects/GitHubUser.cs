using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects {

    public class GitHubUser : SocialJsonObject {

        #region Properties

        public string Login { get; private set; }

        public int Id { get; private set; }

        public string AvatarUrl { get; private set; }

        public string GravatarId { get; private set; }

        public string Url { get; private set; }

        public string HtmlUrl { get; private set; }

        public string FollowersUrl { get; private set; }

        public string FollowingUrl { get; private set; }

        public string GistsUrl { get; private set; }

        public string StarredUrl { get; private set; }

        public string SubscriptionsUrl { get; private set; }

        public string OrganizationsUrl { get; private set; }

        public string ReposUrl { get; private set; }

        public string EventsUrl { get; private set; }

        public string ReceivedEventsUrl { get; private set; }

        public GitHubUserType Type { get; private set; }

        public bool IsSiteAdmin { get; private set; }

        public string Name { get; private set; }

        public string Company { get; private set; }

        public string Location { get; private set; }

        public string Email { get; private set; }

        public string IsHireable { get; private set; }

        public string Bio { get; private set; }

        public int PublicRepos { get; private set; }

        public int PublicGists { get; private set; }

        public int Followers { get; private set; }

        public int Following { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        #endregion

        #region Constructor

        private GitHubUser(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubUser ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        public static GitHubUser Parse(JsonObject obj) {

            if (obj == null) return null;

            string strType = obj.GetString("type");
            GitHubUserType type;
            switch (strType) {
                case "User": type = GitHubUserType.User; break;
                case "Organization": type = GitHubUserType.Organization; break;
                default: throw new Exception("Unknown user type \"" + strType + "\".");
            }

            return new GitHubUser(obj) {
                Login = obj.GetString("login"),
                Id = obj.GetInt32("id"),
                AvatarUrl = obj.GetString("avatar_url"),
                GravatarId = obj.GetString("gravatar_id"),
                Url = obj.GetString("url"),
                HtmlUrl = obj.GetString("html_url"),
                FollowersUrl = obj.GetString("followers_url"),
                FollowingUrl = obj.GetString("following_url"),
                GistsUrl = obj.GetString("gists_url"),
                StarredUrl = obj.GetString("starred_url"),
                SubscriptionsUrl = obj.GetString("subscriptions_url"),
                OrganizationsUrl = obj.GetString("organizations_url"),
                ReposUrl = obj.GetString("repos_url"),
                EventsUrl = obj.GetString("events_url"),
                ReceivedEventsUrl = obj.GetString("received_events_url"),
                Type = type,
                IsSiteAdmin = obj.GetBoolean("site_admin"),
                Name = obj.GetString("name"),
                Company = obj.GetString("company"),
                Location = obj.GetString("location"),
                Email = obj.GetString("email"),
                IsHireable = obj.GetString("hireable"),
                Bio = obj.GetString("bio"),
                PublicRepos = obj.GetInt32("public_repos"),
                PublicGists = obj.GetInt32("public_gists"),
                Followers = obj.GetInt32("followers"),
                Following = obj.GetInt32("following"),
                CreatedAt = obj.GetDateTime("created_at"),
                UpdatedAt = obj.GetDateTime("updated_at"),
            };
        
        }

        #endregion

    }

}