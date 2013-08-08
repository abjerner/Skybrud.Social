using System;
using System.Collections.Specialized;
using Skybrud.Social.Json;
using Skybrud.Social.Vimeo.Advanced.Enums;
using Skybrud.Social.Vimeo.Advanced.Responses;

namespace Skybrud.Social.Vimeo.Advanced.Endpoints.Raw {
    
    public class VimeoChannelsRawEndpoint {

        public VimeoOAuthClient Client { get; private set; }

        public VimeoChannelsRawEndpoint(VimeoOAuthClient client) {
            Client = client;
        }

        #region Method: vimeo.channels.addVideo

        /// <summary>
        /// Adds a video to a channel and returns the raw JSON response from the server.
        /// 
        /// API description: Add a video to a channel. This method requires a token with write permission.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        /// <param name="videoId">The ID of the video.</param>
        public string AddVideo(string channelId, int videoId) {
            return Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.addVideo"},
                {"channel_id", channelId},
                {"video_id", videoId + ""}
            }, null);
        }

        #endregion
        
        #region Method: vimeo.channels.getAll

        public string GetAll() {
            return GetAll(null, 0, 0);
        }

        public string GetAll(string username) {
            return GetAll(username, 0, 0);
        }

        /// <summary>
        /// Gets the raw JSON response for the channels on the specified page.
        /// </summary>
        /// <param name="username">The username or user ID behind a user. </param>
        /// <param name="page">The page number to show.</param>
        /// <param name="perPage">Number of items to show on each page. Max 50.</param>
        /// <returns></returns>
        public string GetAll(string username, int page, int perPage) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.getAll"}
            };

            // Add optional parameters
            if (!String.IsNullOrEmpty(username)) query.Add("user_id", username);
            if (page > 0) query.Add("page", page + "");
            if (perPage > 0) query.Add("per_page", perPage + "");

            // Call the Vimeo API
            return Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        public string GetAll(string username, VimeoChannelsSort sort, int page, int perPage) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.getAll"}
            };

            // Add optional parameters
            if (!String.IsNullOrEmpty(username)) query.Add("user_id", username);
            if (sort != VimeoChannelsSort.Default) query.Add("sort", SocialUtils.CamelCaseToUnderscore(sort));
            if (page > 0) query.Add("page", page + "");
            if (perPage > 0) query.Add("per_page", perPage + "");

            // Call the Vimeo API
            return Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

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
            return Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

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
        public string GetModerated(string username, VimeoChannelsSort sort, int page, int perPage) {

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
            return Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        #endregion

        #region Method: vimeo.channels.getModerators

        /// <summary>
        /// API description: Get a list of the channel's moderators.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        public string GetModerators(int channelId) {
            return GetModerators(channelId, 0, 0);
        }

        /// <summary>
        /// API description: Get a list of the channel's moderators.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        /// <param name="page">The page number to show.</param>
        /// <param name="perPage">Number of items to show on each page. Max 50.</param>
        public string GetModerators(int channelId, int page, int perPage) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.getModerators"},
                {"channel_id", channelId + ""}
            };

            if (page > 0) query.Add("page", page + "");
            if (perPage > 0) query.Add("per_page", perPage + "");

            // Call the Vimeo API
            return Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        #endregion

        #region Method: vimeo.channels.getSubscribers

        /// <summary>
        /// API description: Get a list of the channel's subscribers.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        public string GetSubscribers(int channelId) {
            return GetSubscribers(channelId, 0, 0);
        }

        /// <summary>
        /// API description: Get a list of the channel's subscribers.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        /// <param name="page">The page number to show.</param>
        /// <param name="perPage">Number of items to show on each page. Max 50.</param>
        public string GetSubscribers(int channelId, int page, int perPage) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.getSubscribers"},
                {"channel_id", channelId + ""}
            };

            if (page > 0) query.Add("page", page + "");
            if (perPage > 0) query.Add("per_page", perPage + "");

            // Call the Vimeo API
            return Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        #endregion

        #region Method: vimeo.channels.getVideos

        /// <summary>
        /// API description: Get a list of the videos in a channel.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        public string GetVideos(int channelId) {
            return GetVideos(channelId, 0, 0);
        }

        /// <summary>
        /// API description: Get a list of the videos in a channel.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        /// <param name="page">The page number to show.</param>
        /// <param name="perPage">Number of items to show on each page. Max 50.</param>
        public string GetVideos(int channelId, int page, int perPage) {
            return GetVideos(channelId, null, page, perPage, false, false);
        }

        public string GetVideos(int channelId, string username, int page, int perPage, bool summaryResponse, bool fullResponse) {

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
            return Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);

        }

        #endregion

        #region Method: vimeo.channels.removeVideo

        /// <summary>
        /// API description: Remove a video from a channel. This method requires a token with write permission.
        /// </summary>
        /// <param name="channelId">The numeric id of the channel or its url name.</param>
        /// <param name="videoId">The ID of the video.</param>
        public string RemoveVideo(string channelId, int videoId) {
            return Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", new NameValueCollection {
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
        public string Subscribe(string channelId) {
            return Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", new NameValueCollection {
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
        public string Unsubscribe(string channelId) {
            return Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.channels.unsubscribe"},
                {"channel_id", channelId}
            }, null);
        }

        #endregion


    }

}
