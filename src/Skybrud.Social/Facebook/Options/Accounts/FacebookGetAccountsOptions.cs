using System;
using Skybrud.Social.Facebook.Fields;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Facebook.Options.Accounts {
    
    /// <summary>
    /// Class representing the options for a call to the Facebook Graph API to get accounts of the authenticated user.
    /// </summary>
    public class FacebookGetAccountsOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the fields to be returned.
        /// </summary>
        public FacebookFieldsCollection Fields { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an instance with default options.
        /// </summary>
        public FacebookGetAccountsOptions() {
            Fields = new FacebookFieldsCollection();
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {

            // Convert the collection of fields to a string
            string fields = (Fields == null ? "" : Fields.ToString()).Trim();

            // Construct the query string
            SocialQueryString query = new SocialQueryString();
            if (!String.IsNullOrWhiteSpace(fields)) query.Set("fields", fields);

            return query;

        }

        #endregion
    
    }

}