using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects.Geocode {
    
    public class TwitterReverseGeocodeResult : SocialJsonObject {

        #region Properties

        public TwitterReverseGeocodeResults Results { get; private set; }
        
        public TwitterPlace[] Places { get; private set; }

        #endregion

        #region Constructors

        private TwitterReverseGeocodeResult(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static TwitterReverseGeocodeResult Parse(TwitterReverseGeocodeResults results, JsonObject obj) {
            return new TwitterReverseGeocodeResult(obj) {
                Results = results,
                Places = obj.GetArray("places", TwitterPlace.Parse)
            };
        }

        #endregion

    }

}