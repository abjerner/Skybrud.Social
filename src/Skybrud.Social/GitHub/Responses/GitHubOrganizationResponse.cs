using System.Net;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubOrganizationResponse : GitHubResponse<GitHubOrganization> {

        #region Constructor

        private GitHubOrganizationResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        public static GitHubOrganizationResponse ParseResponse(SocialHttpResponse response) {

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();

            // Check for any errors
            if (response.StatusCode != HttpStatusCode.OK) {
                string message = obj.GetString("message");
                string url = obj.GetString("documentation_url");
                throw new GitHubHttpException(response.StatusCode, message, url);
            }

            // Initialize the object to be returned
            return new GitHubOrganizationResponse(response) {
                Body = GitHubOrganization.Parse(obj)
            };

        }

    }

}