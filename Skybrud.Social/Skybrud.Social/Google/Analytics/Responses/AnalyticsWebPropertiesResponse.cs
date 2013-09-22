using Skybrud.Social.Google.Analytics.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Responses {

    public class AnalyticsWebPropertiesResponse {
        
        public string Username { get; private set; }
        public int TotalResults { get; private set; }
        public int StartIndex { get; private set; }
        public int ItemsPerPage { get; private set; }
        public AnalyticsWebProperty[] Items { get; private set; }
        public AnalyticsWebProperty[] WebProperties {
            get { return Items; }
        }

        private AnalyticsWebPropertiesResponse() {
            // make constructor private
        }

        public static AnalyticsWebPropertiesResponse ParseJson(string json) {
            return Parse(JsonConverter.ParseObject(json));
        }

        public static AnalyticsWebPropertiesResponse Parse(JsonObject obj) {
            
            // TODO: Check for any errors

            return new AnalyticsWebPropertiesResponse {
                Username = obj.GetString("username"),
                TotalResults = obj.GetInt("totalResults"),
                StartIndex = obj.GetInt("startIndex"),
                ItemsPerPage = obj.GetInt("itemsPerPage"),
                Items = obj.GetArray("items", AnalyticsWebProperty.Parse)
            };

        }

    }

}