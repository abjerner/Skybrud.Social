using System;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubEmailsResponse : GitHubResponse<GitHubEmail[]> {

        #region Constructor

        private GitHubEmailsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        public static GitHubEmailsResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubEmailsResponse(response) {
                Body = JsonArray.ParseJson(response.Body).ParseMultiple(GitHubEmail.Parse)
            };

        }

    }

}