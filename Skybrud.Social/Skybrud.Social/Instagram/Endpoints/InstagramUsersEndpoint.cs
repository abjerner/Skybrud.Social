using System.Collections.Specialized;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Responses;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Endpoints {

    public class InstagramUsersEndpoint {

        protected InstagramService Service;

        internal InstagramUsersEndpoint(InstagramService service) {
            Service = service;
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">The name of the user.</param>
        public InstagramUsersResponse Search(string query) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection {
                {"access_token", Service.AccessToken},
                {"q", query}
            };

            // Perform the call to the API
            return InstagramUsersResponse.Parse(SocialUtils.DoHttpGetRequestAndGetBodyAsJsonObject("https://api.instagram.com/v1/users/search", qs));

        }

        /// <summary>
        /// Gets the information about a user by the specified ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        public InstagramUser GetInfo(long id) {

            // Perform the call to the API
            JsonObject obj = SocialUtils.DoHttpGetRequestAndGetBodyAsJsonObject("https://api.instagram.com/v1/users/" + id + "/?access_token=" + Service.AccessToken);

            // Validate the response
            InstagramResponse.ValidateResponse(obj);

            // Parse the object
            return obj.GetObject("data", InstagramUser.Parse);

        }

        #region Get media

        /// <summary>
        /// API description: Get the most recent media published by a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">Count of media to return.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public string GetMediaAsRawJson(long userId, int count) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection { { "access_token", Service.AccessToken } };
            if (count > 0) qs.Add("count", count + "");

            // Perform the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/users/" + userId + "/media/recent/", qs);

        }

        /// <summary>
        /// The the most recent media of the current user.
        /// </summary>
        public InstagramRecentMediaResponse GetMedia() {
            return GetMedia(Service.CurrentUser.Id);
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramRecentMediaResponse GetMedia(long userId) {
            return GetMedia(userId, 0);
        }

        /// <summary>
        /// Gets the most recent media of the user with the specified ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">Count of media to return.</param>
        public InstagramRecentMediaResponse GetMedia(long userId, int count) {
            return InstagramRecentMediaResponse.ParseJson(GetMediaAsRawJson(userId, count));
        }

        #endregion

    }

}
