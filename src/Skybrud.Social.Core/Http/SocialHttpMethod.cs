namespace Skybrud.Social.Http {
    
    /// <summary>
    /// Enum class representing the HTTP method to be used for a HTTP request.
    /// </summary>
    public enum SocialHttpMethod {

        /// <summary>
        /// Indicates a request should be made using the <code>GET</code> HTTP method.
        /// </summary>
        Get,

        /// <summary>
        /// Indicates a request should be made using the <code>POST</code> HTTP method.
        /// </summary>
        Post,

        /// <summary>
        /// Indicates a request should be made using the <code>PUT</code> HTTP method.
        /// </summary>
        Put,

        /// <summary>
        /// Indicates a request should be made using the <code>DELETE</code> HTTP method.
        /// </summary>
        Delete

    }

}