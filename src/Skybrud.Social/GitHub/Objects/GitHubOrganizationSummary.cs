using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects {
   

    public class GitHubOrganizationSummary : SocialJsonObject {

        #region Properties

        public string Login { get; private set; }

        public int Id { get; private set; }

        public string Url { get; private set; }

        public string ReposUrl { get; private set; }

        public string EventsUrl { get; private set; }

        public string MembersUrl { get; private set; }

        public string PublicMembersUrl { get; private set; }

        public string AvatarUrl { get; private set; }

        #endregion

        #region Constructor

        private GitHubOrganizationSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubOrganizationSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GitHubOrganizationSummary(obj) {
                Login = obj.GetString("login"),
                Id = obj.GetInt32("id"),
                Url = obj.GetString("url"),
                ReposUrl = obj.GetString("repos_url"),
                EventsUrl = obj.GetString("events_url"),
                MembersUrl = obj.GetString("members_url"),
                PublicMembersUrl = obj.GetString("public_members_url"),
                AvatarUrl = obj.GetString("avatar_url")
            };
        
        }

        #endregion

    }

}
