using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects {
    
    public class TwitterUserTimeline {

        /// <summary>
        /// Gets the raw JSON response from the Twitter API.
        /// </summary>
        public string Raw { get; private set; }

        /// <summary>
        /// Gets the status messages of the timeline.
        /// </summary>
        public TwitterStatusMessage[] StatusMessages { get; private set; }

        /// <summary>
        /// Gets the status messages of the timeline.
        /// </summary>
        public TwitterStatusMessage[] Tweets {
            get { return StatusMessages; }
        }

        /// <summary>
        /// Gets the amount of status messages in the scope for the timeline.
        /// </summary>
        public int Count {
            get { return StatusMessages.Length; }
        }

        public static TwitterUserTimeline ParseJson(string contents) {

            // Deserialize the JSON
            IJsonObject json = JsonConverter.Parse(contents);

            // Can there be multiple errors? Need. More. Data.
            JsonObject obj = json as JsonObject;
            if (obj != null) {
                JsonArray errors = obj.GetArray("errors");
                throw new TwitterException(
                    errors.GetObject(0).GetInt("code"),
                    errors.GetObject(0).GetString("message")
                );
            }

            // Parse the tweets
            IEnumerable<TwitterStatusMessage> tweets = TwitterStatusMessage.ParseMultiple(json as JsonArray);

            // Return the instance
            return new TwitterUserTimeline {
                Raw = contents, StatusMessages = tweets.ToArray()
            };

        }

    }

}
