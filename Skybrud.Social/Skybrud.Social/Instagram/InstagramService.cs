using System;
using System.Collections.Specialized;
using System.Web;
using Skybrud.Social.Instagram.Endpoints;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Responses;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram {
    public class InstagramService {

        public string AccessToken { get; set; }
        public InstagramUser CurrentUser { get; set; }

        public InstagramEndpoints Endpoints { get; private set; }

        private InstagramService() {
            Endpoints = new InstagramEndpoints(this);
        }

        #region Initializers

        [Obsolete("Use CreateFromAuthCode instead")]
        public static InstagramService CreateFromCode(string clientId, string clientSecret, string redirectUri, string code) {
            return CreateFromAuthCode(clientId, clientSecret, redirectUri, code);
        }

        public static InstagramService CreateFromAuthCode(string clientId, string clientSecret, string redirectUri, string code) {

            NameValueCollection parameters = new NameValueCollection {
                {"client_id", clientId},
                {"client_secret", clientSecret},
                {"grant_type", "authorization_code"},
                {"redirect_uri", redirectUri},
                {"code", code }
            };

            JsonObject obj = SocialUtils.DoHttpPostRequestAndGetBodyAsJsonObject("https://api.instagram.com/oauth/access_token", null, parameters);

            if (obj.HasValue("access_token")) {
                return new InstagramService {
                    AccessToken = obj.GetString("access_token"),
                    CurrentUser = obj.GetObject("user", InstagramUser.Parse)
                };
            }

            if (obj.HasValue("error_message")) {
                throw new Exception(obj.GetString("error_message"));
            }

            throw new Exception("An unknown error occured");

        }

        public static InstagramService TryCreateFromCode(string clientId, string clientSecret, string redirectUri, string code) {
            try {
                return CreateFromAuthCode(clientId, clientSecret, redirectUri, code);
            } catch (Exception) {
                return null;
            }
        }

        public static InstagramService CreateFromAccessToken(string accessToken) {

            // Make the call to the API
            JsonObject obj = SocialUtils.DoHttpGetRequestAndGetBodyAsJsonObject("https://api.instagram.com/v1/users/self/?access_token=" + accessToken);

            // Validate the response
            InstagramResponse.ValidateResponse(obj);

            // Some validation
            return new InstagramService {
                AccessToken = accessToken,
                CurrentUser = obj.GetObject("data", InstagramUser.Parse)
            };

        }

        public static InstagramService TryCreateFromAccessToken(string accessToken) {
            try {
                return CreateFromAccessToken(accessToken);
            } catch (Exception) {
                return null;
            }
        }

        #endregion
        
        public static string GetAuthorizeUrl(string clientId, string redirectUri) {
            return GetAuthorizeUrl(clientId, redirectUri, "basic");
        }

        public static string GetAuthorizeUrl(string clientId, string redirectUri, string scope) {
            return String.Format(
                "https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=code&scope={2}",
                HttpUtility.UrlEncode(clientId),
                HttpUtility.UrlEncode(redirectUri),
                HttpUtility.UrlEncode(scope)
            );
        }

        public static string GetAuthorizeUrl(string clientId, string redirectUri, string scope, string state) {
            return String.Format(
                "https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}",
                HttpUtility.UrlEncode(clientId),
                HttpUtility.UrlEncode(redirectUri),
                HttpUtility.UrlEncode(scope),
                HttpUtility.UrlEncode(state)
            );
        }

    }

    /*public static class HttpHelpersInternal {

        public static string Get(string url) {
            try {
                WebClient client = new WebClient();
                return client.DownloadString(url);
            } catch (WebException ex) {
                var stream = ex.Response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }

        public static dynamic GetJson(string url) {

            string response = Get(url);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.RegisterConverters(new JavaScriptConverter[] { new DynamicJsonConverter() });

            return jss.Deserialize(response, typeof(object));

        }

        public static string Post(string url, NameValueCollection parameters) {
            try {
                WebClient client = new WebClient();
                var result = client.UploadValues(url, "POST", parameters);
                return Encoding.UTF8.GetString(result);
            } catch (WebException ex) {
                var stream = ex.Response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }

        public static dynamic PostJson(string url, NameValueCollection parameters) {

            string response = Post(url, parameters);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.RegisterConverters(new JavaScriptConverter[] { new DynamicJsonConverter() });

            return jss.Deserialize(response, typeof(object));

        }

    }*/

}