using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsWebProperty {
        
        public string Id { get; private set; }
        public string AccountId { get; private set; }
        public string InternalWebPropertyId { get; private set; }
        public string Name { get; private set; }
        public string WebsiteUrl { get; private set; }
        public string Level { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }

        private AnalyticsWebProperty() {
            // make constructor private
        }

        public static AnalyticsWebProperty Parse(JsonObject obj) {
            return new AnalyticsWebProperty {
                Id = obj.GetString("id"),
                AccountId = obj.GetString("accountId"),
                InternalWebPropertyId = obj.GetString("internalWebPropertyId"),
                Name = obj.GetString("name"),
                WebsiteUrl = obj.GetString("websiteUrl"),
                Level = obj.GetString("level"),
                Created = obj.GetDateTime("created"),
                Updated = obj.GetDateTime("updated")
            };
        }

    }

}
