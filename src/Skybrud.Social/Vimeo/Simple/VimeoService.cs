using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Skybrud.Social.Json;
using Skybrud.Social.Vimeo.Simple.Objects;
using Skybrud.Social.Vimeo.Simple.Responses;

namespace Skybrud.Social.Vimeo.Simple {

    public class VimeoService {

        #region user channels

        public string GetUserChannelsAsRawXml(string name) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("http://vimeo.com/api/v2/" + name + "/channels.xml");
        }

        public VimeoChannelsResponse GetUserChannels(string name) {
            HttpWebResponse response = SocialUtils.DoHttpGetRequest("http://vimeo.com/api/v2/" + name + "/channels.xml");
            if (response.StatusCode == HttpStatusCode.OK) return VimeoChannelsResponse.Parse(XElement.Parse(response.GetAsString()));
            throw new VimeoException(response.GetAsString());
        }

        #endregion

        #region Channel info

        public string GetChannelInfoAsRawXml(string name) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("http://vimeo.com/api/v2/channel/" + name + "/info.xml");
        }

        public VimeoChannel GetChannelInfo(int id) {
            return GetChannelInfo(id + "");
        }

        public VimeoChannel GetChannelInfo(string name) {
            HttpWebResponse response = SocialUtils.DoHttpGetRequest("http://vimeo.com/api/v2/channel/" + name + "/info.xml");
            if (response.StatusCode == HttpStatusCode.OK) return VimeoChannel.ParseMultiple(XElement.Parse(response.GetAsString())).FirstOrDefault();
            throw new VimeoException(response.GetAsString());
        }

        #endregion

        #region Channel videos

        public string GetChannelVideosAsRawXml(int id, int page) {
            return GetChannelVideosAsRawXml(id + "", page);
        }
        
        public string GetChannelVideosAsRawXml(string id, int page) {
            NameValueCollection query = new NameValueCollection();
            if (page > 0) query.Set("page", page + "");
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("http://vimeo.com/api/v2/channel/" + id + "/videos.xml", query);
        }

        public string GetChannelVideosAsRawJson(int id, int page) {
            return GetChannelVideosAsRawJson(id + "", page);
        }
        
        public string GetChannelVideosAsRawJson(string id, int page) {
            NameValueCollection query = new NameValueCollection();
            if (page > 0) query.Set("page", page + "");
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("http://vimeo.com/api/v2/channel/" + id + "/videos.json", query);
        }

        /// <summary>
        /// Get a list of channel videos.
        /// </summary>
        /// <param name="id">The ID of the channel.</param>
        public VimeoChannelVideosResponse GetChannelVideos(int id) {
            return GetChannelVideos(id + "", 0);
        }

        /// <summary>
        /// Get a list of channel videos.
        /// </summary>
        /// <param name="id">The ID of the channel.</param>
        /// <param name="page">The Simple API only allows to browse pages 1 through 3.</param>
        public VimeoChannelVideosResponse GetChannelVideos(int id, int page) {
            return GetChannelVideos(id + "", page);
        }

        /// <summary>
        /// Get a list of channel videos.
        /// </summary>
        /// <param name="id">The ID of the channel.</param>
        public VimeoChannelVideosResponse GetChannelVideos(string id) {
            return GetChannelVideos(id, 0);
        }

        /// <summary>
        /// Get a list of channel videos.
        /// </summary>
        /// <param name="id">The ID of the channel.</param>
        /// <param name="page">The Simple API only allows to browse pages 1 through 3.</param>
        public VimeoChannelVideosResponse GetChannelVideos(string id, int page) {
            NameValueCollection query = new NameValueCollection();
            if (page > 0) query.Set("page", page + "");
            HttpWebResponse response = SocialUtils.DoHttpGetRequest("http://vimeo.com/api/v2/channel/" + id + "/videos.json", query);
            if (response.StatusCode == HttpStatusCode.OK) return VimeoChannelVideosResponse.Parse(JsonConverter.ParseArray(response.GetAsString()));
            string str = response.GetAsString();
            Match match = Regex.Match(str, "<section id=\"exception_msg\" class=\"block\">(.+?)</section>", RegexOptions.Singleline);
            throw new VimeoException(match.Success ? match.Groups[1].Value.Trim() : str);
        }

        #endregion

    }

}
