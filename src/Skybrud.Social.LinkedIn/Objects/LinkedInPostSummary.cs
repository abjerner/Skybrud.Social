using System;
using System.Xml.Linq;
using System.Xml.XPath;
using Skybrud.Social.LinkedIn.ExtensionMethods;
using Skybrud.Social.LinkedIn.Objects;

namespace Skybrud.Social.LinkedIn {
    
    public class LinkedInPostSummary {
        
        public string Id { get; private set; }
        public string Type { get; private set; }
        public string Url { get; private set; }
        public DateTime Created { get; private set; }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public LinkedInPersonSummary Creator { get; private set; }
        public LinkedInLikesSummary Likes { get; private set; }

        public static LinkedInPostSummary Parse(XElement xPost) {

            // Get the timestamp and divide by 1000 (milliseconds to seconds)
            double timestamp = xPost.GetElementValueOrDefault<long>("creation-timestamp") / 1000.00;

            // Get the type of the post (post or news)
            XElement xTypeCode = xPost.XPathSelectElement("type/code");
            
            return new LinkedInPostSummary {
                Id = xPost.GetElementValueOrDefault<string>("id"),
                Type = xTypeCode == null ? null : xTypeCode.Value,
                Url = xPost.GetElementValueOrDefault<string>("site-group-post-url"),
                Created = SocialUtils.GetDateTimeFromUnixTime(timestamp),
                Title = xPost.GetElementValueOrDefault<string>("title"),
                Summary = xPost.GetElementValueOrDefault<string>("summary"),
                Creator = LinkedInPersonSummary.Parse(xPost.Element("creator")),
                Likes = LinkedInLikesSummary.Parse(xPost.Element("likes"))
            };
        
        }

    }

}