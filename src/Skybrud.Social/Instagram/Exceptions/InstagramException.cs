using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Instagram.Exceptions {

    public class InstagramException : Exception {

        public SocialHttpResponse Response { get; private set; }
        public int Code { get; private set; }
        public string Type { get; private set; }

        internal InstagramException(SocialHttpResponse response, int code, string type, string message) : base(message) {
            Response = response;
            Code = code;
            Type = type;
        }

    }

}