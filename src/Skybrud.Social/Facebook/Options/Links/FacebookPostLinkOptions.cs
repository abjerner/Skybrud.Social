using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Facebook.Options.Links {

    public class FacebookPostLinkOptions : IPostOptions {

        public string Link { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }

        public SocialQueryString GetQueryString() {
            return new SocialQueryString();
        }

        public bool IsMultipart {
            get { return false; }
        }

        public SocialPostData GetPostData() {
            SocialPostData postData = new SocialPostData();
            if (!String.IsNullOrWhiteSpace(Link)) postData.Add("link", Link);
            if (!String.IsNullOrWhiteSpace(Description)) postData.Add("description", Description);
            if (!String.IsNullOrWhiteSpace(Message)) postData.Add("message", Message);
            if (!String.IsNullOrWhiteSpace(Name)) postData.Add("name", Name);
            if (!String.IsNullOrWhiteSpace(Caption)) postData.Add("caption", Caption);
            return postData;
        }
    
    }

}
