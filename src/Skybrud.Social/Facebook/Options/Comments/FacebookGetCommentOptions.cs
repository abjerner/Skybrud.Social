using System;
using Skybrud.Social.Facebook.Fields;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Facebook.Options.Comments {
    
    /// <summary>
    /// Class representing the options for getting information about a single comment.
    /// </summary>
    public class FacebookGetCommentOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the identifier (ID) of the comments.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the fields to be returned.
        /// </summary>
        public FacebookFieldsCollection Fields { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the class with default options.
        /// </summary>
        public FacebookGetCommentOptions() { }
        
        /// <summary>
        /// Initializes the class with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID) of the comment.</param>
        public FacebookGetCommentOptions(string identifier) {
            Identifier = identifier;
        }

        #endregion

        #region Methods

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