using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsProfile {
        
        public string Id { get; private set; }
        public string AccountId { get; private set; }
        public string WebPropertyId { get; private set; }
        public string InternalWebPropertyId { get; private set; }
        public string Name { get; private set; }
        public string Currency { get; private set; }
        public string Timezone { get; private set; }
        public string WebsiteUrl { get; private set; }
        public string Type { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }

        private AnalyticsProfile() {
            // make constructor private
        }

        public static AnalyticsProfile Parse(JsonObject obj) {
            return new AnalyticsProfile {
                Id = obj.GetString("id"),
                AccountId = obj.GetString("accountId"),
                WebPropertyId = obj.GetString("webPropertyId"),
                InternalWebPropertyId = obj.GetString("internalWebPropertyId"),
                Name = obj.GetString("name"),
                Currency = obj.GetString("currency"),
                Timezone = obj.GetString("timezone"),
                WebsiteUrl = obj.GetString("websiteUrl"),
                Type = obj.GetString("type"),
                Created = obj.GetDateTime("created"),
                Updated = obj.GetDateTime("updated")
            };
        }

    }

}
