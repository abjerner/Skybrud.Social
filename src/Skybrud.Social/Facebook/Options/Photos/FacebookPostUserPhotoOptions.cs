using System;
using Skybrud.Social.Facebook.Options.Common;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Facebook.Options.Photos {

    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.2/user/photos#publish</cref>
    /// </see>
    public class FacebookPostUserPhotoOptions : IPostOptions {

        #region Properties
        
        /// <summary>
        /// Gets or sets the identifier (ID or alias) of the user, page or album to which the photo should be uploaded.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the photo. Either this or <code>url</code> field is required, but both should not be used
        /// together.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The URL of a photo that is already uploaded to the internet. Either this or <code>source</code> is
        /// required, but both should not be used together.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The description of the photo, used as the accompanying status message in any feed story.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Page ID of a place associated with the Photo.
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// If set to <code>TRUE</code>, this will suppress the feed story that is automatically generated on a
        /// person's profile when they upload a photo using your app.
        /// </summary>
        public bool NoStory { get; set; }

        /// <summary>
        /// Determines the privacy settings of the photo. If not supplied, this defaults to the privacy level granted
        /// to the app in the Login Dialog. This field cannot be used to set a more open privacy setting than the one
        /// granted.
        /// </summary>
        public FacebookPrivacyOptions Privacy { get; set; }

        public bool IsMultipart {
            get { return !String.IsNullOrWhiteSpace(Source); }
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            return new SocialQueryString();
        }

        public SocialPostData GetPostData() {
            SocialPostData postData = new SocialPostData();
            if (!String.IsNullOrWhiteSpace(Source)) postData.AddFile("source", Source);
            if (!String.IsNullOrWhiteSpace(Url)) postData.Add("url", Url);
            if (!String.IsNullOrWhiteSpace(Message)) postData.Add("message", Message);
            if (!String.IsNullOrWhiteSpace(Place)) postData.Add("place", Place);
            if (NoStory) postData.Add("no_story", "true");
            return postData;
        }

        #endregion

    }

}