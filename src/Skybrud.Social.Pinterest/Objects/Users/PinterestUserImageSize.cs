using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Pinterest.Objects.Users {
    
    public class PinterestUserImageSize : PinterestObject {

        #region Properties

        public string Url { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        #endregion

        #region Constructors

        private PinterestUserImageSize(JObject obj) : base(obj) {
            Url = obj.GetString("url");
            Width = obj.GetInt32("width");
            Height = obj.GetInt32("height");
        }

        #endregion

        #region Static methods

        public static PinterestUserImageSize Parse(JObject obj) {
            return obj == null ? null : new PinterestUserImageSize(obj);
        }

        #endregion

    }

}