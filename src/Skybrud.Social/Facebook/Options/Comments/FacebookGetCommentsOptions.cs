using System;
using Skybrud.Social.Facebook.Fields;
using Skybrud.Social.Facebook.Options.Pagination;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Options.Comments {
    
    /// <summary>
    /// Class representing the options for getting a list of comments.
    /// </summary>
    public class FacebookGetCommentsOptions : FacebookCursorBasedPaginationOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the identifier (ID) of the parent object.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the fields to be returned.
        /// </summary>
        public FacebookFieldsCollection Fields { get; set; }

        /// <summary>
        /// Gets or sets whether a summary of metadata about the comments on the object should be included in the
        /// response. The summary will contain the total count of comments and how the comments are sorted (either
        /// <code>ranked</code> or <code>chronological</code>).
        /// </summary>
        public bool IncludeSummary { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the class with default options.
        /// </summary>
        public FacebookGetCommentsOptions() { }

        /// <summary>
        /// Initializes the class with the specified <code>limit</code>.
        /// </summary>
        /// <param name="limit">The limit.</param>
        public FacebookGetCommentsOptions(int limit) {
            Limit = limit;
        }

        /// <summary>
        /// Initializes the class with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID) of the parent object.</param>
        public FacebookGetCommentsOptions(string identifier) {
            Identifier = identifier;
        }

        /// <summary>
        /// Initializes the class with the specified <code>identifier</code> and <code>limit</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID) of the parent object.</param>
        /// <param name="limit">The limit.</param>
        public FacebookGetCommentsOptions(string identifier, int limit) {
            Identifier = identifier;
            Limit = limit;
        }

        #endregion

        #region Methods

        public override SocialQueryString GetQueryString() {
            
            SocialQueryString query = base.GetQueryString();

            // Convert the collection of fields to a string
            string fields = (Fields == null ? "" : Fields.ToString()).Trim();

            // Construct the query string
            if (!String.IsNullOrWhiteSpace(fields)) query.Set("fields", fields);
            if (IncludeSummary) query.Set("summary", "true");
            
            // TODO: Implement the "filter" modifier
            
            return query;
        
        }

        #endregion

    }

}