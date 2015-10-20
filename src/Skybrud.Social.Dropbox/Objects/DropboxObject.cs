using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Dropbox.Objects {
    
    public class DropboxObject {

        #region Properties

        public JObject JObject { get; private set; }

        #endregion

        #region Constructors

        protected DropboxObject(JObject obj) {
            JObject = obj;
        }

        #endregion

    }

}