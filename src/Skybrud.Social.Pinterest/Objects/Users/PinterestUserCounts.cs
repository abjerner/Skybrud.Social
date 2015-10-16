using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Pinterest.Objects.Users {
    
    public class PinterestUserCounts : PinterestObject {

        #region Properties

        /// <summary>
        /// Gets the amount of pins made by the user.
        /// </summary>
        public int Pins { get; private set; }
        
        /// <summary>
        /// Gets the amount of users the user is following.
        /// </summary>
        public int Following { get; private set; }
        
        /// <summary>
        /// Gets the amount of users following the user.
        /// </summary>
        public int Followers { get; private set; }
        
        public int Boards { get; private set; }
        
        public int Likes { get; private set; }

        #endregion

        #region Constructors

        private PinterestUserCounts(JObject obj) : base(obj) {
            Pins = obj.GetInt32("pins");
            Following = obj.GetInt32("following");
            Followers = obj.GetInt32("followers");
            Boards = obj.GetInt32("boards");
            Likes = obj.GetInt32("likes");
        }

        #endregion

        #region Static methods

        public static PinterestUserCounts Parse(JObject obj) {
            return obj == null ? null : new PinterestUserCounts(obj);
        }

        #endregion

    }

}