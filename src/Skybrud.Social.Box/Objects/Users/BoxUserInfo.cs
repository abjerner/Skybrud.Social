using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Box.Objects.Users {
    
    public class BoxUserInfo : BoxObject {

        #region Properties

        /// <summary>
        /// Gets the type of the user.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Gets the login of the user.
        /// </summary>
        public string Login { get; private set; }

        #endregion

        #region Constructors

        private BoxUserInfo(JObject obj) : base(obj) {
            Type = obj.GetString("type");
            Id = obj.GetString("id");
            Name = obj.GetString("name");
            Login = obj.GetString("login");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>BoxUserInfo</code> from the specified <code>JObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to parse.</param>
        public static BoxUserInfo Parse(JObject obj) {
            return obj == null ? null : new BoxUserInfo(obj);
        }

        #endregion

    }

}