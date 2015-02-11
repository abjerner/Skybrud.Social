using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects.Geocode {
    
    public class TwitterReverseGeocodeResults : SocialJsonObject {

        #region Properties

        public TwitterReverseGeocodeResult Result { get; private set; }

        public TwitterReverseGeocodeQuery Query { get; private set; }

        #endregion

        #region Constructors

        private TwitterReverseGeocodeResults(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static TwitterReverseGeocodeResults Parse(JsonObject obj) {
            if (obj == null) return null;
            TwitterReverseGeocodeResults results = new TwitterReverseGeocodeResults(obj);
            results.Result = obj.GetObject("result", x => TwitterReverseGeocodeResult.Parse(results, x));
            results.Query = obj.GetObject("query", x => TwitterReverseGeocodeQuery.Parse(results, x));
            return results;
        }

        #endregion

    }

}