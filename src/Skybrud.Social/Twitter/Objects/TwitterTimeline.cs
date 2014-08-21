using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects {
    
    public class TwitterTimeline : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the internal JsonArray the object was created from.
        /// </summary>
        public JsonArray JsonArray { get; private set; }

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

        #endregion

        public static TwitterTimeline ParseJson(string contents) {

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

            // Cast to an array
            JsonArray array = (JsonArray) json;

            // Return the instance
            return new TwitterTimeline {
                JsonObject = obj,
                JsonArray = array,
                StatusMessages = TwitterStatusMessage.ParseMultiple(array)
            };

        }

    }

}
