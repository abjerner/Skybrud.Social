using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Options.Albums {
    
    public class FacebookPostAlbumOptions : IFacebookPostOptions {

        #region Properties

        /// <summary>
        /// The name given to the album. This field is required.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the album, which will show up in news feed stories as the status message.
        /// </summary>
        public string Message { get; set; }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            return new SocialQueryString();
        }

        public SocialQueryString GetPostData() {
            SocialQueryString query = new SocialQueryString();
            if (!String.IsNullOrWhiteSpace(Name)) query.Add("name", Name);
            if (!String.IsNullOrWhiteSpace(Message)) query.Add("message", Message);
            return query;
        }

        #endregion

    }

}