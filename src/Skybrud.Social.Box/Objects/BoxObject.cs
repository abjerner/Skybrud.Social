using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Box.Objects {
    
    public class BoxObject {

        #region Properties

        public JObject JObject { get; private set; }

        #endregion

        #region Constructors

        protected BoxObject(JObject obj) {
            JObject = obj;
        }

        #endregion

    }

}