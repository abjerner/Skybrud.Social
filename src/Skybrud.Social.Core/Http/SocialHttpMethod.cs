namespace Skybrud.Social.Http {
    
    /// <summary>
    /// Enum class representing the HTTP method to be used for a HTTP request.
    /// </summary>
    public enum SocialHttpMethod {

        /// <summary>
        /// Indicates a request should be made using the <c>GET</c> HTTP method.
        /// </summary>
        Get,

        /// <summary>
        /// Indicates a request should be made using the <c>HEAD</c> HTTP method.
        /// </summary>
        Head,

        /// <summary>
        /// Indicates a request should be made using the <c>POST</c> HTTP method.
        /// </summary>
        Post,

        /// <summary>
        /// Indicates a request should be made using the <c>PUT</c> HTTP method.
        /// </summary>
        Put,

        /// <summary>
        /// Indicates a request should be made using the <c>PATCH</c> HTTP method.
        /// </summary>
        Patch,

        /// <summary>
        /// Indicates a request should be made using the <c>DELETE</c> HTTP method.
        /// </summary>
        Delete

    }

}