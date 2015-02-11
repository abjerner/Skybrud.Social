using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects.Geocode {
    
    public class TwitterReverseGeocodeQuery : SocialJsonObject {

        #region Properties

        public TwitterReverseGeocodeResults Results { get; private set; }

        public string Url { get; private set; }

        public string Type { get; private set; }

        #endregion

        #region Constructors

        private TwitterReverseGeocodeQuery(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static TwitterReverseGeocodeQuery Parse(TwitterReverseGeocodeResults results, JsonObject obj) {
            return new TwitterReverseGeocodeQuery(obj) {
                Results = results,
                Url = obj.GetString("url"),
                Type = obj.GetString("type")
            };
        }

        #endregion

    }

}