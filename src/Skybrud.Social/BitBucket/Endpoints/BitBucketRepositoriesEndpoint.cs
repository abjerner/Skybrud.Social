using System.Net;
using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.BitBucket.Exceptions;
using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.BitBucket.Responses;

namespace Skybrud.Social.BitBucket.Endpoints {
    
    public class BitBucketRepositoriesEndpoint {

        public BitBucketService Service { get; private set; }

        /// <summary>
        /// The implementation of the endpoint for getting the raw server response.
        /// </summary>
        public BitBucketRepositoriesRawEndpoint Raw {
            get { return Service.Client.Repositories; }
        }

        internal BitBucketRepositoriesEndpoint(BitBucketService service) {
            Service = service;
        }

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
        public BitBucketChangesetsResponse GetChangesets(string accountName, string repoSlug, int limit = 0, string start = null) {
            
            HttpStatusCode status;

            // Get the raw data from the API
            string contents = Raw.GetChangesets(accountName, repoSlug, limit, start, out status);

            // Validate the response
            if (status != HttpStatusCode.OK) {
                throw new BitBucketHttpException(status);
            }

            // Parse the JSON
            return BitBucketChangesetsResponse.ParseJson(contents);
        
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
        public BitBucketCommitsResponse GetCommits(string accountName, string repoSlug, int page = 0) {

            HttpStatusCode status;

            // Get the raw data from the API
            string contents = Raw.GetCommits(accountName, repoSlug, page, out status);

            // Validate the response
            if (status != HttpStatusCode.OK) {
                throw new BitBucketHttpException(status);
            }

            // Parse the JSON
            return BitBucketCommitsResponse.ParseJson(contents);

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
        public BitBucketCommit GetCommit(string accountName, string repoSlug, string revision) {

            HttpStatusCode status;

            // Get the raw data from the API
            string contents = Raw.GetCommit(accountName, repoSlug, revision, out status);

            // Validate the response
            if (status != HttpStatusCode.OK) {
                throw new BitBucketHttpException(status);
            }

            // Parse the JSON
            return BitBucketCommit.ParseJson(contents);

        }

        #endregion

    }

}
