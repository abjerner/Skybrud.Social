using System;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Entities;

namespace Skybrud.Social.Twitter.Objects {

    public class TwitterStatusMessage : SocialJsonObject, ISocialTimelineEntry {

        #region Properties

        /// <summary>
        /// The ID of the tweet.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// The ID of the tweet as a string.
        /// </summary>
        public string IdStr { get; private set; }

        /// <summary>
        /// The date and time for when the tweet was created in UTC/GMT.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// The text or message of the tweet.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// The source/client used for making the tweet.
        /// </summary>
        public string Source { get; private set; }
        public bool IsTruncated { get; private set; }

        public TwitterReplyTo InReplyTo { get; private set; }

        public int Retweets { get; private set; }

        /// <summary>
        /// Gets whether the current user has favorited the tweet.
        /// </summary>
        public bool Favorited { get; private set; }
        
        /// <summary>
        /// Gets whether the current user has retweeted the tweet.
        /// </summary>
        public bool Retweeted { get; private set; }

        public TwitterStatusMessageEntities Entities { get; private set; }

        public TwitterContributor[] Contributors { get; private set; }
        public TwitterCoordinates Coordinates { get; private set; }
        public TwitterPlace Place { get; private set; }

        /// <summary>
        /// Information about the user who made the tweet. May be <code>NULL</code>.
        /// </summary>
        public TwitterUser User { get; private set; }

        public DateTime SortDate {
            get { return CreatedAt; }
        }

        #endregion

        #region Constructor(s)

        private TwitterStatusMessage(JsonObject obj) : base(obj) {
            // Hide default constructor
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a status message (tweet) from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static TwitterStatusMessage LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a status message (tweet) from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static TwitterStatusMessage ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets a status message (tweet) from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static TwitterStatusMessage Parse(JsonObject obj) {

            // Error checking
            if (obj == null) return null;
            if (obj.HasValue("error")) throw TwitterException.Parse(obj.GetArray("error"));
            if (obj.HasValue("errors")) throw TwitterException.Parse(obj.GetArray("errors"));

            TwitterStatusMessage msg = new TwitterStatusMessage(obj) {
                Id = obj.GetInt64("id"),
                IdStr = obj.GetString("id_str"),
                Text = obj.GetString("text"),
                Source = obj.GetString("source"),
                IsTruncated = obj.GetBoolean("truncated")
            };

            // Twitter has some strange date formats
            msg.CreatedAt = TwitterUtils.ParseDateTimeUtc(obj.GetString("created_at"));

            // Parse the reply information
            if (obj.HasValue("in_reply_to_status_id")) {
                msg.InReplyTo = new TwitterReplyTo {
                    StatusId = obj.GetInt64("in_reply_to_status_id"),
                    StatusIdStr = obj.GetString("in_reply_to_status_id_str"),
                    UserId = obj.GetInt64("in_reply_to_user_id"),
                    UserIdStr = obj.GetString("in_reply_to_user_id_str"),
                    ScreenName = obj.GetString("in_reply_to_screen_name")
                };
            }

            msg.Retweets = obj.GetInt32("retweet_count");

            // Related to the authenticating user
            msg.Favorited = obj.GetBoolean("favorited");
            msg.Retweeted = obj.GetBoolean("retweeted");

            // Parse the entities (if any)
            msg.Entities = TwitterStatusMessageEntities.Parse(obj.GetObject("entities"));

            // For some weird reason Twitter flips the coordinates by writing longitude before latitude
            // See: https://dev.twitter.com/docs/platform-objects/tweets#obj-coordinates)
            msg.Coordinates = TwitterCoordinates.Parse(obj.GetObject("coordinates"));

            // See: https://dev.twitter.com/docs/platform-objects/tweets#obj-contributors
            /*if (tweet.contributors != null) {
                List<TwitterContributor> contributors = new List<TwitterContributor>();
                foreach (dynamic contributor in tweet.contributors) {
                    contributors.Add(new TwitterContributor {
                        UserId = contributor.id,
                        ScreenName = contributor.screen_name
                    });
                }
                msg.Contributors = contributors.ToArray();
            }*/

            msg.User = obj.GetObject("user", TwitterUser.Parse);
            msg.Place = obj.GetObject("place", TwitterPlace.Parse);

            return msg;

        }

        #endregion

    }

}
