using System.Net;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubCommitsResponse : GitHubResponse {

        #region Properties

        public SocialJsonArray<GitHubCommitSummary> Data { get; private set; }

        #endregion

        #region Constructor

        private GitHubCommitsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static GitHubCommitsResponse ParseResponse(SocialHttpResponse response) {

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
            return new GitHubCommitsResponse(response) {
                Data = SocialJsonArray<GitHubCommitSummary>.Parse(array, GitHubCommitSummary.Parse)
            };

        }

        #endregion

    }

}
