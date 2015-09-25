using Skybrud.Social.LinkedIn.Interfaces;
using Skybrud.Social.LinkedIn.Responses;

using LinkedInOAuth1aClient = Skybrud.Social.LinkedIn.OAuth1a.LinkedInOAuthClient;
using LinkedInOAuth2Client = Skybrud.Social.LinkedIn.OAuth2.LinkedInOAuthClient;

namespace Skybrud.Social.LinkedIn {

    public class LinkedInService {

        public ILinkedInOAuthClient Client { get; private set; }

        private LinkedInService() {
            // Hide default constructor
        }

        /// <summary>
        /// Initializes a new service based on the specified OAuth 1.0a client.
        /// </summary>
        /// <param name="client">The OAuth client to use.</param>
        public static LinkedInService CreateFromOAuthClient(LinkedInOAuth1aClient client) {
            return new LinkedInService {
                Client = client
            };
        }

        /// <summary>
        /// Initializes a new service based on the specified OAuth 2.0 client.
        /// </summary>
        /// <param name="client">The OAuth client to use.</param>
        public static LinkedInService CreateFromOAuthClient(LinkedInOAuth2Client client) {
            return new LinkedInService {
                Client = client
            };
        }

        /// <summary>
        /// Initializes a new service based on the specified OAuth 2.0 access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static LinkedInService CreateFromAccessToken(string accessToken) {
            return new LinkedInService {
                Client = new LinkedInOAuth2Client {
                    AccessToken = accessToken
                }
            };
        }

        public LinkedInPostsResponse GetGroupPosts(long groupId) {
            return GetGroupPosts(groupId, LinkedInConstants.GroupPostsDefaultFields);
        }

        public LinkedInPostsResponse GetGroupPosts(long groupId, string[] fields) {
            return LinkedInPostsResponse.ParseXml(Client.GetGroupPosts(groupId, fields));
        }

        public LinkedInBasicProfileResponse GetBasicProfile() {
            return GetBasicProfile(LinkedInConstants.BasicProfileDefaultFields);
        }

        public LinkedInBasicProfileResponse GetBasicProfile(string[] fields) {
            string xmlResponse = Client.GetBasicProfile(fields);
            return LinkedInBasicProfileResponse.ParseXml(xmlResponse);
        }

    }

}