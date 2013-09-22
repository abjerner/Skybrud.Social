using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsAccount {
        
        public string Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }

        private AnalyticsAccount() {
            // make constructor private
        }

        public static AnalyticsAccount Parse(JsonObject obj) {
            return new AnalyticsAccount {
                Id = obj.GetString("id"),
                Name = obj.GetString("name"),
                Created = obj.GetDateTime("created"),
                Updated = obj.GetDateTime("updated")
            };
        }

    }

}
