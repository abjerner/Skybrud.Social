using System;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubUsersResponse : GitHubResponse<GitHubUserSummary[]> {

        #region Constructor

        private GitHubUsersResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        public static GitHubUsersResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubUsersResponse(response) {
                Body = JsonArray.ParseJson(response.Body).ParseMultiple(GitHubUserSummary.Parse)
            };

        }

    }

}