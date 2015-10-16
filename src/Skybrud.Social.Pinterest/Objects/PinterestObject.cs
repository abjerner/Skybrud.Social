using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Pinterest.Objects {

    public class PinterestObject {

        #region Properties

        public JObject JObject { get; private set; }

        #endregion

        #region Constructors

        protected PinterestObject(JObject obj) {
            JObject = obj;
        }

        #endregion

    }

}