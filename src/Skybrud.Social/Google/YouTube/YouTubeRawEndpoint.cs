using System;
using System.Collections.Specialized;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube.Objects.Channel;
using Skybrud.Social.Google.YouTube.Objects.Playlist;
using Skybrud.Social.Google.YouTube.Objects.PlaylistItem;
using Skybrud.Social.Google.YouTube.Objects.Videos;

namespace Skybrud.Social.Google.YouTube {
    
    public class YouTubeRawEndpoint {

        public GoogleOAuthClient Client { get; private set; }

        public YouTubeRawEndpoint(GoogleOAuthClient client) {
            Client = client;
        }

        public string GetVideoDetails(string id) {

            NameValueCollection query = new NameValueCollection();
            query.Add("id", id);
            query.Add("part", "snippet,contentDetails,fileDetails,player,processingDetails,recordingDetails,statistics,status,suggestions,topicDetails");
            query.Add("access_token", Client.AccessToken);

            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://www.googleapis.com/youtube/v3/videos", query);

        }

        public string GetMyChannels(YouTubeChannelPart part) {
            return GetMyChannels(new YouTubeChannelPartsCollection(part));
        }

        public string GetMyChannels(YouTubeChannelPartsCollection parts) {

            NameValueCollection query = new NameValueCollection();
            query.Add("part", parts.ToString());
            query.Add("mine", "true");
            query.Add("access_token", Client.AccessToken);

            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://www.googleapis.com/youtube/v3/channels", query);

        }

        #region Playlists

        public string GetMyPlaylists() {
            return GetMyPlaylists(YouTubePlaylistPart.Id + YouTubePlaylistPart.Snippet + YouTubePlaylistPart.Status);
        }

        public string GetMyPlaylists(YouTubePlaylistPartsCollection parts) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://www.googleapis.com/youtube/v3/playlists", new NameValueCollection {
                {"part", parts.ToString()},
                {"mine", "true"},
                {"access_token", Client.AccessToken}
            });
        }

        public string GetPlaylistsFromChannel(string channelId) {
            return GetPlaylistsFromChannel(channelId, YouTubePlaylistPart.Id + YouTubePlaylistPart.Snippet + YouTubePlaylistPart.Status);
        }

        public string GetPlaylistsFromChannel(string channelId, YouTubePlaylistPartsCollection parts) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://www.googleapis.com/youtube/v3/playlists", new NameValueCollection {
                {"part", parts.ToString()},
                {"channelId", channelId},
                {"access_token", Client.AccessToken}
            });
        }

        public string GetPlaylistsFromIds(params string[] playlistIds) {
            return GetPlaylistsFromIds(playlistIds, YouTubePlaylistPart.Id + YouTubePlaylistPart.Snippet + YouTubePlaylistPart.Status);
        }

        public string GetPlaylistsFromIds(string[] playlistIds, YouTubePlaylistPartsCollection parts) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://www.googleapis.com/youtube/v3/playlists", new NameValueCollection {
                {"part", parts.ToString()},
                {"id", String.Join(",", playlistIds)},
                {"access_token", Client.AccessToken}
            });
        }

        #endregion

        #region Playlist item

        public string GetPlaylistItems(YouTubePlaylistItemOptions options) {

            // Initialize the query
            NameValueCollection query = new NameValueCollection {
                {"part", "id,snippet,contentDetails,status"},
                {"access_token", Client.AccessToken}
            };

            // Optional parameters
            if (options != null) {
                if (!String.IsNullOrWhiteSpace(options.Id)) query.Add("id", options.Id);
                if (options.MaxResults > 0) query.Add("maxResults", options.MaxResults + "");
                if (!String.IsNullOrWhiteSpace(options.PageToken)) query.Add("pageToken", options.PageToken);
                if (!String.IsNullOrWhiteSpace(options.PlaylistId)) query.Add("playlistId", options.PlaylistId);
                if (!String.IsNullOrWhiteSpace(options.VideoId)) query.Add("videoId", options.VideoId);
            }

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://www.googleapis.com/youtube/v3/playlistItems", query);

        }

        #endregion

        #region Videos

        public string ListVideos(YouTubeVideoOptions options) {

            // Initialize the query
            NameValueCollection query = new NameValueCollection {
                {"part", "id,snippet,contentDetails,fileDetails,liveStreamingDetails,player,processingDetails,recordingDetails,statistics,status,suggestions,topicDetails"},
                {"access_token", Client.AccessToken}
            };

            // Optional parameters
            if (options != null) {
                if (options.Ids != null && options.Ids.Length > 0) query.Add("id", String.Join(",", options.Ids));
                if (options.MaxResults > 0) query.Add("maxResults", options.MaxResults + "");
                if (!String.IsNullOrWhiteSpace(options.PageToken)) query.Add("pageToken", options.PageToken);
            }

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://www.googleapis.com/youtube/v3/videos", query);

        }

        #endregion

    }

}