using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Enums;

namespace Skybrud.Social.Twitter.Objects.Geocode {
    
    public class TwitterReverseGeocodeParameters : SocialJsonObject {

        #region Properties

        public TwitterReverseGeocodeQuery Query { get; private set; }

        public int Accuracy { get; private set; }

        public TwitterGranularity Granularity { get; private set; }

        public TwitterCoordinates Coordinates { get; private set; }

        #endregion

        #region Constructors

        private TwitterReverseGeocodeParameters(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static TwitterReverseGeocodeParameters Parse(TwitterReverseGeocodeQuery query, JsonObject obj) {
            return new TwitterReverseGeocodeParameters(obj) {
                Query = query,
                Accuracy = obj.GetInt32("accuracy"),
                Granularity = TwitterUtils.ParseGranularity(obj.GetString("granularity")),
                Coordinates = obj.GetObject("coordinates", TwitterCoordinates.Parse),
            };
        }

        #endregion

    }

}