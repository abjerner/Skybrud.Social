using System;
using Skybrud.Social.Google.Analytics.Options.Management;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Google.Analytics.Endpoints.Raw {
    
    /// <summary>
    /// Raw implementation of the management endpoint.
    /// </summary>
    public class AnalyticsManagementRawEndpoint {

        protected const string ManagementUrl = "https://www.googleapis.com/analytics/v3/management/";

        #region Properties

        /// <summary>
        /// Gets a reference to the Google OAuth client.
        /// </summary>
        public GoogleOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal AnalyticsManagementRawEndpoint(GoogleOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of Analytics accounts of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetAccounts() {
            return GetAccounts(new AnalyticsAccountsOptions());
        }

        /// <summary>
        /// Gets a list of Analytics accounts of the authenticated user.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetAccounts(AnalyticsAccountsOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://www.googleapis.com/analytics/v3/management/accounts", options);
        }

        /// <summary>
        /// Gets a list of web properties based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        /// <returns></returns>
        public SocialHttpResponse GetWebProperties(AnalyticsWebPropertiesOptions options) {
            
            // Some input validation
            if (options == null) throw new ArgumentNullException("options");

            // Construct the URL
            string url = String.Format(
               "{0}accounts/" + options.AccountId + "/webproperties",
               ManagementUrl,
               options.AccountId
            );
            
            return Client.DoAuthenticatedGetRequest(url, options);
        
        }

        /// <summary>
        /// Gets a list of profiles based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetProfiles(AnalyticsProfilesOptions options) {
            
            // Some input validation
            if (options == null) throw new ArgumentNullException("options");

            // Construct the URL
            string url = String.Format(
               "{0}accounts/" + options.AccountId + "/webproperties/" + options.WebPropertyId + "/profiles",
               ManagementUrl,
               options.AccountId,
               options.WebPropertyId
            );

            // Make the call to the API
            return Client.DoAuthenticatedGetRequest(url, options);

        }
        
        #endregion

    }

}