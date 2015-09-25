using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Skybrud.Social.LinkedIn.Exceptions;
using Skybrud.Social.LinkedIn.ExtensionMethods;

namespace Skybrud.Social.LinkedIn.Responses
{
    public class LinkedInBasicProfileResponse {

        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Headline { get; private set; }
        public int NumConnections { get; private set; }
        public bool NumConnectionsCapped { get; private set; }
        public string Summary { get; private set; }
        public string PictureUrl { get; private set; }
        public string PublicProfileUrl { get; private set; }

        public static LinkedInBasicProfileResponse ParseXml(string xml) {
            return Parse(XElement.Parse(xml));
        }

        public static LinkedInBasicProfileResponse Parse(XElement xPerson) {
            return new LinkedInBasicProfileResponse {
                Id = xPerson.GetElementValueOrDefault<string>("id"),
                FirstName = xPerson.GetElementValueOrDefault<string>("first-name"),
                LastName = xPerson.GetElementValueOrDefault<string>("last-name"),

                Headline = xPerson.GetElementValueOrDefault<string>("headline"),
                NumConnections = xPerson.GetElementValueOrDefault<int>("num-connections"),
                NumConnectionsCapped = xPerson.GetElementValueOrDefault<bool>("num-connections-capped"),
                Summary = xPerson.GetElementValueOrDefault<string>("summary"),
                
                PictureUrl = xPerson.GetElementValueOrDefault<string>("picture-url"),
                PublicProfileUrl = xPerson.GetElementValueOrDefault<string>("public-profile-url")
            };
        }
    }
}
