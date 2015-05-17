using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.BitBucket.Options;
using Skybrud.Social.BitBucket.Responses;
using Skybrud.Social.BitBucket.Responses.Repositories;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Endpoints {
    
    /// <summary>
    /// Class representing the repositories endpoint in the BitBucket API.
    /// </summary>
    public class BitBucketRepositoriesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the BitBucket service.
        /// </summary>
        public BitBucketService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw repositories endpoint.
        /// </summary>
        public BitBucketRepositoriesRawEndpoint Raw {
            get { return Service.Client.Repositories; }
        }

        #endregion
        
        #region Constructors

        internal BitBucketRepositoriesEndpoint(BitBucketService service) {
            Service = service;
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
        public BitBucketChangesetsResponse GetChangesets(string accountName, string repoSlug, int limit = 0, string start = null) {

            // Get the raw data from the API
            string contents = Raw.GetChangesets(accountName, repoSlug, limit, start).Body;

            // Parse the JSON
            return BitBucketChangesetsResponse.ParseJson(contents);
        
        }

        /// <summary>
        /// Gets the commit information associated with a repository. By default, this call returns all the commits
        /// across all branches, bookmarks, and tags. The newest commit is first.
        /// </summary>
        /// <param name="accountName">The team or individual account owning the repo.</param>
        /// <param name="repoSlug">The repo identifier.</param>
        /// <param name="page">The page.</param>
        public BitBucketCommitsResponse GetCommits(string accountName, string repoSlug, int page = 0) {
            return BitBucketCommitsResponse.ParseResponse(Raw.GetCommits(accountName, repoSlug, page));
        }

        /// <summary>
        /// Gets the commit information associated with a repository. By default, this call returns all the commits
        /// across all branches, bookmarks, and tags. The newest commit is first.
        /// </summary>
        /// <param name="accountName">The team or individual account owning the repo.</param>
        /// <param name="repoSlug">The repo identifier.</param>
        /// <param name="options">The options for the call to the API.</param>
        public BitBucketCommitsResponse GetCommits(string accountName, string repoSlug, BitBucketCommitsOptions options) {
            return BitBucketCommitsResponse.ParseResponse(Raw.GetCommits(accountName, repoSlug, options));
        }

        /// <summary>
        /// Gets the information associated with an individual commit.
        /// </summary>
        /// <param name="accountName">The team or individual account owning the repo.</param>
        /// <param name="repoSlug">The repo identifier.</param>
        /// <param name="revision">A SHA value for the commit. You can also specify a branch name, a bookmark, or tag.
        /// If you do Bitbucket responds with the commit that the revision points. For example, if you supply a branch
        /// name this returns the branch tip (or head).</param>
        public BitBucketCommit GetCommit(string accountName, string repoSlug, string revision) {

            // Get the raw data from the API
            string contents = Raw.GetCommit(accountName, repoSlug, revision).Body;

            // Parse the JSON
            return JsonObject.ParseJson(contents, BitBucketCommit.Parse);

        }

        /// <summary>
        /// Gets a list of repositories of the with the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        public BitBucketRepositoriesResponse GetRepositories(string username) {
            return BitBucketRepositoriesResponse.ParseResponse(Raw.GetRepositories(username));
        }

        /// <summary>
        /// Gets a list of repositories of the with the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public BitBucketRepositoriesResponse GetRepositories(string username, BitBucketRepositoriesOptions options) {
            return BitBucketRepositoriesResponse.ParseResponse(Raw.GetRepositories(username, options));
        }

        #endregion

    }

}