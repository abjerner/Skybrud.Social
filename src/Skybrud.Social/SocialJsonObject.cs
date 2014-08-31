using Skybrud.Social.Json;

namespace Skybrud.Social {

    public abstract class SocialJsonObject {

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; protected set; }
    }

}
