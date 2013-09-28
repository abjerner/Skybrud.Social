using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.BitBucket.OAuth;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketRepositoriesRawEndpoint {

        public BitBucketOAuthClient Client { get; private set; }

        public BitBucketRepositoriesRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }

        /// <summary>
        /// Gets a list of change sets associated with a repository. By default, this call returns the 15 most recent
        /// changesets. It also returns the count which is the total number of changesets on the repository. Private
        /// repositories require the caller to authenticate.
        /// </summary>
        /// <param name="accountName">The team or individual account owning the repo.</param>
        /// <param name="repoSlug">The repo identifier.</param>
        /// <param name="limit">An integer representing how many changesets to return. You can specify a limit between
        /// 0 and 50. If you specify 0 (zero), the system returns the <code>count</code> but returns empty values for
        /// the remaining fields.</param>
        /// <param name="start">A hash value representing the earliest node to start with. The system starts with the
        /// specified node and includes the older requests that preceded it. The Bitbucket GUI lists the nodes on the
        /// <b>Commit</b> tab. The default <code>start</code> value is the tip.</param>
        public string GetChangesets(string accountName, string repoSlug, int limit = 0, string start = null) {

            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (limit > 0) query.Add("limit", limit + "");
            if (!String.IsNullOrWhiteSpace(start)) query.Add("start", start);

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://bitbucket.org/api/1.0/repositories/" + accountName + "/" + repoSlug + "/changesets", query);

        }

        /// <summary>
        /// Gets the commit information associated with a repository. By default, this call returns all the commits
        /// across all branches, bookmarks, and tags. The newest commit is first.
        /// </summary>
        /// <param name="accountName">The team or individual account owning the repo.</param>
        /// <param name="repoSlug">The repo identifier.</param>
        public string GetCommits(string accountName, string repoSlug) {

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://bitbucket.org/api/2.0/repositories/" + accountName + "/" + repoSlug + "/commits");

        }

    }

}
