using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options;
using Skybrud.Social.Twitter.Options.Favorites;
using Skybrud.Social.Twitter.Responses;

namespace Skybrud.Social.Twitter.Endpoints {
    
    /// <summary>
    /// Implementation of the favorites endpoint.
    /// </summary>
    public class TwitterFavoritesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw favorites endpoint.
        /// </summary>
        public TwitterFavoritesRawEndpoint Raw {
            get { return Service.Client.Favotires; }
        }

        #endregion

        #region Constructors

        internal TwitterFavoritesEndpoint(TwitterService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of favorites of the authenticated user.
        /// </summary>
        public TwitterTimelineResponse GetFavorites() {
            return TwitterTimelineResponse.ParseResponse(Raw.GetFavorites());
        }

        /// <summary>
        /// Gets a list of favorites of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterTimelineResponse GetFavorites(long userId) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetFavorites(userId));
        }

        /// <summary>
        /// Gets a list of favorites of the user with the specified <code>screenName</code>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterTimelineResponse GetFavorites(string screenName) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetFavorites(screenName));
        }

        /// <summary>
        /// Gets a list of favorites based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public TwitterTimelineResponse GetFavorites(TwitterGetFavoritesOptions options) {
            return TwitterTimelineResponse.ParseResponse(Raw.GetFavorites(options));
        }

        /// <summary>
        /// Favorites the status message with the specified <code>statusId</code> as the authenticating user.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        public TwitterStatusMessageResponse Create(long statusId) {
            return TwitterStatusMessageResponse.ParseResponse(Raw.Create(statusId));
        }

        /// <summary>
        /// Un-favorites the status message with the specified <code>statusId</code> as the authenticating user.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        public TwitterStatusMessageResponse Destroy(long statusId) {
            return TwitterStatusMessageResponse.ParseResponse(Raw.Destroy(statusId));
        }

        #endregion

    }

}