using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using Skybrud.Social.GitHub.Endpoints;

namespace Skybrud.Social.GitHub {
    
    public class GitHubService {

        public NetworkCredential Credential { get; private set; }
        public string AccessToken { get; private set; }

        public GitHubRepositoriesEndpoint Repositories { get; private set; }

        private GitHubService(string accessToken) {
            AccessToken = accessToken;
            Repositories = new GitHubRepositoriesEndpoint(this);
        }

        private GitHubService(NetworkCredential credential) {
            Credential = credential;
            Repositories = new GitHubRepositoriesEndpoint(this);
        }

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
            if (!string.IsNullOrWhiteSpace(state)) nvc.Add("state", state);

            // Generate the URL
            return "https://github.com/login/oauth/authorize?" + SocialUtils.NameValueCollectionToQueryString(nvc);

        }

        public static GitHubService CreateFromAccessToken(string token) {
            return new GitHubService(token);
        }

        public static GitHubService CreateFromAuthCode(string clientId, string clientSecret, string redirectUri, string code) {

            NameValueCollection parameters = new NameValueCollection {
                {"client_id", clientId},
                {"client_secret", clientSecret},
                {"code", code }
            };

            // Add the redirect URI (if specified)
            if (!string.IsNullOrWhiteSpace(redirectUri)) parameters.Add("redirect_uri", redirectUri);

            // Get the response from the server
            string contents = SocialUtils.DoHttpPostRequestAndGetBodyAsString("https://github.com/login/oauth/access_token", null, parameters);

            // Parse the contents
            NameValueCollection query = HttpUtility.ParseQueryString(contents);

            // Get the access token
            return new GitHubService(query["access_token"]);

        }

        public static GitHubService CreateFromCredential(NetworkCredential credential) {
            return new GitHubService(credential);
        }

        public static GitHubService CreateFromCredential(string username, string password) {
            return new GitHubService(new NetworkCredential(username, password));
        }

        internal string GenerateAbsoluteUrl(string relative) {
            return GenerateAbsoluteUrl(relative, null);
        }

        internal string GenerateAbsoluteUrl(string relative, NameValueCollection query) {

            string url = "https://api.github.com";
            if (Credential != null) {
                url = "https://" + Credential.UserName + ":" + Credential.Password + "@api.github.com";
            } else if (AccessToken != null) {
                query.Add("access_token", AccessToken);
            }

            // Add the relative URL
            url += relative;

            // Append the query string (if not empty)
            if (query != null && query.Count > 0) url += "?" + SocialUtils.NameValueCollectionToQueryString(query);

            // Now return the URL
            return url;

        }
    
    }

}
