using System.Net;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubFollowingResponse : GitHubResponse {

        #region Properties

        public bool IsFollowing { get; private set; }

        #endregion

        #region Constructor

        private GitHubFollowingResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        public static GitHubFollowingResponse ParseResponse(SocialHttpResponse response) {

            switch (response.StatusCode) {

                case HttpStatusCode.NoContent:
                    return new GitHubFollowingResponse(response) {
                        IsFollowing = true
                    };

                case HttpStatusCode.NotFound:
                    return new GitHubFollowingResponse(response) {
                        IsFollowing = false
                    };

                default:

                    // Parse the raw JSON response
                    JsonObject obj = response.GetBodyAsJsonObject();

                    string message = obj.GetString("message");
                    string url = obj.GetString("documentation_url");
                    throw new GitHubHttpException(response.StatusCode, message, url);
                    
            }

        }

    }

}
