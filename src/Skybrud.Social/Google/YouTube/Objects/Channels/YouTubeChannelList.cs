using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Channels {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/channels/list</cref>
    /// </see>
    public class YouTubeChannelList : GoogleApiResource {

        #region Properties

        public YouTubePageInfo PageInfo { get; private set; }

        public YouTubeChannel[] Items { get; private set; }

        #endregion

        #region Constructors

        protected YouTubeChannelList(JsonObject obj) : base(obj) { }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeChannelList</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubeChannelList Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeChannelList(obj) {
                PageInfo = obj.GetObject("pageInfo", YouTubePageInfo.Parse),
                Items = obj.GetArray("items", YouTubeChannel.Parse)
            };
        }

        #endregion

    }

}