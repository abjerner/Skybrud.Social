using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Pinterest.Fields;

namespace Skybrud.Social.Pinterest.Options {
    
    public class PinterestGetUserOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the identifier (ID) of the user.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the fields to be returned.
        /// </summary>
        public PinterestFieldsCollection Fields { get; set; }

        #endregion
        
        #region Constructors

        /// <summary>
        /// Initializes an instance with default options.
        /// </summary>
        public PinterestGetUserOptions() {
            Fields = new PinterestFieldsCollection();
        }

        /// <summary>
        /// Initializes an instance with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID) of the user.</param>
        public PinterestGetUserOptions(string identifier) {
            Identifier = identifier;
        }

        /// <summary>
        /// Initializes an instance with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID) of the user.</param>
        /// <param name="fields">A collection of the fields that should be returned.</param>
        public PinterestGetUserOptions(string identifier, PinterestFieldsCollection fields) {
            Identifier = identifier;
            Fields = fields ?? new PinterestFieldsCollection();
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