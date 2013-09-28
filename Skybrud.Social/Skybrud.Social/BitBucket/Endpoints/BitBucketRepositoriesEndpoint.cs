using Skybrud.Social.BitBucket.Endpoints.Raw;
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
            return BitBucketChangesetsResponse.ParseJson(Raw.GetChangesets(accountName, repoSlug, limit, start));
        }

    }

}
