using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Pinterest.Objects.Authentication;

namespace Skybrud.Social.Pinterest.Responses.Authentication {

    public class PinterestTokenResponse : PinterestResponse<PinterestTokenResponseBody> {
        
        #region Constructors

        private PinterestTokenResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>PinterestTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>PinterestTokenResponse</code>.</returns>
        public static PinterestTokenResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");
            
            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new PinterestTokenResponse(response) {
                Body = SocialUtils.ParseJsonObject(response.Body, PinterestTokenResponseBody.Parse)
            };

        }

        #endregion

    }

}