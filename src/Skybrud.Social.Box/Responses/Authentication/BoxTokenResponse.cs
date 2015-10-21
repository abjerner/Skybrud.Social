using System;
using Skybrud.Social.Box.Objects.Authentication;
using Skybrud.Social.Http;

namespace Skybrud.Social.Box.Responses.Authentication {
    
    public class BoxTokenResponse : BoxResponse<BoxTokenResponseBody> {
        
        #region Constructors

        private BoxTokenResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>BoxTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>BoxTokenResponse</code>.</returns>
        public static BoxTokenResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");
            
            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new BoxTokenResponse(response) {
                Body = SocialUtils.ParseJsonObject(response.Body, BoxTokenResponseBody.Parse)
            };

        }

        #endregion

    }

}