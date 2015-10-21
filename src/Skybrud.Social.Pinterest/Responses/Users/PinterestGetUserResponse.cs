using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Json.Extensions.JObject;
using Skybrud.Social.Pinterest.Objects;
using Skybrud.Social.Pinterest.Objects.Users;

namespace Skybrud.Social.Pinterest.Responses.Users {

    public class PinterestGetUserResponse : PinterestResponse<PinterestGetUserResponseBody> {
        
        #region Constructors

        private PinterestGetUserResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>PinterestGetUserResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>PinterestGetUserResponse</code>.</returns>
        public static PinterestGetUserResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");
            
            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new PinterestGetUserResponse(response) {
                Body = SocialUtils.ParseJsonObject(response.Body, PinterestGetUserResponseBody.Parse)
            };

        }

        #endregion

    }

    public class PinterestGetUserResponseBody : PinterestObject {

        #region Properties

        public PinterestUser Data { get; private set; }

        #endregion

        #region Constructors

        private PinterestGetUserResponseBody(JObject obj) : base(obj) {
            Data = obj.GetObject("data", PinterestUser.Parse);
        }

        #endregion

        #region Static methods

        public static PinterestGetUserResponseBody Parse(JObject obj) {
            return obj == null ? null : new PinterestGetUserResponseBody(obj);
        }

        #endregion

    }

}