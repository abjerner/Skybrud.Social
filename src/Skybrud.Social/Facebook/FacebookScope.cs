using System;
using System.Collections.Generic;

namespace Skybrud.Social.Facebook {
    
    /// <summary>
    /// Class representing a scope of the Facebook Graph API.
    /// </summary>
    public class FacebookScope {

        #region Private fields

        private static readonly Dictionary<string, FacebookScope> Scopes = new Dictionary<string, FacebookScope>();

        #endregion

        #region Constants

        #region Extended permissions

        #region Read Permissions
        
        /// <summary>
        /// Lets the application read your friendlists.
        /// </summary>
        public static readonly FacebookScope ReadFriendlists = new FacebookScope(
            "read_friendlists",
            "Provides access to any friend lists the user created. All user's friends are provided as part of basic data, this extended permission grants access to the lists of friends a user has created, and should only be requested if your application utilizes lists of friends."
        );
        
        public static readonly FacebookScope ReadInsights = new FacebookScope(
            "read_insights",
            "Provides read access to the Insights data for pages, applications, and domains the user owns."
        );
        
        public static readonly FacebookScope ReadMailbox = new FacebookScope(
            "read_mailbox",
            "Provides the ability to read from a user's Facebook Inbox."
        );
        
        public static readonly FacebookScope ReadRequests = new FacebookScope(
            "read_requests",
            "Provides read access to the user's friend requests."
        );

        /// <summary>
        /// Lets the application read your stream.
        /// </summary>
        public static readonly FacebookScope ReadStream = new FacebookScope(
            "read_stream",
            "Provides access to all the posts in the user's News Feed and enables your application to perform searches against the user's News Feed."
        );
        
        public static readonly FacebookScope XmppLogin = new FacebookScope(
            "xmpp_login",
            "Provides applications that integrate with Facebook Chat the ability to log in users."
        );
        
        public static readonly FacebookScope UserOnlinePresence = new FacebookScope(
            "user_online_presence",
            "Provides access to the user's online/offline presence."
        );
        
        public static readonly FacebookScope FriendsOnlinePresence = new FacebookScope(
            "friends_online_presence",
            "Provides access to the user's friend's online/offline presence."
        );

        #endregion

        #region Publish Permissions
        
        public static readonly FacebookScope AdsManagement = new FacebookScope(
            "ads_management",
            "Provides the ability to manage ads and call the Facebook Ads API on behalf of a user."
        );
        
        public static readonly FacebookScope CreateEvent = new FacebookScope(
            "create_event",
            "Enables your application to create and modify events on the user's behalf."
        );
        
        public static readonly FacebookScope ManageFriendlists = new FacebookScope(
            "manage_friendlists",
            "Enables your app to create and edit the user's friend lists."
        );
        
        public static readonly FacebookScope ManageNotifications = new FacebookScope(
            "manage_notifications",
            "Enables your app to read notifications and mark them as read. <strong>Intended usage:</strong> This permission should be used to let users read and act on their notifications; it should not be used to for the purposes of modeling user behavior or data mining. Apps that misuse this permission may be banned from requesting it."
        );
        
        public static readonly FacebookScope PublishActions = new FacebookScope(
            "publish_actions",
            "Enables your app to post content, comments and likes to a user's stream <a href=\"/docs/facebook-login/overview/#logindialog\">and requires extra permissions from a person using your app</a>. Because this permission lets you publish on behalf of a user please read the <a href=\"/policy/\">Platform Policies</a> to ensure you understand how to properly use this permission. Note, you do <strong>not</strong> need to request the <code>publish_actions</code> permission in order to use the <a href=\"/docs/reference/dialogs/feed/\">Feed Dialog</a>, the <a href=\"/docs/reference/dialogs/requests/\">Requests Dialog</a> or the <a href=\"/docs/reference/dialogs/send/\">Send Dialog</a>.  Facebook used to have a permission called <code>publish_stream</code>, <code>publish_actions</code> replaces it in most cases, for users.  For pages, <code>publish_stream</code> is still required to publish to a page's timeline."
        );
        
        public static readonly FacebookScope PublishStream = new FacebookScope(
            "publish_stream",
            "The <code>publish_stream</code> permission is required to post to a Facebook Page's timeline.  For a Facebook User use <code>publish_actions</code>."
        );
        
        public static readonly FacebookScope RsvpEvent = new FacebookScope(
            "rsvp_event",
            "Enables your application to RSVP to events on the user's behalf."
        );

        #endregion

        #endregion

        #region Email Permissions
        
        public static readonly FacebookScope Email = new FacebookScope(
            "email",
            "Provides access to the user's primary email address in the <code>email</code> property.  Do not spam users.  Your use of email must comply both with <a href=\"https://www.facebook.com/terms.php\">Facebook policies</a> and with the <a href=\"http://www.ftc.gov/bcp/edu/pubs/business/ecommerce/bus61.shtm\">CAN-SPAM Act</a>."
        );

        #endregion

        #region Page Permissions
        
        /// <summary>
        /// Lets the application manage pages that you have access to.
        /// </summary>
        public static readonly FacebookScope ManagePages = new FacebookScope(
            "manage_pages",
            "Enables your application to retrieve access_tokens for Pages and Applications that the user administrates.  The access tokens can be queried by calling <code>/&lt;user_id&gt;/accounts</code> via the Graph API. <br> See <a href=\"https://developers.facebook.com/roadmap/offline-access-removal/#page_access_token\">here</a> for generating long-lived Page access tokens that do not expire after 60 days."
        );

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string Description { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default and private constructor.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public FacebookScope(string name, string description = null) {
            Name = name;
            Description = String.IsNullOrWhiteSpace(description) ? null : description.Trim();
        }

        #endregion

        #region Member methods

        public override string ToString() {
            return Name;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal static FacebookScope RegisterScope(string name, string description = null) {
            FacebookScope scope = new FacebookScope(name, description);
            Scopes.Add(scope.Name, scope);
            return scope;
        }

        /// <summary>
        /// Attempts to get a scope with the specified <code>name</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Gets a scope matching the specified <code>name</code>, or <code>null</code> if not found-</returns>
        public static FacebookScope GetScope(string name) {
            FacebookScope scope;
            return Scopes.TryGetValue(name, out scope) ? scope : null;
        }

        /// <summary>
        /// Gets whether the scope is a known scope.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Returns <code>true</code> if the specified <code>name</code> matches a known
        /// scope, otherwise <code>false</code>.</returns>
        public static bool ScopeExists(string name) {
            return Scopes.ContainsKey(name);
        }

        #endregion
        
        #region Operators

        /// <summary>
        /// Adding two instances of <code>FacebookScope</code> will result in a
        /// <code>FacebookScopeCollection</code> containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static FacebookScopeCollection operator +(FacebookScope left, FacebookScope right) {
            return new FacebookScopeCollection(left, right);
        }

        #endregion

    }

}