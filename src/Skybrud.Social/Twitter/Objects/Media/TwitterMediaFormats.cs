using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects.Media {
    
    /// <summary>
    /// Class representing a collection of formats of a given media.
    /// </summary>
    public class TwitterMediaFormats : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets a reference to the <code>small</code> media format.
        /// </summary>
        public TwitterMediaFormat Small { get; private set; }
        
        /// <summary>
        /// Gets a reference to the <code>thumb</code> media format.
        /// </summary>
        public TwitterMediaFormat Thumb { get; private set; }
        
        /// <summary>
        /// Gets a reference to the <code>medium</code> media format.
        /// </summary>
        public TwitterMediaFormat Medium { get; private set; }
        
        /// <summary>
        /// Gets a reference to the <code>large</code> media format.
        /// </summary>
        public TwitterMediaFormat Large { get; private set; }

        #endregion

        #region Constructors

        private TwitterMediaFormats(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>TwitterMediaFormats</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static TwitterMediaFormats Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterMediaFormats(obj) {
                Small = GetMediaFormatByAlias(obj, "small"),
                Thumb = GetMediaFormatByAlias(obj, "thumb"),
                Medium = GetMediaFormatByAlias(obj, "medium"),
                Large = GetMediaFormatByAlias(obj, "large")
            };
        }

        private static TwitterMediaFormat GetMediaFormatByAlias(JsonObject parent, string alias) {
            return parent.GetObject(alias, x => TwitterMediaFormat.Parse(alias, x));
        }

        #endregion

    }

}