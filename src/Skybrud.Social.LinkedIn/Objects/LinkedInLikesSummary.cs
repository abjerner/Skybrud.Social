using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Skybrud.Social.LinkedIn.ExtensionMethods;

namespace Skybrud.Social.LinkedIn.Objects {
    
    public class LinkedInLikesSummary {
        
        public int Total { get; private set; }
        public LinkedInPersonSummary[] Persons { get; private set; }

        public static LinkedInLikesSummary Parse(XElement xLikes) {
            return new LinkedInLikesSummary {
                Total = xLikes.GetAttributeValueOrDefault<int>("total"),
                Persons = (
                    from xPerson in xLikes.XPathSelectElements("like/person")
                    select LinkedInPersonSummary.Parse(xPerson)
                ).ToArray()
            };
        }

    }

}