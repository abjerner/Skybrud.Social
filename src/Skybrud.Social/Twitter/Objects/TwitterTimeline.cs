using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects {
    
    public class TwitterTimeline : SocialJsonArray {

        #region Properties

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
        
        #region Constructors

        private TwitterTimeline(JsonArray array) : base(array) { }

        #endregion

        public static TwitterTimeline ParseJson(string contents) {

            // Deserialize the JSON
            IJsonObject json = JsonConverter.Parse(contents);

            // Cast to an array
            JsonArray array = (JsonArray) json;

            // Return the instance
            return new TwitterTimeline(array) {
                StatusMessages = array.ParseMultiple(TwitterStatusMessage.Parse)
            };

        }

    }

}