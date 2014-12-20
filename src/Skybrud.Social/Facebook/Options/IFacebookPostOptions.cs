using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Options {

    public interface IFacebookPostOptions : IFacebookGetOptions {

        #region Methods

        /// <summary>
        /// Gets an instance of <code>SocialQueryString</code> representing the POST data.
        /// </summary>
        SocialQueryString GetPostData();

        #endregion

    }

}
