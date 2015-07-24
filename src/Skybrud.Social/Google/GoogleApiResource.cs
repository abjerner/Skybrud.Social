using Skybrud.Social.Json;

namespace Skybrud.Social.Google {
    
    /// <summary>
    /// Class representing a resource in the Google ecosystem. A resource can be described as an object that can be
    /// requested through one of the various APIs, and holds properties fir <code>kind</code> and <code>etag</code>.
    /// </summary>
    public class GoogleApiResource : GoogleApiObject {

        #region Properties

        /// <summary>
        /// Gets the <code>kind</code> of the resource.
        /// </summary>
        public string Kind { get; private set; }

        /// <summary>
        /// Gets the <code>etag</code> of the resource.
        /// </summary>
        public string ETag { get; private set; }

        #endregion

        #region Constructors

        protected GoogleApiResource(JsonObject obj) : base(obj) {
            Kind = obj.GetString("kind");
            ETag = obj.GetString("etag");
        }

        #endregion

    }

}