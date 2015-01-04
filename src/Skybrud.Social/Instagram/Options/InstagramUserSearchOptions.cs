using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options {

    public class InstagramUserSearchOptions : IGetOptions {

        public string Query { get; set; }

        public int Count { get; set; }
        
        public SocialQueryString GetQueryString() {

            SocialQueryString qs = new SocialQueryString();



            return qs;

            throw new NotImplementedException();
        }
    
    }

}
