using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects {

    public class TwitterPlace : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the place.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the URL for the place in the Twitter API.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the type of the place.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the name of the place.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the full name of the place.
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Gets the country code of the place.
        /// </summary>
        public string CountryCode { get; private set; }

        /// <summary>
        /// Gets the country name of the place.
        /// </summary>
        public string Country { get; private set; }

        /// <summary>
        /// Gets the bounding box describing the place.
        /// </summary>
        public TwitterBoundingBox BoundingBox { get; private set; }

        #endregion

        #region Constructors

        private TwitterPlace(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>TwitterPlace</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static TwitterPlace Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterPlace(obj) {
                Id = obj.GetString("id"),
                Url = obj.GetString("url"),
                Type = obj.GetString("place_type"),
                Name = obj.GetString("name"),
                FullName = obj.GetString("full_name"),
                CountryCode = obj.GetString("country_code"),
                Country = obj.GetString("country"),
                BoundingBox = obj.GetObject("bounding_box", TwitterBoundingBox.Parse)
            };
        }

        #endregion

    }

}