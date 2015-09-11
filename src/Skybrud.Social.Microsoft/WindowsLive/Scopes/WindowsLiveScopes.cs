using Skybrud.Social.Microsoft.Scopes;

namespace Skybrud.Social.Microsoft.WindowsLive.Scopes {
    
    /// <see>
    ///     <cref>https://msdn.microsoft.com/en-us/library/hh243646.aspx</cref>
    /// </see>
    public class WindowsLiveScopes {

        #region Constants

        #region Core scopes

        /// <summary>
        /// Read access to a user's basic profile info. Also enables read access to a user's list of contacts.
        /// </summary>
        /// <see>
        ///     <cref>https://msdn.microsoft.com/en-us/library/hh243646.aspx#wlbasic</cref>
        /// </see>
        public static readonly MicrosoftScope Basic = new MicrosoftScope("wl.basic");

        /// <summary>
        /// The ability of an app to read and update a user's info at any time. Without this scope, an app can access
        /// the user's info only while the user is signed in to Live Connect and is using your app.
        /// </summary>
        /// <see>
        ///     <cref>https://msdn.microsoft.com/en-us/library/hh243646.aspx#wlofflineaccess</cref>
        /// </see>
        public static readonly MicrosoftScope OfflineAccess = new MicrosoftScope("wl.offline_access");

        /// <summary>
        /// Single sign-in behavior. With single sign-in, users who are already signed in to Live Connect are also
        /// signed in to your website.
        /// </summary>
        /// <see>
        ///     <cref>https://msdn.microsoft.com/en-us/library/hh243646.aspx#wlsignin</cref>
        /// </see>
        public static readonly MicrosoftScope Signin = new MicrosoftScope("wl.signin");

        #endregion

        #region Extended scopes

        /// <summary>
        /// Read access to a user's birthday info including birth day, month, and year.
        /// </summary>
        /// <see>
        ///     <cref>https://msdn.microsoft.com/en-us/library/hh243646.aspx#wlbirthday</cref>
        /// </see>
        public static readonly MicrosoftScope Birthday = new MicrosoftScope("wl.birthday");

        /// <summary>
        /// Read access to a user's personal, preferred, and business email addresses.
        /// </summary>
        /// <see>
        ///     <cref>https://msdn.microsoft.com/en-us/library/hh243646.aspx#wlemails</cref>
        /// </see>
        public static readonly MicrosoftScope Emails = new MicrosoftScope("wl.emails");

        #endregion

        #endregion

    }

}