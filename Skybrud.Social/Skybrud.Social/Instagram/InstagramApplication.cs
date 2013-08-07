using System;

namespace Skybrud.Social.Instagram {
    
    public class InstagramApplication {
        
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string WebsiteUrl { get; set; }
        public string RedirectUri { get; set; }

        public string GetUserLoginUrl() {
            return GetUserLoginUrl(Guid.NewGuid().ToString(), InstagramScope.Basic);
        }

        public string GetUserLoginUrl(string state, InstagramScope scope) {
            return InstagramService.GetAuthorizeUrl(ClientId, RedirectUri, scope.ToString().ToLower().Replace(" ", ""), state);
        }

        public string GetAuthorizeUrl() {
            return GetAuthorizeUrl(Guid.NewGuid().ToString(), InstagramScope.Basic);
        }

        public string GetAuthorizeUrl(string state, InstagramScope scope) {
            return InstagramService.GetAuthorizeUrl(ClientId, RedirectUri, scope.ToString().ToLower().Replace(" ", ""), state);
        }

        public InstagramService GetServiceFromAuthCode(string authCode) {
            return InstagramService.CreateFromAuthCode(ClientId, ClientSecret, RedirectUri, authCode);
        }

    }

}
