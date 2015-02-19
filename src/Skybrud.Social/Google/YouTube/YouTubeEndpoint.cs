using System.Linq;
using Skybrud.Social.Google.YouTube.Endpoints;
using Skybrud.Social.Google.YouTube.Objects.Playlist;
using Skybrud.Social.Google.YouTube.Objects.PlaylistItem;
using Skybrud.Social.Google.YouTube.Objects.Videos;
using Skybrud.Social.Google.YouTube.Responses;

namespace Skybrud.Social.Google.YouTube {

    public class YouTubeEndpoint {

        #region Private fields

        private YouTubeChannelsEndpoint _channels;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the parent service of this endpoint.
        /// </summary>
        public GoogleService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw YouTube endpoint.
        /// </summary>
        public YouTubeRawEndpoint Raw {
            get { return Service.Client.YouTube; }
        }

        /// <summary>
        /// Gets a reference to the channels endpoint.
        /// </summary>
        public YouTubeChannelsEndpoint Channels {
            get { return _channels ?? (_channels = new YouTubeChannelsEndpoint(this)); }
        }

        #endregion

        internal YouTubeEndpoint(GoogleService service) {
            Service = service;
        }

        #region Member methods

        #region Playlists

        /// <summary>
        /// Gets the playlist with the specified ID.
        /// </summary>
        public YouTubePlaylist GetPlaylist(string playlistId) {
            return YouTubePlaylistListResponse.ParseJson(Raw.GetPlaylistsFromIds(playlistId)).Items.FirstOrDefault();
        }

        public YouTubePlaylistListResponse GetPlaylist2(string playlistId) {
            return YouTubePlaylistListResponse.ParseJson(Raw.GetPlaylistsFromIds(playlistId));
        }

        /// <summary>
        /// Gets a list of playlists owned by the authenticated user.
        /// </summary>
        public YouTubePlaylistListResponse GetMyPlaylists() {
            return YouTubePlaylistListResponse.ParseJson(Raw.GetMyPlaylists());
        }

        /// <summary>
        /// Gets a list of playlists in the specified channel.
        /// </summary>
        /// <param name="channelId">The ID of the parent channel.</param>
        public YouTubePlaylistListResponse GetPlaylistsFromChannel(string channelId) {
            return YouTubePlaylistListResponse.ParseJson(Raw.GetPlaylistsFromChannel(channelId));
        }

        #endregion

        #region Playlist item

        public YouTubePlaylistItemListResponse GetPlaylistItems(string playlistId) {
            return GetPlaylistItems(new YouTubePlaylistItemOptions {
                PlaylistId = playlistId
            });
        }

        public YouTubePlaylistItemListResponse GetPlaylistItems(YouTubePlaylistItemOptions options) {
            return YouTubePlaylistItemListResponse.ParseJson(Raw.GetPlaylistItems(options));
        }

        #endregion

        #region Videos

        /// <summary>
        /// Gets video information for the specified YouTube IDs. It seems that the API will return
        /// a "forbidden" error if more than five videos are requsted per call.
        /// </summary>
        /// <param name="videoIds">The IDs of the videos.</param>
        public YouTubeVideoListResponse ListVideos(string[] videoIds) {
            return YouTubeVideoListResponse.ParseJson(Raw.ListVideos(new YouTubeVideoOptions {
                Ids = videoIds
            }));
        }

        /// <summary>
        /// Gets a list of videos from the sepcified <var>options</var>.
        /// </summary>
        /// <param name="options">The options specifying the query.</param>
        public YouTubeVideoListResponse ListVideos(YouTubeVideoOptions options) {
            return YouTubeVideoListResponse.ParseJson(Raw.ListVideos(options));
        }

        #endregion

        #endregion

    }

}