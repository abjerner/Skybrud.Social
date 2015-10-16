using System.Linq;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Pinterest.Objects.Users {
    
    public class PinterestUserImage : PinterestObject {

        #region Properties

        public PinterestUserImageSize[] Sizes { get; private set; }

        #endregion

        #region Constructors

        private PinterestUserImage(JObject obj) : base(obj) {
            Sizes = (
                from property in obj.Properties()
                select PinterestUserImageSize.Parse(property.Value as JObject)
            ).ToArray();
        }

        #endregion

        #region Static methods

        public static PinterestUserImage Parse(JObject obj) {
            return obj == null ? null : new PinterestUserImage(obj);
        }

        #endregion

    }

}