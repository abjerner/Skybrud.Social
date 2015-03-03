using System;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubRepositoryResponse : GitHubResponse<GitHubRepository> {

        #region Constructor

        private GitHubRepositoryResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        public static GitHubRepositoryResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubRepositoryResponse(response) {
                Body = JsonObject.ParseJson(response.Body, GitHubRepository.Parse)
            };

        }

    }

}