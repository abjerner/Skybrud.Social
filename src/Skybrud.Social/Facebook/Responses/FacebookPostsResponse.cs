using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {

    public class FacebookPostsResponse : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets an array of all posts in the response.
        /// </summary>
        public FacebookPostSummary[] Data { get; private set; }

        /// <summary>
        /// Gets an array of all posts in the response.
        /// </summary>
        public FacebookPostSummary[] Posts {
            get { return Data; }
        }

        public FacebookPaging Paging {
            get; private set;
        }

        #endregion

        #region Constructors

        private FacebookPostsResponse(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookPostsResponse ParseJson(string contents) {
            return Parse(JsonConverter.ParseObject(contents));
        }

        public static FacebookPostsResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookApiException.Parse);
            return new FacebookPostsResponse(obj) {
                Data = obj.GetArray("data", FacebookPostSummary.Parse),
                Paging = obj.GetObject("paging", FacebookPaging.Parse)
            };
        }

        #endregion

    }

}
