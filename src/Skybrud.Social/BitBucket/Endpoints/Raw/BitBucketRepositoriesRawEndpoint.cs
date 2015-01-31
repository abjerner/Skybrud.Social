using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.BitBucket.OAuth;

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

        #region GetChangesets

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
            HttpStatusCode statusCode;
            return GetChangesets(accountName, repoSlug, limit, start, out statusCode);
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
        /// <param name="statusCode">The status code of the request.</param>
        public string GetChangesets(string accountName, string repoSlug, int limit, string start, out HttpStatusCode statusCode) {

            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (limit > 0) query.Add("limit", limit + "");
            if (!String.IsNullOrWhiteSpace(start)) query.Add("start", start);

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://bitbucket.org/api/1.0/repositories/" + accountName + "/" + repoSlug + "/changesets", query, null, out statusCode);

        }

        #endregion

        #region GetCommits

        /// <summary>
        /// Gets the commit information associated with a repository. By default, this call returns all the commits
        /// across all branches, bookmarks, and tags. The newest commit is first.
        /// </summary>
        /// <param name="accountName">The team or individual account owning the repo.</param>
        /// <param name="repoSlug">The repo identifier.</param>
        /// <param name="page">The page.</param>
        public string GetCommits(string accountName, string repoSlug, int page = 0) {
            HttpStatusCode statusCode;
            return GetCommits(accountName, repoSlug, page, out statusCode);
        }

        /// <summary>
        /// Gets the commit information associated with a repository. By default, this call returns all the commits
        /// across all branches, bookmarks, and tags. The newest commit is first.
        /// </summary>
        /// <param name="accountName">The team or individual account owning the repo.</param>
        /// <param name="repoSlug">The repo identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="statusCode">The status code of the request.</param>
        public string GetCommits(string accountName, string repoSlug, int page, out HttpStatusCode statusCode) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection();
            if (page > 0) query.Add("page", page + "");

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://bitbucket.org/api/2.0/repositories/" + accountName + "/" + repoSlug + "/commits", query, null, out statusCode);

        }

        #endregion

        #region GetCommit

        /// <summary>
        /// Gets the information associated with an individual commit.
        /// </summary>
        /// <param name="accountName">The team or individual account owning the repo.</param>
        /// <param name="repoSlug">The repo identifier.</param>
        /// <param name="revision">A SHA value for the commit. You can also specify a branch name, a bookmark, or tag.
        /// If you do Bitbucket responds with the commit that the revision points. For example, if you supply a branch
        /// name this returns the branch tip (or head).</param>
        public string GetCommit(string accountName, string repoSlug, string revision) {

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://bitbucket.org/api/2.0/repositories/" + accountName + "/" + repoSlug + "/commit/" + revision);

        }

        /// <summary>
        /// Gets the information associated with an individual commit.
        /// </summary>
        /// <param name="accountName">The team or individual account owning the repo.</param>
        /// <param name="repoSlug">The repo identifier.</param>
        /// <param name="revision">A SHA value for the commit. You can also specify a branch name, a bookmark, or tag.
        /// If you do Bitbucket responds with the commit that the revision points. For example, if you supply a branch
        /// name this returns the branch tip (or head).</param>
        /// <param name="statusCode">The status code of the request.</param>
        public string GetCommit(string accountName, string repoSlug, string revision, out HttpStatusCode statusCode) {

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://bitbucket.org/api/2.0/repositories/" + accountName + "/" + repoSlug + "/commit/" + revision, null, null, out statusCode);

        }

        #endregion

        #endregion

    }

}