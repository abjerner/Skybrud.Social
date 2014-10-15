using System.Net;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubUsersResponse : GitHubResponse {

        #region Properties

        /// <summary>
        /// Gets a reference to the user.
        /// </summary>
        public GitHubUserSummary[] Users { get; private set; }

        #endregion

        #region Constructor

        private GitHubUsersResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        public static GitHubUsersResponse ParseResponse(SocialHttpResponse response) {

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
            return new GitHubUsersResponse(response) {
                Users = array.ParseMultiple(GitHubUserSummary.Parse)
            };

        }

    }

}
