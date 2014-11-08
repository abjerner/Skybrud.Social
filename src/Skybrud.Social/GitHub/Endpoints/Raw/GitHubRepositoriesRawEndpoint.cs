using System;
using System.Collections.Specialized;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Endpoints.Raw {
    
    public class GitHubRepositoriesRawEndpoint {

        #region Properties

        public GitHubOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal GitHubRepositoriesRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        public string GetContents(string owner, string repository, string path) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString(
                Client.GenerateAbsoluteUrl(String.Format("/repos/{0}/{1}/contents/{2}", owner, repository, path))
            );
        }

        public SocialHttpResponse GetCommit(string owner, string repository, string sha) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/repos/" + owner + "/" + repository + "/commits/" + sha);
        }

        public SocialHttpResponse GetCommits(string owner, string repository) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/repos/" + owner + "/" + repository + "/commits");
        }

        public SocialHttpResponse GetCommits(string owner, string repository, GitHubGetCommitOptions options) {
            NameValueCollection query = new NameValueCollection();
            if (options != null) {
                if (!String.IsNullOrWhiteSpace(options.Sha)) query.Add("sha", options.Sha);
                if (!String.IsNullOrWhiteSpace(options.Path)) query.Add("path", options.Path);
                if (!String.IsNullOrWhiteSpace(options.Author)) query.Add("author", options.Author);
                if (options.Since != null) query.Add("since", options.Since.Value.ToString(SocialUtils.IsoDateFormat));
                if (options.Until != null) query.Add("until", options.Until.Value.ToString(SocialUtils.IsoDateFormat));
            }
            return Client.DoAuthenticatedGetRequest("https://api.github.com/repos/" + owner + "/" + repository + "/commits", query);
        }

        public SocialHttpResponse GetRepository(string owner, string repository) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/repos/" + owner + "/" + repository);
        }

        #endregion

    }

}
