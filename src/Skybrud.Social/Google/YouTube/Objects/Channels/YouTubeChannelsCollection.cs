using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Channels {

    public class YouTubeChannelsCollection : GoogleApiResource {

        #region Properties

        public YouTubePageInfo PageInfo { get; private set; }

        public YouTubeChannel[] Items { get; private set; }

        #endregion

        #region Constructors

        protected YouTubeChannelsCollection(JsonObject obj) : base(obj) { }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeChannelsCollection</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubeChannelsCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeChannelsCollection(obj) {
                PageInfo = obj.GetObject("pageInfo", YouTubePageInfo.Parse),
                Items = obj.GetArray("items", YouTubeChannel.Parse)
            };
        }

        #endregion

    }

}