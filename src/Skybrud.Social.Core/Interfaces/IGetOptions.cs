using Skybrud.Social.Http;

namespace Skybrud.Social.Interfaces {

    /// <summary>
    /// Interface representing the options of a HTTP GET request.
    /// </summary>
    public interface IGetOptions {

        #region Methods

        /// <summary>
        /// Gets an instance of <code>SocialQueryString</code> representing the GET parameters.
        /// </summary>
        SocialQueryString GetQueryString();

        #endregion

    }

}