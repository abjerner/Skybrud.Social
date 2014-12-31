using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Options {

    public interface IFacebookPostOptions : IFacebookGetOptions {

        #region Properties

        bool IsMultipart { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an instance of <code>SocialPostData</code> representing the POST data.
        /// </summary>
        SocialPostData GetPostData();

        #endregion

    }

}
