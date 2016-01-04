using Skybrud.Social.Http;

namespace Skybrud.Social.Interfaces {

    public interface IPostOptions : IGetOptions {

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