using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Options {

    public interface IFacebookGetOptions {

        #region Methods

        /// <summary>
        /// Gets an instance of <code>SocialQueryString</code> representing the GET parameters.
        /// </summary>
        SocialQueryString GetQueryString();

        #endregion

    }

}
