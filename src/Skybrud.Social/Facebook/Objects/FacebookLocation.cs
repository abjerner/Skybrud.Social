using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookLocation : SocialJsonObject {

        #region Properties

        public string City { get; private set; }

        public string Country { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public string Street { get; private set; }

        public string Zip { get; private set; }

        #endregion

        #region Constructor

        private FacebookLocation(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookLocation Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookLocation(obj) {
                City = obj.GetString("city"),
                Country = obj.GetString("country"),
                Latitude = obj.GetDouble("latitude"),
                Longitude = obj.GetDouble("longitude"),
                Street = obj.GetString("street"),
                Zip = obj.GetString("zip")
            };

        }

        #endregion

    }

}
