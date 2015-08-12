using System.Xml.Linq;
using Skybrud.Social.LinkedIn.ExtensionMethods;

namespace Skybrud.Social.LinkedIn.Objects {
    
    public class LinkedInPersonSummary {
        
        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PictureUrl { get; private set; }
        public string Headline { get; private set; }

        public static LinkedInPersonSummary Parse(XElement xPerson) {
            return new LinkedInPersonSummary {
                Id = xPerson.GetElementValueOrDefault<string>("id"),
                FirstName = xPerson.GetElementValueOrDefault<string>("first-name"),
                LastName = xPerson.GetElementValueOrDefault<string>("last-name"),
                PictureUrl = xPerson.GetElementValueOrDefault<string>("picture-url"),
                Headline = xPerson.GetElementValueOrDefault<string>("headline")
            };
        }

    }

}