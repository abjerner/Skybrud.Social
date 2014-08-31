using System;
using System.Xml.Linq;

namespace Skybrud.Social.Twitter {

    [Obsolete("Use class TwitterOAuthClient instead.")]
    public class TwitterAccessInformation {
    
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }

        [Obsolete("Use 'AccessTokenSecret' instead")]
        public string AccessSecret {
            get { return AccessTokenSecret; }
            set { AccessTokenSecret = value; }
        }

        public static TwitterAccessInformation ParseXml(XElement xml) {
            if (xml == null) return new TwitterAccessInformation();
            return new TwitterAccessInformation {
                ConsumerKey = SocialUtils.GetElementValue<string>(xml, "ConsumerKey"),
                ConsumerSecret = SocialUtils.GetElementValue<string>(xml, "ConsumerSecret"),
                AccessToken = SocialUtils.GetElementValue<string>(xml, "AccessToken"),
                AccessTokenSecret = SocialUtils.GetElementValue<string>(xml, "AccessTokenSecret") ?? SocialUtils.GetElementValue<string>(xml, "AccessSecret")
            };
        }
    
    }

}
