using Skybrud.Social.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options.Lists;

namespace Skybrud.Social.Twitter.Endpoints.Raw {
    
    /// <summary>
    /// Raw implementation of the favorites endpoint.
    /// </summary>
    public class TwitterListsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwitterOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal TwitterListsRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the list with the specified <code>listId</code>.
        /// </summary>
        /// <param name="listId">The ID of the list.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/show</cref>
        /// </see>
        public SocialHttpResponse GetList(long listId) {
            return GetList(new TwitterGetListOptions {
                Id = listId
            });
        }

        /// <summary>
        /// Gets information about the list with the specified <code>listId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/show</cref>
        /// </see>
        public SocialHttpResponse GetList(long userId, string slug) {
            return GetList(new TwitterGetListOptions {
                UserId = userId,
                Slug = slug
            });
        }

        /// <summary>
        /// Gets information about the list with the specified <code>listId</code>.
        /// </summary>
        /// <param name="screenName">The screen name of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/show</cref>
        /// </see>
        public SocialHttpResponse GetList(string screenName, string slug) {
            return GetList(new TwitterGetListOptions {
                ScreenName = screenName,
                Slug = slug
            });
        }

        /// <summary>
        /// Gets information about the list matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/show</cref>
        /// </see>
        public SocialHttpResponse GetList(TwitterGetListOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/lists/list.json", options);
        }

        /// <summary>
        /// Gets a list of list of the authenticated user.
        /// </summary>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/list</cref>
        /// </see>
        public SocialHttpResponse GetLists() {
            return GetLists(default(TwitterGetListsOptions));
        }

        /// <summary>
        /// Gets a list of lists of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/list</cref>
        /// </see>
        public SocialHttpResponse GetLists(long userId) {
            return GetLists(new TwitterGetListsOptions {
                UserId = userId
            });
        }

        /// <summary>
        /// Gets a list of lists of the user with the specified <code>screenName</code>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/list</cref>
        /// </see>
        public SocialHttpResponse GetLists(string screenName) {
            return GetLists(new TwitterGetListsOptions {
                ScreenName = screenName
            });
        }

        /// <summary>
        /// Gets a list of lists of the user matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/list</cref>
        /// </see>
        public SocialHttpResponse GetLists(TwitterGetListsOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/lists/list.json", options);
        }

        /// <summary>
        /// Gets the lists owned by the user with the specified <code>userId</code>. Private lists will only be shown
        /// if the authenticated user is also the owner of the lists.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/ownerships</cref>
        /// </see>
        public SocialHttpResponse GetOwnerships(long userId) {
            return GetOwnerships(new TwitterGetOwnershipsOptions {
                UserId = userId
            });
        }

        /// <summary>
        /// Gets the lists owned by the user with the specified <code>screenName</code>. Private lists will only be
        /// shown if the authenticated user is also the owner of the lists.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/ownerships</cref>
        /// </see>
        public SocialHttpResponse GetOwnerships(string screenName) {
            return GetOwnerships(new TwitterGetOwnershipsOptions {
                ScreenName = screenName
            });
        }

        /// <summary>
        /// Gets the lists owned by the user matching the specified <code>options</code>. Private lists will only be
        /// shown if the authenticated user is also the owner of the lists.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/ownerships</cref>
        /// </see>
        public SocialHttpResponse GetOwnerships(TwitterGetOwnershipsOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/lists/list.json", options);
        }

        /// <summary>
        /// Gets a list the user with the specified <code>userId</code> is a member of.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/memberships</cref>
        /// </see>
        public SocialHttpResponse GetMemberships(long userId) {
            return GetMemberships(new TwitterGetMembershipsOptions {
                UserId = userId
            });
        }

        /// <summary>
        /// Gets a list the user with the specified <code>screenName</code> is a member of.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/memberships</cref>
        /// </see>
        public SocialHttpResponse GetMemberships(string screenName) {
            return GetMemberships(new TwitterGetMembershipsOptions {
                ScreenName = screenName
            });
        }

        /// <summary>
        /// Gets the list the user matching the specified <code>options</code> is a member of.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/memberships</cref>
        /// </see>
        public SocialHttpResponse GetMemberships(TwitterGetMembershipsOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/lists/memberships.json", options);
        }

        /// <summary>
        /// Gets the members of the list with the specified <code>listId</code>.
        /// </summary>
        /// <param name="listId">The ID of the list.</param>
        /// <see>
        ///     <cref>https://api.twitter.com/1.1/lists/members.json</cref>
        /// </see>
        public SocialHttpResponse GetMembers(long listId) {
            return GetMembers(new TwitterGetMembersOptions {
                Id = listId
            });
        }

        /// <summary>
        /// Gets the member of the list matching the specified <code>userId</code> and <code>slug</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="slug">The slug of the list.</param>
        /// <see>
        ///     <cref>https://api.twitter.com/1.1/lists/members.json</cref>
        /// </see>
        public SocialHttpResponse GetMembers(long userId, string slug) {
            return GetMembers(new TwitterGetMembersOptions {
                UserId = userId,
                Slug = slug
            });
        }

        /// <summary>
        /// Gets the members of the list matching the specified <code>screenName</code> and <code>slug</code>.
        /// </summary>
        /// <param name="screenName">The screen name of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        /// <see>
        ///     <cref>https://api.twitter.com/1.1/lists/members.json</cref>
        /// </see>
        public SocialHttpResponse GetMembers(string screenName, string slug) {
            return GetMembers(new TwitterGetMembersOptions {
                ScreenName = screenName,
                Slug = slug
            });
        }

        /// <summary>
        /// Gets the members of the list matching the specified <code>options</code>. Private list members will only be
        /// shown if the authenticated user owns the specified list.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://api.twitter.com/1.1/lists/members.json</cref>
        /// </see>
        public SocialHttpResponse GetMembers(TwitterGetMembersOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/lists/members.json", options);
        }

        #endregion

    }

}