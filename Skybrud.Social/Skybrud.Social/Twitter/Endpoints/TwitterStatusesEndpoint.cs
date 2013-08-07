using Skybrud.Social.Twitter.Objects;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterStatusesEndpoint {

        protected TwitterService Service;

        internal TwitterStatusesEndpoint(TwitterService service) {
            Service = service;
        }

        public TwitterStatusMessage Show(long statusId, TwitterStatusMessageOptions options = null) {
            return TwitterStatusMessage.ParseJson(Service.RestApi.GetTweetAsRawJson(statusId, options));
        }

        public TwitterUserTimeline UserTimeline(long userId, int count) {



            return TwitterUserTimeline.ParseJson(Service.RestApi.GetUserTimelineAsRawJson(userId, new TwitterUserTimelineOptions(count)));
        }

        public TwitterUserTimeline UserTimeline(long userId, TwitterUserTimelineOptions options = null) {
            return TwitterUserTimeline.ParseJson(Service.RestApi.GetUserTimelineAsRawJson(userId, options));
        }

        public TwitterUserTimeline UserTimeline(string screenName, int count) {
            return TwitterUserTimeline.ParseJson(Service.RestApi.GetUserTimelineAsRawJson(screenName, new TwitterUserTimelineOptions(count)));
        }

        public TwitterUserTimeline UserTimeline(string screenName, TwitterUserTimelineOptions options = null) {
            return TwitterUserTimeline.ParseJson(Service.RestApi.GetUserTimelineAsRawJson(screenName, options));
        }

    }

}
