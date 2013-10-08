using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Objects;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterStatusesEndpoint {

        /// <summary>
        /// A reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public TwitterStatusesRawEndpoint Raw {
            get { return Service.Client.Statuses; }
        }

        internal TwitterStatusesEndpoint(TwitterService service) {
            Service = service;
        }

        public TwitterStatusMessage Show(long statusId, TwitterStatusMessageOptions options = null) {
            return TwitterStatusMessage.ParseJson(Raw.GetTweet(statusId, options));
        }

        public TwitterUserTimeline UserTimeline(long userId, int count) {
            return TwitterUserTimeline.ParseJson(Raw.GetUserTimeline(userId, new TwitterUserTimelineOptions(count)));
        }

        public TwitterUserTimeline UserTimeline(long userId, TwitterUserTimelineOptions options = null) {
            return TwitterUserTimeline.ParseJson(Raw.GetUserTimeline(userId, options));
        }

        public TwitterUserTimeline UserTimeline(string screenName, int count) {
            return TwitterUserTimeline.ParseJson(Raw.GetUserTimeline(screenName, new TwitterUserTimelineOptions(count)));
        }

        public TwitterUserTimeline UserTimeline(string screenName, TwitterUserTimelineOptions options = null) {
            return TwitterUserTimeline.ParseJson(Raw.GetUserTimeline(screenName, options));
        }

    }

}
