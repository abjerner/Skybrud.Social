using Skybrud.Social.Microsoft.Scopes;

namespace Skybrud.Social.Microsoft.OneDrive.Scopes {
    
    /// <see>
    ///     <cref>https://dev.onedrive.com/auth/msa_oauth.htm</cref>
    /// </see>
    public class OneDriveScopes {

        #region Constants

        /// <summary>
        /// Grants read-only permission to all of a user's OneDrive files, including files shared with the user.
        /// </summary>
        public static readonly MicrosoftScope Readonly = new MicrosoftScope("onedrive.readonly");

        /// <summary>
        /// Grants read and write permission to all of a user's OneDrive files, including files shared with the user.
        /// To create sharing links, this scope is required.
        /// </summary>
        public static readonly MicrosoftScope ReadWrite = new MicrosoftScope("onedrive.readwrite");

        /// <summary>
        /// Grants read and write permissions to a specific folder for your application.
        /// </summary>
        public static readonly MicrosoftScope AppFolder = new MicrosoftScope("onedrive.appfolder");

        #endregion

    }

}