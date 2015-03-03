using System;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubRepositoriesResponse : GitHubResponse<GitHubRepositorySummary[]> {

        #region Constructor

        private GitHubRepositoriesResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        public static GitHubRepositoriesResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubRepositoriesResponse(response) {
                Body = JsonArray.ParseJson(response.Body).ParseMultiple(GitHubRepositorySummary.Parse)
            };

        }

    }

}