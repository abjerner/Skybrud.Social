using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Pages {

    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.2/page#read</cref>
    /// </see>
    public class FacebookPage : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the page.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets information about the page.
        /// </summary>
        public string About { get; private set; }

        /// <summary>
        /// Gets whether the authenticated user can post to the page.
        /// </summary>
        public bool CanPost { get; private set; }

        /// <summary>
        /// Gets the main category of the page.
        /// </summary>
        public string Category { get; private set; }

        /// <summary>
        /// Gets a list of all sub categories.
        /// </summary>
        public FacebookPageCategory[] CategoryList { get; private set; }

        /// <summary>
        /// Gets the number of checkins at a place represented by the page.
        /// </summary>
        public int Checkins { get; private set; }

        /// <summary>
        /// Gets the company overview. Applicable to <code>Companies</code>.
        /// </summary>
        public string CompanyOverview { get; private set; }

        /// <summary>
        /// Gets information about the cover photo of the page.
        /// </summary>
        public FacebookCoverPhoto Cover { get; private set; }

        /// <summary>
        /// Gets the description of the page.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the director of the film. Applicable to <code>Films</code>.
        /// </summary>
        public string DirectedBy { get; private set; }

        /// <summary>
        /// Gets when the company was founded. Applicable to <code>Companies</code>.
        /// </summary>
        public string Founded { get; private set; }

        /// <summary>
        /// General information provided by the page.
        /// </summary>
        public string GeneralInfo { get; private set; }

        /// <summary>
        /// Gets the general manager of the business. Applicable to <code>Restaurants</code> or
        /// <code>Nightlife</code>.
        /// </summary>
        public string GeneralManager { get; private set; }

        /// <summary>
        /// Gets the hometown of the band. Applicable to <code>Bands</code>.
        /// </summary>
        public string Hometown { get; private set; }

        /// <summary>
        /// Gets the opening hours for this location.
        /// </summary>
        public FacebookOpeningHours Hours { get; private set; }

        /// <summary>
        /// Impressum for the page. Only required for German pages.
        /// </summary>
        public string Impressum { get; private set; }

        /// <summary>
        /// For businesses that are no longer operating.
        /// </summary>
        public bool IsPermantlyClosed { get; private set; }

        /// <summary>
        /// Gets whether the page is published and visible to non-admins.
        /// </summary>
        public bool IsPublished { get; private set; }

        /// <summary>
        /// Gets whether the page is unclaimed.
        /// </summary>
        public bool IsUnclaimed { get; private set; }

        /// <summary>
        /// Gets the number of users who like the page. For Global Brand Pages this is the count
        /// for all pages across the brand.
        /// </summary>
        public int Likes { get; private set; }

        /// <summary>
        /// Gets the Facebook URL of the page.
        /// </summary>
        public string Link { get; private set; }

        /// <summary>
        /// Gets the location of the place. Applicable to all <code>Places</code>.
        /// </summary>
        public FacebookLocation Location { get; private set; }

        /// <summary>
        /// Gets the company mission. Applicable to <code>Companies</code>.
        /// </summary>
        public string Mission { get; private set; }

        /// <summary>
        /// Gets the name of the page.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets information about the parking available at a place.
        /// </summary>
        public FacebookParking Parking { get; private set; }

        /// <summary>
        /// Gets information about the available payment options at a place.
        /// </summary>
        public FacebookPaymentOptions PaymentOptions { get; private set; }

        /// <summary>
        /// Gets the phone number provided by a page.
        /// </summary>
        public string Phone { get; private set; }

        /// <summary>
        /// Gets the press contact information of the band. Applicable to <code>Bands</code>.
        /// </summary>
        public string PressContact { get; private set; }

        /// <summary>
        /// Price range of the business. Applicable to <code>Restaurants</code> or
        /// <code>Nightlife</code>.
        /// </summary>
        public string PriceRange { get; private set; }

        /// <summary>
        /// Services the restaurant provides. Applicable to <code>Restaurants</code>.
        /// </summary>
        public FacebookRestaurantServices RestaurantServices { get; private set; }

        /// <summary>
        /// The restaurant's specialties. Applicable to <code>Restaurants</code>.
        /// </summary>
        public FacebookRestaurantSpecialties RestaurantSpecialties { get; private set; }

        /// <summary>
        /// Gets the number of people talking about the page.
        /// </summary>
        public int TalkingAboutCount { get; private set; }

        /// <summary>
        /// Gets the alias of the page. For example, for www.facebook.com/platform the username is
        /// 'platform'.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the URL to the website of the page.
        /// </summary>
        public string Website { get; private set; }

        /// <summary>
        /// Gets the number of visits to location of the page.
        /// </summary>
        public int WereHereCount { get; private set; }

        #endregion

        #region Constructors

        private FacebookPage(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets a page from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static FacebookPage Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPage(obj) {
                Id = obj.GetString("id"),
                About = obj.GetString("about"),
                CanPost = obj.GetBoolean("can_post"),
                Category = obj.GetString("category"),
                CategoryList = obj.GetArray("category_list", FacebookPageCategory.Parse),
                Checkins = obj.GetInt32("checkins"),
                CompanyOverview = obj.GetString("company_overview"),
                Cover = obj.GetObject("cover", FacebookCoverPhoto.Parse),
                Description = obj.GetString("description"),
                DirectedBy = obj.GetString("directed_by"),
                Founded = obj.GetString("founded"),
                GeneralInfo = obj.GetString("general_info"),
                GeneralManager = obj.GetString("general_manager"),
                Hometown = obj.GetString("hometown"),
                Hours = obj.GetObject("hours", FacebookOpeningHours.Parse),
                Impressum = obj.GetString("impressum"),
                IsPermantlyClosed = obj.GetBoolean("is_permanently_closed"),
                IsPublished = obj.GetBoolean("is_published"),
                IsUnclaimed = obj.GetBoolean("is_unclaimed"),
                Likes = obj.GetInt32("likes"),
                Link = obj.GetString("link"),
                Location = obj.GetObject("location", FacebookLocation.Parse),
                Mission = obj.GetString("mission"),
                Name = obj.GetString("name"),
                Parking = obj.GetObject("parking", FacebookParking.Parse),
                PaymentOptions = obj.GetObject("payment_options", FacebookPaymentOptions.Parse),
                Phone = obj.GetString("phone"),
                PressContact = obj.GetString("press_contact"),
                PriceRange = obj.GetString("price_range"),
                RestaurantServices = obj.GetObject("restaurant_services", FacebookRestaurantServices.Parse),
                RestaurantSpecialties = obj.GetObject("restaurant_specialties", FacebookRestaurantSpecialties.Parse),
                TalkingAboutCount = obj.GetInt32("talking_about_count"),
                Username = obj.GetString("username"),
                Website = obj.GetString("website"),
                WereHereCount = obj.GetInt32("were_here_count")
            };
        }

        #endregion

    }

}