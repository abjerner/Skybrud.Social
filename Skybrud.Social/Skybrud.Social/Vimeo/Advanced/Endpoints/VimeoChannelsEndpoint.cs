using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Skybrud.Social.Json;
using Skybrud.Social.Vimeo.Advanced.Enums;
using Skybrud.Social.Vimeo.Advanced.Responses;

namespace Skybrud.Social.Vimeo.Advanced.Endpoints {
  
    public class VimeoChannelsEndpoint {

        public VimeoService Service { get; private set; }

        internal VimeoChannelsEndpoint(VimeoService service) {
            Service = service;
        }

        #region Method: vimeo.channels.addVideo

        /// <summary>
        /// API description: Add a video to a channel. This method requires a token with write permission.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        /// <param name="videoId">The ID of the video.</param>
        public string AddVideoAsRawJson(string channelId, int videoId) {
            return Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.addVideo"},
                {"channel_id", channelId},
                {"video_id", videoId + ""}
            }, null);
        }

        #endregion

        #region Method: vimeo.channels.getAll

        public string GetAllAsRawJson() {
            return GetAllAsRawJson(null, 0, 0);
        }

        public string GetAllAsRawJson(string username) {
            return GetAllAsRawJson(username, 0, 0);
        }

        /// <summary>
        /// Gets the raw JSON response for the channels on the specified page.
        /// </summary>
        /// <param name="username">The username or user ID behind a user. </param>
        /// <param name="page">The page number to show.</param>
        /// <param name="perPage">Number of items to show on each page. Max 50.</param>
        /// <returns></returns>
        public string GetAllAsRawJson(string username, int page, int perPage) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.getAll"}
            };

            if (!String.IsNullOrEmpty(username)) query.Add("user_id", username);
            if (page > 0) query.Add("page", page + "");
            if (perPage > 0) query.Add("per_page", perPage + "");

            // Call the Vimeo API
            return Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        public string GetAllAsRawJson(string username, VimeoChannelsSort sort, int page, int perPage) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.getAll"}
            };

            if (!String.IsNullOrEmpty(username)) query.Add("user_id", username);
            if (sort != VimeoChannelsSort.Default) query.Add("sort", SocialUtils.CamelCaseToUnderscore(sort));
            if (page > 0) query.Add("page", page + "");
            if (perPage > 0) query.Add("per_page", perPage + "");

            // Call the Vimeo API
            return Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        #endregion

        #region Method: vimeo.channels.getInfo

        /// <summary>
        /// API description: Get the information on a single channel.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        public string GetInfoAsRawJson(string channelId) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.getInfo"},
                {"channel_id", channelId}
            };

            // Call the Vimeo API
            return Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        #endregion

        #region Method: vimeo.channels.getModerated

        /// <summary>
        /// API description: Get a list of the channels that a user moderates.
        /// </summary>
        /// <param name="username">The username or user ID behind a user. </param>
        /// <param name="sort">How the response should be sorted.</param>
        /// <param name="page">The page number to show.</param>
        /// <param name="perPage">Number of items to show on each page. Max 50.</param>
        public string GetModeratedAsRawJson(string username, VimeoChannelsSort sort, int page, int perPage) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.getModerated"}
            };

            if (!String.IsNullOrEmpty(username)) query.Add("user_id", username);
            if (sort != VimeoChannelsSort.Default) query.Add("sort", SocialUtils.CamelCaseToUnderscore(sort));
            if (page > 0) query.Add("page", page + "");
            if (perPage > 0) query.Add("per_page", perPage + "");

            // Call the Vimeo API
            return Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        #endregion

        #region Method: vimeo.channels.getModerators

        /// <summary>
        /// API description: Get a list of the channel's moderators.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        public string GetModeratorsAsRawJson(int channelId) {
            return GetModeratorsAsRawJson(channelId, 0, 0);
        }

        /// <summary>
        /// API description: Get a list of the channel's moderators.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        /// <param name="page">The page number to show.</param>
        /// <param name="perPage">Number of items to show on each page. Max 50.</param>
        public string GetModeratorsAsRawJson(int channelId, int page, int perPage) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.getModerators"},
                {"channel_id", channelId + ""}
            };

            if (page > 0) query.Add("page", page + "");
            if (perPage > 0) query.Add("per_page", perPage + "");

            // Call the Vimeo API
            return Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        #endregion

        #region Method: vimeo.channels.getSubscribers

        /// <summary>
        /// API description: Get a list of the channel's subscribers.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        public string GetSubscribersAsRawJson(int channelId) {
            return GetModeratorsAsRawJson(channelId, 0, 0);
        }

        /// <summary>
        /// API description: Get a list of the channel's subscribers.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        /// <param name="page">The page number to show.</param>
        /// <param name="perPage">Number of items to show on each page. Max 50.</param>
        public string GetSubscribersAsRawJson(int channelId, int page, int perPage) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.getSubscribers"},
                {"channel_id", channelId + ""}
            };

            if (page > 0) query.Add("page", page + "");
            if (perPage > 0) query.Add("per_page", perPage + "");

            // Call the Vimeo API
            return Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        #endregion

        #region Method: vimeo.channels.getVideos

        /// <summary>
        /// API description: Get a list of the videos in a channel.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        public string GetVideosAsRawJson(int channelId) {
            return GetVideosAsRawJson(channelId, 0, 0);
        }

        /// <summary>
        /// API description: Get a list of the videos in a channel.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        /// <param name="page">The page number to show.</param>
        /// <param name="perPage">Number of items to show on each page. Max 50.</param>
        public string GetVideosAsRawJson(int channelId, int page, int perPage) {
            return GetVideosAsRawJson(channelId, null, page, perPage, false, false);
        }

        public string GetVideosAsRawJson(int channelId, string username, int page, int perPage, bool summaryResponse, bool fullResponse) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.getVideos"},
                {"channel_id", channelId + ""}
            };

            if (!String.IsNullOrEmpty(username)) query.Add("user_id", username);
            if (page > 0) query.Add("page", page + "");
            if (perPage > 0) query.Add("per_page", perPage + "");
            if (summaryResponse) query.Add("summary_response", "1");
            if (fullResponse) query.Add("full_response", "1");

            // Call the Vimeo API
            return Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        public VimeoVideosResponse GetVideos(int channelId) {
            return VimeoVideosResponse.Parse(JsonConverter.ParseObject(GetVideosAsRawJson(channelId, null, 0, 0, true, true)));
        }

        public VimeoVideosResponse GetVideos(int channelId, int page, int perPage) {
            return VimeoVideosResponse.Parse(JsonConverter.ParseObject(GetVideosAsRawJson(channelId, null, page, perPage, true, true)));
        }

        #endregion

        #region Method: vimeo.channels.removeVideo

        /// <summary>
        /// API description: Remove a video from a channel. This method requires a token with write permission.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        /// <param name="videoId">The ID of the video.</param>
        public string RemoveVideoAsRawJson(string channelId, int videoId) {
            return Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.removeVideo"},
                {"channel_id", channelId},
                {"video_id", videoId + ""}
            }, null);
        }

        #endregion

        #region Method: vimeo.channels.subscribe

        /// <summary>
        /// API description: Subscribe a user to a channel. This method requires a token with write permission.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        public string SubscribeAsRawJson(string channelId) {
            return Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.subscribe"},
                {"channel_id", channelId}
            }, null);
        }

        #endregion

        #region Method: vimeo.channels.unsubscribe

        /// <summary>
        /// API description: Unsubscribe a user from a channel. This method requires a token with write permission.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        public string UnsubscribeAsRawJson(string channelId) {
            return Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.unsubscribe"},
                {"channel_id", channelId}
            }, null);
        }

        #endregion

    }

}
