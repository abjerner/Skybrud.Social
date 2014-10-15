using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects {

    public class GitHubUserSummary : SocialJsonObject {

        #region Properties

        public string Login { get; private set; }

        public int Id { get; private set; }

        public string AvatarUrl { get; private set; }

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

        #endregion

        #region Constructor

        private GitHubUserSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubUserSummary Parse(JsonObject obj) {

            if (obj == null) return null;

            string strType = obj.GetString("type");
            GitHubUserType type;
            switch (strType) {
                case "User": type = GitHubUserType.User; break;
                case "Organization": type = GitHubUserType.Organization; break;
                default: throw new Exception("Unknown user type \"" + strType + "\".");
            }

            return new GitHubUserSummary(obj) {
                Login = obj.GetString("login"),
                Id = obj.GetInt32("id"),
                AvatarUrl = obj.GetString("avatar_url"),
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
                IsSiteAdmin = obj.GetBoolean("site_admin")
            };
        
        }

        #endregion

    }

}