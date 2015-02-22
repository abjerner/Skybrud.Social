using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists/list</cref>
    /// </see>
    public class YouTubePlaylistList : GoogleApiResource {

        #region Properties

        public string NextPageToken { get; private set; }

        public string PrevPageToken { get; private set; }

        public YouTubePageInfo PageInfo { get; private set; }

        public YouTubePlaylist[] Items { get; private set; }

        #endregion

        #region Constructors

        protected YouTubePlaylistList(JsonObject obj) : base(obj) { }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubePlaylistList</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubePlaylistList Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubePlaylistList(obj) {
                NextPageToken = obj.GetString("nextPageToken"),
                PrevPageToken = obj.GetString("prevPageToken"),
                PageInfo = obj.GetObject("pageInfo", YouTubePageInfo.Parse),
                Items = obj.GetArray("items", YouTubePlaylist.Parse)
            };
        }

        #endregion

    }

}