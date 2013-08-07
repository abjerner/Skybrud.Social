using System;
using Skybrud.Social.OAuth;
using Skybrud.Social.Vimeo.Advanced.Endpoints;

namespace Skybrud.Social.Vimeo.Advanced {
    
    public class VimeoService {

        /// <summary>
        /// The OAuth client used for communicating with the Vimeo Advanced API.
        /// </summary>
        public VimeoOAuthClient Client { get; private set; }

        public VimeoChannelsEndpoint Channels { get; private set; }
        public VimeoPeopleEndpoint People { get; private set; }
        public VimeoTestEndpoint Test { get; private set; }
        public VimeoVideosEndpoint Videos { get; private set; }

        private VimeoService() {
            Channels = new VimeoChannelsEndpoint(this);
            People = new VimeoPeopleEndpoint(this);
            Test = new VimeoTestEndpoint(this);
            Videos = new VimeoVideosEndpoint(this);
        }

        /// <summary>
        /// Initializes a service reference based on the specified consumer key
        /// and consumer secret. This will create an API reference without a
        /// user context.
        /// </summary>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        public static VimeoService CreateFromConsumerKey(string consumerKey, string consumerSecret) {
            return new VimeoService {
                Client = new VimeoOAuthClient(consumerKey, consumerSecret, null, null)
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
        public static VimeoService CreateFromAccessToken(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret) {
            return new VimeoService {
                Client = new VimeoOAuthClient(consumerKey, consumerSecret, accessToken, accessTokenSecret)
            };
        }

        /// <summary>
        /// Initialize a service reference based on the specified OAUth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static VimeoService CreateFromOAuthClient(OAuthClient client) {
            if (client == null) throw new ArgumentNullException("client");
            return CreateFromAccessToken(client.ConsumerKey, client.ConsumerSecret, client.Token, client.TokenSecret);
        } 

    }

}
