namespace Skybrud.Social.Facebook.Fields {
    
    /// <summary>
    /// Class representing a field in the Facebook Graph API.
    /// </summary>
    public class FacebookField {

        #region Properties

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new field with the specified <code>name</code>.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        public FacebookField(string name) {
            Name = name;
        }

        #endregion

        #region Operators
       
        /// <summary>
        /// Initializes a new field based on the specified <code>name</code>.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        public static implicit operator FacebookField(string name) {
            return new FacebookField(name);
        }

        /// <summary>
        /// Adding two instances of <code>FacebookField</code> will result in a
        /// <code>FacebookFieldsCollection</code> containing both fields.
        /// </summary>
        /// <param name="left">The left field.</param>
        /// <param name="right">The right field.</param>
        public static FacebookFieldsCollection operator +(FacebookField left, FacebookField right) {
            return new FacebookFieldsCollection(left, right);
        }

        #endregion

    }

}