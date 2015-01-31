using System;
using Skybrud.Social.BitBucket.Endpoints;
using Skybrud.Social.BitBucket.OAuth;
using Skybrud.Social.OAuth;

namespace Skybrud.Social.BitBucket {
    
    public class BitBucketService {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client used for communicating with the BitBucket API.
        /// </summary>
        public BitBucketOAuthClient Client { get; private set; }

        /// <summary>
        /// Gets a reference to the user endpoint.
        /// </summary>
        public BitBucketUserEndpoint User { get; private set; }

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        public BitBucketUsersEndpoint Users { get; private set; }

        /// <summary>
        /// Gets a reference to the repositories endpoint.
        /// </summary>
        public BitBucketRepositoriesEndpoint Repositories { get; private set; }

        #endregion

        #region Constructors

        private BitBucketService() {
            User = new BitBucketUserEndpoint(this);
            Users = new BitBucketUsersEndpoint(this);
            Repositories = new BitBucketRepositoriesEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a service reference based on the specified consumer key
        /// and consumer secret. This will create an API reference without a
        /// user context.
        /// </summary>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        public static BitBucketService CreateFromConsumerKey(string consumerKey, string consumerSecret) {
            return new BitBucketService {
                Client = new BitBucketOAuthClient(consumerKey, consumerSecret, null, null)
            };
        }

        /// <summary>
        /// Initializes a service reference based on the specified consumer key
        /// and access token.
        /// </summary>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="accessTokenSecret">The acess token secret.</param>
        public static BitBucketService CreateFromAccessToken(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret) {
            return new BitBucketService {
                Client = new BitBucketOAuthClient(consumerKey, consumerSecret, accessToken, accessTokenSecret)
            };
        }

        /// <summary>
        /// Initialize a service reference based on the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static BitBucketService CreateFromOAuthClient(OAuthClient client) {
            if (client == null) throw new ArgumentNullException("client");
            return CreateFromAccessToken(client.ConsumerKey, client.ConsumerSecret, client.Token, client.TokenSecret);
        }

        #endregion

    }

}