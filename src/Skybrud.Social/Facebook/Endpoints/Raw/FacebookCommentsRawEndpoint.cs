using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookCommentsRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructor

        internal FacebookCommentsRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        public SocialHttpResponse GetSummary(string id) {
            SocialQueryString query = new SocialQueryString();
            query.Add("limit", 0);
            query.Add("summary", true);
            return Client.DoAuthenticatedGetRequest("https://graph.facebook.com/v1.0/" + id + "/comments", query);
        }

        #endregion

    }

}