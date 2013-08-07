using System.Collections.Specialized;
using Skybrud.Social.Json;
using Skybrud.Social.Vimeo.Advanced.Responses;

namespace Skybrud.Social.Vimeo.Advanced.Endpoints {
    
    public class VimeoPeopleEndpoint {

        public VimeoService Service { get; private set; }

        internal VimeoPeopleEndpoint(VimeoService service) {
            Service = service;
        }

        #region Method: vimeo.people.getInfo

        public string GetInfoAsRawJson(string userId) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"format", "json"},
                {"method", "vimeo.people.getInfo"},
                {"user_id", userId }
            };

            // Call the Vimeo API
            return Service.Client.DoHttpRequestAsString("GET", "http://vimeo.com/api/rest/v2", query, null);
        
        }

        /// <summary>
        /// API description: Get information about a user.
        /// </summary>
        /// <see cref="https://developer.vimeo.com/apis/advanced/methods/vimeo.people.getInfo"/>
        public VimeoUserResponse GetInfo() {
            return GetInfo(Service.Client.Token);
        }

        /// <summary>
        /// API description: Get information about a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <see cref="https://developer.vimeo.com/apis/advanced/methods/vimeo.people.getInfo"/>
        public VimeoUserResponse GetInfo(int userId) {
            return GetInfo(userId + "");
        }

        /// <summary>
        /// API description: Get information about a user.
        /// </summary>
        /// <param name="userId">An ID, username or access token identifying the user.</param>
        /// <see cref="https://developer.vimeo.com/apis/advanced/methods/vimeo.people.getInfo"/>
        public VimeoUserResponse GetInfo(string userId) {
            return VimeoUserResponse.Parse(JsonConverter.ParseObject(GetInfoAsRawJson(userId)));
        }

        #endregion

    }

}