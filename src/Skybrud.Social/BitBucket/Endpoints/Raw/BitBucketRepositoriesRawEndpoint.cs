using System;
using System.Collections.Specialized;
using Skybrud.Social.BitBucket.OAuth;
using Skybrud.Social.BitBucket.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketRepositoriesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the BitBucket OAuth client.
        /// </summary>
        public BitBucketOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public BitBucketRepositoriesRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

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
        public SocialHttpResponse GetChangesets(string accountName, string repoSlug, int limit, string start) {

            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (limit > 0) query.Add("limit", limit + "");
            if (!String.IsNullOrWhiteSpace(start)) query.Add("start", start);

            // Make the call to the API
            return Client.DoHttpGetRequest("https://bitbucket.org/api/1.0/repositories/" + accountName + "/" + repoSlug + "/changesets", query);

        }

        /// <summary>
        /// Gets the commit information associated with a repository. By default, this call returns all the commits
        /// across all branches, bookmarks, and tags. The newest commit is first.
        /// </summary>
        /// <param name="accountName">The team or individual account owning the repo.</param>
        /// <param name="repoSlug">The repo identifier.</param>
        /// <param name="page">The page.</param>
        public SocialHttpResponse GetCommits(string accountName, string repoSlug, int page) {
            return GetCommits(accountName, repoSlug, new BitBucketCommitsOptions {
                Page = page
            });
        }

        /// <summary>
        /// Gets the commit information associated with a repository. By default, this call returns all the commits
        /// across all branches, bookmarks, and tags. The newest commit is first.
        /// </summary>
        /// <param name="accountName">The team or individual account owning the repo.</param>
        /// <param name="repoSlug">The repo identifier.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetCommits(string accountName, string repoSlug, BitBucketCommitsOptions options) {
            return Client.DoHttpGetRequest("https://bitbucket.org/api/2.0/repositories/" + accountName + "/" + repoSlug + "/commits", options);
        }

        /// <summary>
        /// Gets the information associated with an individual commit.
        /// </summary>
        /// <param name="accountName">The team or individual account owning the repo.</param>
        /// <param name="repoSlug">The repo identifier.</param>
        /// <param name="revision">A SHA value for the commit. You can also specify a branch name, a bookmark, or tag.
        /// If you do Bitbucket responds with the commit that the revision points. For example, if you supply a branch
        /// name this returns the branch tip (or head).</param>
        public SocialHttpResponse GetCommit(string accountName, string repoSlug, string revision) {
            return Client.DoHttpGetRequest("https://bitbucket.org/api/2.0/repositories/" + accountName + "/" + repoSlug + "/commit/" + revision);
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        public SocialHttpResponse GetRepositories(string username) {
            return GetRepositories(username, null);
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetRepositories(string username, BitBucketRepositoriesOptions options) {
            return Client.DoHttpGetRequest("https://bitbucket.org/api/2.0/repositories/" + username, options);
        }

        #endregion

    }

}