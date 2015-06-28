using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options.Lists;
using Skybrud.Social.Twitter.Responses.Lists;

namespace Skybrud.Social.Twitter.Endpoints {
    
    /// <summary>
    /// Implementation of the lists endpoint.
    /// </summary>
    public class TwitterListsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw lists endpoint.
        /// </summary>
        public TwitterListsRawEndpoint Raw {
            get { return Service.Client.Lists; }
        }

        #endregion

        #region Constructors

        internal TwitterListsEndpoint(TwitterService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the list with the specified <code>listId</code>.
        /// </summary>
        /// <param name="listId">The ID of the list.</param>
        public TwitterListResponse GetList(long listId) {
            return TwitterListResponse.ParseResponse(Raw.GetList(listId));
        }

        /// <summary>
        /// Gets information about the list with the specified <code>listId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        public TwitterListResponse GetList(long userId, string slug) {
            return TwitterListResponse.ParseResponse(Raw.GetList(userId, slug));
        }

        /// <summary>
        /// Gets information about the list with the specified <code>listId</code>.
        /// </summary>
        /// <param name="screenName">The screen name of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        public TwitterListResponse GetList(string screenName, string slug) {
            return TwitterListResponse.ParseResponse(Raw.GetList(screenName, slug));
        }

        /// <summary>
        /// Gets information about the list matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public TwitterListResponse GetList(TwitterGetListOptions options) {
            return TwitterListResponse.ParseResponse(Raw.GetList(options));
        }

        /// <summary>
        /// Gets a list of list of the authenticated user.
        /// </summary>
        /// <returns></returns>
        public TwitterListsResponse GetLists() {
            return TwitterListsResponse.ParseResponse(Raw.GetLists());
        }

        /// <summary>
        /// Gets a list of lists of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterListsResponse GetLists(long userId) {
            return TwitterListsResponse.ParseResponse(Raw.GetLists(userId));
        }

        /// <summary>
        /// Gets a list of lists of the user with the specified <code>screenName</code>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterListsResponse GetLists(string screenName) {
            return TwitterListsResponse.ParseResponse(Raw.GetLists(screenName));
        }

        #endregion

    }

}