namespace Skybrud.Social.Pinterest.Fields {
    
    /// <summary>
    /// Class representing a field in the Pinterest API.
    /// </summary>
    public class PinterestField {

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
        public PinterestField(string name) {
            Name = name;
        }

        #endregion

        #region Member methods

        public override bool Equals(object obj) {

            PinterestField field = obj as PinterestField;
            string fieldName = obj as string;

            if (field != null) {
                return Equals(field);
            }
            
            if (fieldName != null) {
                return Equals(fieldName);
            }
            
            return false;

        }

        public bool Equals(PinterestField field) {
            return field != null && Name == field.Name;
        }

        public bool Equals(string name) {
            return Name == name;
        }

        public override int GetHashCode() {
            return Name.GetHashCode();
        }

        #endregion

        #region Operators

        /// <summary>
        /// Initializes a new field based on the specified <code>name</code>.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        public static implicit operator PinterestField(string name) {
            return new PinterestField(name);
        }

        /// <summary>
        /// Adding two instances of <code>PinterestField</code> will result in a
        /// <code>PinterestFieldsCollection</code> containing both fields.
        /// </summary>
        /// <param name="left">The left field.</param>
        /// <param name="right">The right field.</param>
        public static PinterestFieldsCollection operator +(PinterestField left, PinterestField right) {
            return new PinterestFieldsCollection(left, right);
        }

        #endregion

    }

}