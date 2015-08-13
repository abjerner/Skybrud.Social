using System;
using Skybrud.Social.Facebook.Fields;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Facebook.Options.User {
    
    /// <summary>
    /// Class representing the options for a call to the Facebook Graph API to get information about a single user.
    /// </summary>
    public class FacebookGetUserOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the identifier (ID) of the user.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the fields to be returned.
        /// </summary>
        public FacebookFieldsCollection Fields { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an instance with default options.
        /// </summary>
        public FacebookGetUserOptions() {
            Fields = new FacebookFieldsCollection();
        }

        /// <summary>
        /// Initializes an instance with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID) of the user.</param>
        public FacebookGetUserOptions(string identifier) : this() {
            Identifier = identifier;
        }

        #endregion

        public SocialQueryString GetQueryString() {

            // Convert the collection of fields to a string
            string fields = (Fields == null ? "" : Fields.ToString()).Trim();

            // Construct the query string
            SocialQueryString query = new SocialQueryString();
            if (!String.IsNullOrWhiteSpace(fields)) query.Set("fields", fields);

            return query;

        }
    
    }

}