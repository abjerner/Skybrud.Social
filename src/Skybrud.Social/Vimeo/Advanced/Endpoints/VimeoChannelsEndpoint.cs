using System.Collections.Specialized;
using Skybrud.Social.Json;
using Skybrud.Social.Vimeo.Advanced.Endpoints.Raw;
using Skybrud.Social.Vimeo.Advanced.Enums;
using Skybrud.Social.Vimeo.Advanced.Responses;

namespace Skybrud.Social.Vimeo.Advanced.Endpoints {
  
    public class VimeoChannelsEndpoint {

        public VimeoService Service { get; private set; }

        /// <summary>
        /// The implementation of the endpoint for getting the raw server response.
        /// </summary>
        public VimeoChannelsRawEndpoint Raw {
            get { return Service.Client.Channels; }
        }

        internal VimeoChannelsEndpoint(VimeoService service) {
            Service = service;
        }

        #region Method: vimeo.channels.addVideo

        // TODO: Implement method: ??? AddVideo(string channelId, int videoId)

        #endregion

        #region Method: vimeo.channels.getAll

        public VimeoChannelsResponse GetAll() {
            return VimeoChannelsResponse.Parse(JsonConverter.ParseObject(Raw.GetAll()));
        }
        
        public VimeoChannelsResponse GetAll(string username) {
            return VimeoChannelsResponse.Parse(JsonConverter.ParseObject(Raw.GetAll(username)));
        }
        
        public VimeoChannelsResponse GetAll(string username, int page, int perPage) {
            return VimeoChannelsResponse.Parse(JsonConverter.ParseObject(Raw.GetAll(username, page, perPage)));
        }
        
        public VimeoChannelsResponse GetAll(string username, VimeoChannelsSort sort, int page, int perPage) {
            return VimeoChannelsResponse.Parse(JsonConverter.ParseObject(Raw.GetAll(username, sort, page, perPage)));
        }

        #endregion

        #region Method: vimeo.channels.getInfo

        // TODO: Implement method: ??? GetInfo(string channelId)

        #endregion

        #region Method: vimeo.channels.getModerated

        // TODO: Implement method: ??? GetModerated(string username, VimeoChannelsSort sort, int page, int perPage)

        #endregion

        #region Method: vimeo.channels.getModerators

        // TODO: Implement method: ??? GetModerators(int channelId)

        // TODO: Implement method: ??? GetModerators(int channelId, int page, int perPage)

        #endregion

        #region Method: vimeo.channels.getSubscribers

        // TODO: Implement method: ??? GetSubscribers(int channelId)

        // TODO: Implement method: ??? GetSubscribers(int channelId, int page, int perPage)

        #endregion

        #region Method: vimeo.channels.getVideos

        /// <summary>
        /// Gets the videos in the specified channel. If a channel has many videos, only a portion of these videos will
        /// be returned due to pagination.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        public VimeoVideosResponse GetVideos(int channelId) {
            return VimeoVideosResponse.Parse(JsonConverter.ParseObject(Raw.GetVideos(channelId, null, 0, 0, true, true)));
        }

        /// <summary>
        /// Gets the videos in the specified channel. If a channel has many videos, only a portion of these videos will
        /// be returned due to pagination.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <param name="page">The page to retrieve.</param>
        /// <param name="perPage">The amount of videos per page.</param>
        public VimeoVideosResponse GetVideos(int channelId, int page, int perPage) {
            return VimeoVideosResponse.Parse(JsonConverter.ParseObject(Raw.GetVideos(channelId, null, page, perPage, true, true)));
        }

        #endregion

        #region Method: vimeo.channels.removeVideo

        // TODO: Implement method: ??? RemoveVideo(string channelId, int videoId)

        #endregion

        #region Method: vimeo.channels.subscribe

        // TODO: Implement method: ??? Subscribe(string channelId)

        #endregion

        #region Method: vimeo.channels.unsubscribe

        // TODO: Implement method: ??? Unsubscribe(string channelId)

        #endregion

    }

}
