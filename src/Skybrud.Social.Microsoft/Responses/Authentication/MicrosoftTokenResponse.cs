using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Microsoft.Objects.Authentication;

namespace Skybrud.Social.Microsoft.Responses.Authentication {
    
    public class MicrosoftTokenResponse : MicrosoftResponse<MicrosoftTokenResponseBody> {
        
        #region Constructors

        private MicrosoftTokenResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>MicrosoftTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>MicrosoftTokenResponse</code>.</returns>
        public static MicrosoftTokenResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");
            
            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new MicrosoftTokenResponse(response) {
                Body = JsonObject.ParseJson(response.Body, MicrosoftTokenResponseBody.Parse)
            };

        }

        #endregion

    }

}