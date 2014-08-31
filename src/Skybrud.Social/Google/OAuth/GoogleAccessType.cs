namespace Skybrud.Social.Google.OAuth {

    /// <summary>
    /// Indicates whether your application needs to access a Google API when the user is not
    /// present at the browser. This parameter defaults to online. If your application needs to
    /// refresh access tokens when the user is not present at the browser, then use offline. This
    /// will result in your application obtaining a refresh token the first time your application
    /// exchanges an authorization code for a user.
    /// </summary>
    public enum GoogleAccessType {
        Online,
        Offline
    }

}