using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.Json;

namespace Skybrud.Social.Pushover {

    public class PushoverMessage {
    
        public string Title;
        public string Message;
        public string Url;
        public string UrlTitle;
        public PushoverPriority Priority;
        public PushoverSound Sound;

        public string Send(string token, string user, string device = null) {

            // Add mandatory parameters
            NameValueCollection data = new NameValueCollection {
                {"token", token},
                {"user", user},
                {"message", Message ?? ""}
            };

            // Add optional parameters
            if (!String.IsNullOrEmpty(device)) data.Add("device", device);
            if (!String.IsNullOrEmpty(Url)) data.Add("url", Url);
            if (!String.IsNullOrEmpty(UrlTitle)) data.Add("url_title", UrlTitle);
            if (!String.IsNullOrEmpty(UrlTitle)) data.Add("device", UrlTitle);
            if (Priority != PushoverPriority.Normal) data.Add("priority", (int)Priority + "");
            if (Sound != PushoverSound.Default) data.Add("sound", Sound.ToString().ToLower());

            // Make the call
            HttpWebResponse response = SocialUtils.DoHttpPostRequest("https://api.pushover.net/1/messages.json", null, data);

            // Get as JSON object
            JsonObject json = (JsonObject) response.GetAsJson();

            // Return the response body if successful
            if (response.StatusCode == HttpStatusCode.OK && json.GetInt32("status") == 1) return response.GetAsString();

            // Throw an exception with the given errors
            throw new PushoverException(response.StatusCode, json.GetArray("errors").Cast<string>());

        }
    
    }

}
