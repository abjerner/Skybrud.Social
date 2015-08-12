using System;
using System.Linq;
using System.Xml.Linq;
using Skybrud.Social.LinkedIn.Exceptions;
using Skybrud.Social.LinkedIn.ExtensionMethods;

namespace Skybrud.Social.LinkedIn.Responses {
    
    public class LinkedInPostsResponse {

        public XElement XElement { get; private set; }
        
        public int Total { get; private set; }
        public int Count { get; private set; }
        public int Start { get; private set; }
        public LinkedInPostSummary[] Posts { get; private set; }

        public void SaveXml(string path) {
            XElement.Save(path);
        }

        public static LinkedInPostsResponse ParseXml(string xml) {
            return Parse(XElement.Parse(xml));
        }

        public static LinkedInPostsResponse Parse(XElement xElement) {

            // Check for null reference
            if (xElement == null) throw new ArgumentNullException("xElement");

            // Check for errors
            if (xElement.Name.LocalName == "error") {
                throw new LinkedInApiException(xElement);
            }
            
            // Parse the response object
            return new LinkedInPostsResponse {
                XElement = xElement,
                Total = xElement.GetAttributeValueOrDefault<int>("total"),
                Count = xElement.GetAttributeValueOrDefault<int>("count"),
                Start = xElement.GetAttributeValueOrDefault<int>("start"),
                Posts = (
                    from xPost in xElement.Elements("post")
                    select LinkedInPostSummary.Parse(xPost)
                ).ToArray()
            };

        }

        public static LinkedInPostsResponse LoadXml(string path) {
            return Parse(XElement.Load(path));
        }
    
    }

}