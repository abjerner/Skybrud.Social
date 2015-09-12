using System;
using System.Collections.Specialized;
using System.Net;
using System.Web;

namespace Skybrud.Social.Pushover {

    public class PushoverService {

        public static string SendMessage(string token, string user, string message) {

            WebClient wc = new WebClient();

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("token", token);
            nvc.Add("user", user);
            nvc.Add("message", message);

            string data = String.Join("&", Array.ConvertAll(nvc.AllKeys, key => String.Format("{0}={1}", SocialUtils.UrlEncode(key), SocialUtils.UrlEncode(nvc[key]))));

            //throw new Exception(data);

            return wc.UploadString("https://api.pushover.net/1/messages.json", data);

        }

    }

}
