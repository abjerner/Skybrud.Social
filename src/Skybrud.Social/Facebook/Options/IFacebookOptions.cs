using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Options {
    
    public interface IFacebookOptions {

        /// <summary>
        /// Gets an instance of <code>SocialQueryString</code> representing the options.
        /// </summary>
        SocialQueryString GetQuery();

    }

}
