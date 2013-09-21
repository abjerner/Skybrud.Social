using System;

namespace Skybrud.Social.GitHub.Endpoints {
    
    public class GitHubRepositoriesEndpoint {

        protected GitHubService Service;

        internal GitHubRepositoriesEndpoint(GitHubService service) {
            Service = service;
        }

        public string GetContentsAsRawJson(string owner, string repository, string path) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString(
                Service.GenerateAbsoluteUrl(String.Format("/repos/{0}/{1}/contents/{2}", owner, repository, path))
            );
        }


        public string GetRespositoriesAsRawJson(string username) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString(
                Service.GenerateAbsoluteUrl("/" + (username == null ? "user" : "users/" + username) + "/repos")
            );
        }
    
    }

}
