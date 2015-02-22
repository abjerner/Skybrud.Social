using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.PlaylistItems {

    public class YouTubePlaylistItemList : GoogleApiResource {

        #region Properties

        public string NextPageToken { get; private set; }

        public string PrevPageToken { get; private set; }

        public YouTubePageInfo PageInfo { get; private set; }

        public YouTubePlaylistItem[] Items { get; private set; }

        #endregion

        #region Constructors

        protected YouTubePlaylistItemList(JsonObject obj) : base(obj) { }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubePlaylistItemList</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubePlaylistItemList Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubePlaylistItemList(obj) {
                NextPageToken = obj.GetString("nextPageToken"),
                PrevPageToken = obj.GetString("prevPageToken"),
                PageInfo = obj.GetObject("pageInfo", YouTubePageInfo.Parse),
                Items = obj.GetArray("items", YouTubePlaylistItem.Parse)
            };
        }

        #endregion

    }

}