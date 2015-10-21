using System;
using Skybrud.Social.Dropbox.Objects.Authentication;
using Skybrud.Social.Http;

namespace Skybrud.Social.Dropbox.Responses.Authentication {
    
    public class DropboxTokenResponse : DropboxResponse<DropboxTokenResponseBody> {
        
        #region Constructors

        private DropboxTokenResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>DropboxTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>DropboxTokenResponse</code>.</returns>
        public static DropboxTokenResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");
            
            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new DropboxTokenResponse(response) {
                Body = SocialUtils.ParseJsonObject(response.Body, DropboxTokenResponseBody.Parse)
            };

        }

        #endregion

    }

}