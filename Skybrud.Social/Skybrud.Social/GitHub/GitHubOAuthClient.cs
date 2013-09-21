using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Skybrud.Social.GitHub {

    public class GitHubOAuthClient {

        public static string GetAuthorizationUrl(string clientId, string redirectUri = null, GitHubScope scope = GitHubScope.Default, string state = null) {

            // Initialize the query string
            NameValueCollection nvc = new NameValueCollection { { "client_id", clientId } };

            // Add the redirect URI (if specified)
            if (!string.IsNullOrWhiteSpace(redirectUri)) nvc.Add("redirect_uri", redirectUri);

            // Get the scope list
            List<string> scopes = new List<string>();
            if (scope.HasFlag(GitHubScope.User)) scopes.Add("user");
            if (scope.HasFlag(GitHubScope.UserEmail)) scopes.Add("user:email");
            if (scope.HasFlag(GitHubScope.UserFollow)) scopes.Add("user:follow");
            if (scope.HasFlag(GitHubScope.PublicRepo)) scopes.Add("public_repo");
            if (scope.HasFlag(GitHubScope.Repo)) scopes.Add("repo");
            if (scope.HasFlag(GitHubScope.RepoStatus)) scopes.Add("repo:status");
            if (scope.HasFlag(GitHubScope.DeleteRepo)) scopes.Add("delete_repo");
            if (scope.HasFlag(GitHubScope.Notifications)) scopes.Add("notifications");
            if (scope.HasFlag(GitHubScope.Gist)) scopes.Add("gist");
            if (scopes.Count > 0) nvc.Add("scope", String.Join(",", scopes));

            // Add the state of specified
            if (!string.IsNullOrWhiteSpace(redirectUri)) nvc.Add("redirect_uri", redirectUri);

            // Generate the URL
            return "https://github.com/login/oauth/authorize?" + SocialUtils.NameValueCollectionToQueryString(nvc);

        }

    }

}
