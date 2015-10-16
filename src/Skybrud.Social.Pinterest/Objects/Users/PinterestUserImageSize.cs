using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Pinterest.Objects.Users {
    
    public class PinterestUserImageSize : PinterestObject {

        #region Properties
        
        /// <summary>
        /// Gets the alias of the image size.
        /// </summary>
        public string Alias { get; private set; }

        /// <summary>
        /// Gets the URL of the image size.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the width of the image size.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the height of the image size.
        /// </summary>
        public int Height { get; private set; }

        #endregion

        #region Constructors

        private PinterestUserImageSize(JObject obj) : base(obj) {

            JProperty property = obj.Parent as JProperty;
            Alias = property == null ? null : property.Name;

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