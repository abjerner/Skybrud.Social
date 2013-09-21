using System;
using System.Collections.Specialized;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {
    
    public class InstagramTagsEndpoint {

        protected InstagramService Service;

        internal InstagramTagsEndpoint(InstagramService service) {
            Service = service;
        }

        public string GetTagInfoAsRawJson(string tag) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection {
                { "access_token", Service.AccessToken },
            };

            // Perform the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/tags/" + tag, qs);

        }

        public InstagramTagResponse GetTagInfo(string name) {
            return InstagramTagResponse.ParseJson(GetTagInfoAsRawJson(name));
        }

        public string GetRecentMediaAsRawJson(string tag, string minId = null, string maxId = null) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection {
                { "access_token", Service.AccessToken },
            };
            if (!String.IsNullOrWhiteSpace(minId)) qs.Add("min_id", minId);
            if (!String.IsNullOrWhiteSpace(maxId)) qs.Add("max_id", maxId);

            // Perform the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/tags/" + tag + "/media/recent/", qs);

        }

        public InstagramRecentMediaResponse GetRecentMedia(string name, string minId = null, string maxId = null) {
            return InstagramRecentMediaResponse.ParseJson(GetRecentMediaAsRawJson(name, minId, maxId));
        }
    
    }

}
