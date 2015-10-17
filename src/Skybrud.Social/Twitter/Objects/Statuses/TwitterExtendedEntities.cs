using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Entities;

namespace Skybrud.Social.Twitter.Objects.Statuses {
    
    /// <summary>
    /// Class representing the extended entities property of a status message.
    /// </summary>
    public class TwitterExtendedEntities : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets an array of all media mentioned in the parent status message.
        /// </summary>
        public TwitterMediaEntity[] Media { get; private set; }

        #endregion

        #region Constructors

        private TwitterExtendedEntities(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>TwitterExtendedEntities</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static TwitterExtendedEntities Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterExtendedEntities(obj) {
                Media = obj.GetArray("media", TwitterMediaEntity.Parse)
            };
        }

        #endregion

    }

}