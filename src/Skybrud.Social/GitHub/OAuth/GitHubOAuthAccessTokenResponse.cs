using System;
using System.Collections.Specialized;

namespace Skybrud.Social.GitHub.OAuth {

    public class GitHubOAuthAccessTokenResponse {

        public string AccessToken { get; private set; }

        public GitHubScopeCollection Scope { get; private set; }

        public string TokenType { get; private set; }

        public static GitHubOAuthAccessTokenResponse Parse(NameValueCollection nvc) {

            GitHubScopeCollection scopes = new GitHubScopeCollection();

            foreach (string scope in (nvc["scope"] ?? "").Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries)) {
                switch (scope) {
                    case "user": scopes.Add(GitHubScope.User); break;
                    case "user:email": scopes.Add(GitHubScope.UserEmail); break;
                    case "user:follow": scopes.Add(GitHubScope.UserFollow); break;
                    case "public_repo": scopes.Add(GitHubScope.PublicRepo); break;
                    case "repo": scopes.Add(GitHubScope.Repo); break;
                    case "repo:status": scopes.Add(GitHubScope.RepoStatus); break;
                    case "delete_repo": scopes.Add(GitHubScope.DeleteRepo); break;
                    case "notifications": scopes.Add(GitHubScope.Notifications); break;
                    case "gist": scopes.Add(GitHubScope.Gist); break;
                    default: scopes.Add(new GitHubScope(scope)); break;
                }
            } 

            return new GitHubOAuthAccessTokenResponse {
                AccessToken = nvc["access_token"],
                Scope = scopes,
                TokenType = nvc["token_type"]
            };
        
        }

    }

}
