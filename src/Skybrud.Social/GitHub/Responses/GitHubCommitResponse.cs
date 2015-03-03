using System;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubCommitResponse : GitHubResponse<GitHubCommit> {

        #region Constructor

        private GitHubCommitResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static GitHubCommitResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubCommitResponse(response) {
                Body = JsonObject.ParseJson(response.Body, GitHubCommit.Parse)
            };

        }

        #endregion

    }

}