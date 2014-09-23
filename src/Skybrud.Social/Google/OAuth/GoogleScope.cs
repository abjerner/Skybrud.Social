using Skybrud.Social.Google.Analytics;

namespace Skybrud.Social.Google.OAuth {
    
    public class GoogleScope {

        #region Constants (global Google scopes)

        public static readonly GoogleScope OpenId = new GoogleScope("openid");
        public static readonly GoogleScope Email = new GoogleScope("email");
        public static readonly GoogleScope Profile = new GoogleScope("profile");

        #endregion

        public string Name { get; private set; }
        public string Description { get; private set; }

        #region Constructor

        public GoogleScope(string name) {
            Name = name;
        }

        public GoogleScope(string name, string description) {
            Name = name;
            Description = description;
        }

        #endregion
        
        #region Member methods

        public override string ToString() {
            return Name;
        }

        #endregion
        
        #region Operators

        /// <summary>
        /// Adding two instance of GoogleScope will result in a GoogleScopeCollection containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static GoogleScopeCollection operator +(GoogleScope left, GoogleScope right) {
            return new GoogleScopeCollection(left, right);
        }

        #endregion

    }

}