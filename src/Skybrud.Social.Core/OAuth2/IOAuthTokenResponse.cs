using Skybrud.Social.Http;

namespace Skybrud.Social.OAuth2 {
    
    /// <summary>
    /// Interface describing a token response.
    /// </summary>
    public interface IOAuthTokenResponse : IResponse {

        /// <summary>
        /// Gets an object representing the body of the response.
        /// </summary>
        IOAuthToken Body { get; }

    }

}