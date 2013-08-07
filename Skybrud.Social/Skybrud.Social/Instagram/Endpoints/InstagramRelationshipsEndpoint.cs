using Skybrud.Social.Instagram.Exceptions;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Responses;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Endpoints {

    public class InstagramRelationshipsEndpoint {

        protected InstagramService Service;

        internal InstagramRelationshipsEndpoint(InstagramService service) {
            Service = service;
        }

        /// <summary>
        /// Get the list of users this user follows.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramUserSummary[] Follows(long userId) {

            // Perform the call to the API
            JsonObject obj = SocialUtils.DoHttpGetRequestAndGetBodyAsJsonObject("https://api.instagram.com/v1/users/" + userId + "/follows?access_token=" + Service.AccessToken);
            
            // Validate the response
            InstagramResponse.ValidateResponse(obj);

            // Parse the array
            return obj.GetArray("data", InstagramUserSummary.Parse);

        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// 
        /// Required scope: relationships
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramUserSummary[] FollowedBy(long userId) {

            // Perform the call to the API
            JsonObject obj = SocialUtils.DoHttpGetRequestAndGetBodyAsJsonObject("https://api.instagram.com/v1/users/" + userId + "/followed-by?access_token=" + Service.AccessToken);

            // Validate the response
            InstagramResponse.ValidateResponse(obj);

            // Parse the array
            return obj.GetArray("data", InstagramUserSummary.Parse);

        }

    }

}
