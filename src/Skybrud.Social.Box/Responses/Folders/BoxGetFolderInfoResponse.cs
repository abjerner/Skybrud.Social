using System;
using Skybrud.Social.Box.Objects.Folders;
using Skybrud.Social.Http;

namespace Skybrud.Social.Box.Responses.Folders {

    public class BoxGetFolderInfoResponse : BoxResponse<BoxFolderInfo> {
        
        #region Constructors

        private BoxGetFolderInfoResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>BoxGetFolderInfoResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>BoxGetFolderInfoResponse</code>.</returns>
        public static BoxGetFolderInfoResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");
            
            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new BoxGetFolderInfoResponse(response) {
                Body = SocialUtils.ParseJsonObject(response.Body, BoxFolderInfo.Parse)
            };

        }

        #endregion

    }

}