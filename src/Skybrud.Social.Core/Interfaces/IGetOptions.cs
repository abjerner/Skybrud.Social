using Skybrud.Social.Http;

namespace Skybrud.Social.Interfaces {

    /// <summary>
    /// Interface representing the options of a HTTP GET request.
    /// </summary>
    public interface IGetOptions {

        #region Methods

        /// <summary>
        /// Gets an instance of <see cref="SocialHttpQueryString"/> representing the GET parameters.
        /// </summary>
        SocialHttpQueryString GetQueryString();

        #endregion

    }

}