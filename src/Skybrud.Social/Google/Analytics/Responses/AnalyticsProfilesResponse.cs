using Skybrud.Social.Google.Analytics.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Responses {

    public class AnalyticsProfilesResponse {
        
        public string Username { get; private set; }
        
        public int TotalResults { get; private set; }
        
        public int StartIndex { get; private set; }
        
        public int ItemsPerPage { get; private set; }
        
        public AnalyticsProfile[] Items { get; private set; }
        
        public AnalyticsProfile[] Profiles {
            get { return Items; }
        }

        private AnalyticsProfilesResponse() {
            // make constructor private
        }

        public static AnalyticsProfilesResponse ParseJson(string json) {
            return Parse(JsonConverter.ParseObject(json));
        }

        public static AnalyticsProfilesResponse Parse(JsonObject obj) {
            
            // TODO: Check for any errors

            return new AnalyticsProfilesResponse {
                Username = obj.GetString("username"),
                TotalResults = obj.GetInt("totalResults"),
                StartIndex = obj.GetInt("startIndex"),
                ItemsPerPage = obj.GetInt("itemsPerPage"),
                Items = obj.GetArray("items", AnalyticsProfile.Parse)
            };

        }

    }

}