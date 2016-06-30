namespace Skybrud.Social.Interfaces.Http {

    /// <summary>
    /// Interface representing the options of a HTTP POST request.
    /// </summary>
    public interface IHttpPostOptions : IHttpGetOptions {

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpPostData"/> representing the POST data.
        /// </summary>
        IHttpPostData GetPostData();

        #endregion

    }

}