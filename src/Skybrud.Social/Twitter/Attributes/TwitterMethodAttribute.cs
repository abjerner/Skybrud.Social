using System;
using Skybrud.Social.Twitter.Enums;

namespace Skybrud.Social.Twitter.Attributes {
    
    public class TwitterMethodAttribute : Attribute {

        public readonly bool IsRateLimited;
        public readonly TwitterAuthentication Authentication;
        public readonly string RequestRate;

        public TwitterMethodAttribute(bool rateLimited = false, string rate = "none", TwitterAuthentication authentication = TwitterAuthentication.None) {
            IsRateLimited = rateLimited;
            Authentication = authentication;
            RequestRate = rate;
        }

    }

}