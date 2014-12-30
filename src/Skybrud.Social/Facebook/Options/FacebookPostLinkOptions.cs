using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Options {

    public class FacebookPostLinkOptions : IFacebookPostOptions {

        public string Link { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }

        public SocialQueryString GetQueryString() {
            return new SocialQueryString();
        }

        public SocialQueryString GetPostData() {
            SocialQueryString query = new SocialQueryString();
            if (!String.IsNullOrWhiteSpace(Link)) query.Add("link", Link);
            if (!String.IsNullOrWhiteSpace(Description)) query.Add("description", Description);
            if (!String.IsNullOrWhiteSpace(Message)) query.Add("message", Message);
            if (!String.IsNullOrWhiteSpace(Name)) query.Add("name", Name);
            if (!String.IsNullOrWhiteSpace(Caption)) query.Add("caption", Caption);
            return query;
        }
    
    }

}
