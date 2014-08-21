namespace Skybrud.Social.Google.OAuth {

    /// <summary>
    /// Indicates whether the user should be re-prompted for consent. The default is auto, so a
    /// given user should only see the consent page for a given set of scopes the first time
    /// through the sequence. If the value is force, then the user sees a consent page even if
    /// they previously gave consent to your application for a given set of scopes.
    /// </summary>
    public enum GoogleApprovalPrompt {
        Auto,
        Force
    }

}