using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Twitter.Options {

    public class TwitterPostStatusMessageOptions : IPostOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the text of the status message.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the ID of the status message to reply to.
        /// </summary>
        public long? ReplyTo { get; set; }

        /// <summary>
        /// If you upload tweet media that might be considered sensitive content such as nudity, violence, or medical
        /// procedures, you should set this value to <code>true</code>.
        /// </summary>
        public bool PossiblySensitive { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the location this tweet refers to. This parameter will be ignored unless it is
        /// inside the range -90.0 to +90.0 (North is positive) inclusive. It will also be ignored if there isn’t a
        /// corresponding longitude parameter.
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the location this tweet refers to. The valid ranges for longitude is -180.0
        /// to +180.0 (East is positive) inclusive. This parameter will be ignored if outside that range, if it is not
        /// a number, if <code>geo_enabled</code> is disabled, or if there not a corresponding latitude parameter.
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        /// Gets or sets the ID for a place in the world.
        /// </summary>
        public string PlaceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to put a pin on the exact coordinates a tweet has been sent from.
        /// </summary>
        public bool DisplayCoordinates { get; set; }
        
        public bool IsMultipart {
            get { return false; }
        }

        #endregion

        public SocialQueryString GetQueryString() {
            return null;
        }

        public SocialPostData GetPostData() {
            SocialPostData data = new SocialPostData();
            data.Add("status", Status ?? "");
            if (ReplyTo != null) data.Add("in_reply_to_status_id", ReplyTo);
            if (PossiblySensitive) data.Add("possibly_sensitive", "true");
            if (Latitude != null) data.Add("lat", Latitude);
            if (Longitude != null) data.Add("long", Longitude);
            if (PlaceId != null) data.Add("place_id", PlaceId);
            if (DisplayCoordinates) data.Add("display_coordinates", "true");
            return data;
        }
    
    }

}