using System;
using Skybrud.Social.BitBucket.Endpoints;
using Skybrud.Social.BitBucket.OAuth;
using Skybrud.Social.OAuth;

namespace Skybrud.Social.BitBucket {
    
    public class BitBucketService {

        /// <summary>
        /// The OAuth client used for communicating with the BitBucket API.
        /// </summary>
        public BitBucketOAuthClient Client { get; private set; }

        public BitBucketUserEndpoint User { get; private set; }

        private BitBucketService() {
            User = new BitBucketUserEndpoint(this);
        }

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
        /// Initialize a service reference based on the specified OAUth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static BitBucketService CreateFromOAuthClient(OAuthClient client) {
            if (client == null) throw new ArgumentNullException("client");
            return CreateFromAccessToken(client.ConsumerKey, client.ConsumerSecret, client.Token, client.TokenSecret);
        }

    }

}
