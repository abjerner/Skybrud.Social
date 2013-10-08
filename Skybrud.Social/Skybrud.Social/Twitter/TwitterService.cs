using System;
using Skybrud.Social.Twitter.Endpoints;
using Skybrud.Social.Twitter.OAuth;

namespace Skybrud.Social.Twitter {

    public class TwitterService {

        public TwitterOAuthClient Client { get; private set; }

        internal TwitterAccessInformation Info { get; private set; }

        public TwitterAccountEndpoint Account { get; private set; }
        public TwitterGeoEndpoint Geo { get; private set; }
        public TwitterStatusesEndpoint Statuses { get; private set; }
        public TwitterUsersEndpoint Users { get; private set; }

        private TwitterService() {
            // make constructor private
        }

        public static TwitterService GetFromAccessInformation(TwitterAccessInformation info) {

            // This should never be null
            if (info == null) throw new ArgumentNullException("info");

            // Initialize the service
            TwitterService service = new TwitterService {
                Info = info,
                Client = new TwitterOAuthClient {
                    ConsumerKey = info.ConsumerKey,
                    ConsumerSecret = info.ConsumerSecret,
                    Token = info.AccessToken,
                    TokenSecret = info.AccessTokenSecret
                }
            };

            // Set the endpoints etc.
            service.Account = new TwitterAccountEndpoint(service);
            service.Geo = new TwitterGeoEndpoint(service);
            service.Statuses = new TwitterStatusesEndpoint(service);
            service.Users = new TwitterUsersEndpoint(service);

            // Return the service
            return service;

        }

    }

}
