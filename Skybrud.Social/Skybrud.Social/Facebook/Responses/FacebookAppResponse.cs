using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {

    public class FacebookAppResponse {

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public string SubCategory { get; private set; }
        public string Link { get; private set; }
        public string Namespace { get; private set; }
        public string IconUrl { get; private set; }
        public string LogoUrl { get; private set; }
        public int? DailyActiveUsers { get; private set; }
        public int? WeeklyActiveUsers { get; private set; }
        public int? MonthlyActiveUsers { get; private set; }
        public int? DailyActiveUserRank { get; private set; }
        public int? MontlyActiveUserRank { get; private set; }

        public static FacebookAppResponse ParseJson(string contents) {
            return Parse(JsonConverter.ParseObject(contents));
        }

        public static FacebookAppResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookException.Parse);
            return new FacebookAppResponse {
                Id = obj.GetLong("id"),
                Name = obj.GetString("name"),
                Description = obj.GetString("description"),
                Category = obj.GetString("category"),
                SubCategory = obj.GetString("subcategory"),
                Link = obj.GetString("link"),
                Namespace = obj.GetString("namespace"),
                IconUrl = obj.GetString("icon_url"),
                LogoUrl = obj.GetString("logo_url")
            };
        }

    }

}
