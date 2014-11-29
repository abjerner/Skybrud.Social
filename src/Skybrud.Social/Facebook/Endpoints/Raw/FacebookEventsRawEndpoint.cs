using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookEventsRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructor

        internal FacebookEventsRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        public SocialHttpResponse GetEvents(string identifier, int limit = 0) {

            // Declare the query string
            SocialQueryString query = new SocialQueryString();
            if (limit > 0) query.Set("limit", limit);

            // Make the call to the API
            return Client.DoAuthenticatedGetRequest("https://graph.facebook.com/v1.0/" + identifier + "/events", query);

        }

        #endregion

    }

}