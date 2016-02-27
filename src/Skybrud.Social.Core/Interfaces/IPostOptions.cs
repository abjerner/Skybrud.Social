using Skybrud.Social.Http;

namespace Skybrud.Social.Interfaces {

    /// <summary>
    /// Interface representing the options of a HTTP POST request.
    /// </summary>
    public interface IPostOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets whether the request should be posted as multipart data.
        /// </summary>
        bool IsMultipart { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an instance of <see cref="SocialPostData"/> representing the POST data.
        /// </summary>
        SocialPostData GetPostData();

        #endregion

    }

}