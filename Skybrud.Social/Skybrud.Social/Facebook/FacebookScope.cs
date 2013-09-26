namespace Skybrud.Social.Facebook {
    
    public class FacebookScope {

        #region Constants

        /// <summary>
        /// Lets the application manage pages that you have access to.
        /// </summary>
        public static readonly FacebookScope ManagePages = new FacebookScope("manage_pages");

        /// <summary>
        /// Lets the application read your stream.
        /// </summary>
        public static readonly FacebookScope ReadStream = new FacebookScope("read_stream");

        /// <summary>
        /// Lets the application read your friendlists.
        /// </summary>
        public static readonly FacebookScope ReadFriendlists = new FacebookScope("read_friendlists");

        #endregion

        #region Properties

        // The name of the scope
        public string Name { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default and private constructor.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        private FacebookScope(string name) {
            Name = name;
        }

        #endregion

        #region Member methods

        public override string ToString() {
            return Name;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adding two instance of FacebookScope will result in a FacebookScopeCollection containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static FacebookScopeCollection operator +(FacebookScope left, FacebookScope right) {
            return new FacebookScopeCollection(left, right);
        }

        #endregion

    }

}
