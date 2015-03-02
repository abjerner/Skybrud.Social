using System.Net;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses { 

    public class GitHubOrganizationsResponse : GitHubResponse<GitHubOrganizationSummary[]> {

        #region Constructor

        private GitHubOrganizationsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        public static GitHubOrganizationsResponse ParseResponse(SocialHttpResponse response) {

            // Check for any errors
            if (response.StatusCode != HttpStatusCode.OK) {

                // Parse the raw JSON response
                JsonObject obj = response.GetBodyAsJsonObject();
                
                string message = obj.GetString("message");
                string url = obj.GetString("documentation_url");
                throw new GitHubHttpException(response.StatusCode, message, url);
            
            }

            // Parse the raw JSON response
            JsonArray array = response.GetBodyAsJsonArray();

            // Initialize the object to be returned
            return new GitHubOrganizationsResponse(response) {
                Body = array.ParseMultiple(GitHubOrganizationSummary.Parse)
            };

        }

    }

}