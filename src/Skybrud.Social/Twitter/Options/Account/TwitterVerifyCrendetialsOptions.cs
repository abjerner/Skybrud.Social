using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Twitter.Options.Account {
    
    /// <summary>
    /// Options for a call to verify the authenticated user (or the <em>credentials</em> of the user).
    /// </summary>
    /// <see>
    ///     <cref>https://dev.twitter.com/rest/reference/get/account/verify_credentials</cref>
    /// </see>
    public class TwitterVerifyCrendetialsOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets whether entities should be included in the response. Default is <code>true</code>.
        /// 
        /// Notice that both the user object and the status object will have their own <code>entities</code> property.
        /// The Twitter API documentation doesn't this further, but at the time of writing, this property only seems to
        /// effect the <code>entities</code> property on the status object.
        /// in the API documentation.
        /// </summary>
        public bool IncludeEntities { get; set; }

        /// <summary>
        /// Gets or sets whether the latest tweet (status message) of the user should be skipped in the response.
        /// Default is <code>false</code> (meaning it is included by default).
        /// </summary>
        public bool SkipStatus { get; set; }

        /// <summary>
        /// Gets or sets the email of the authenticated user should be included in the response. Default is
        /// <code>false</code>.
        /// 
        /// Notice that this qill require the <strong>Request email addresses from users</strong> option to be enabled
        /// in the settings of your Twitter app.
        /// </summary>
        public bool IncludeEmail { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterVerifyCrendetialsOptions() {
            IncludeEntities = true;
        }

        #endregion

        #region Member properties

        public SocialQueryString GetQueryString() {
            SocialQueryString query = new SocialQueryString();
            if (!IncludeEntities) query.Add("include_entities", "false");
            if (SkipStatus) query.Add("skip_status", "true");
            if (IncludeEmail) query.Add("include_email", "true");
            return query;
        }

        #endregion

    }

}