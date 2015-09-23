using System;
using Skybrud.Social.LinkedIn.Interfaces;
using Skybrud.Social.OAuth;

namespace Skybrud.Social.LinkedIn.OAuth1a {
    
    public class LinkedInOAuthClient : OAuthClient, ILinkedInOAuthClient {

        #region Constructors

        public LinkedInOAuthClient() : this(null, null, null, null, null) {
            // Call overloaded constructor
        }

        public LinkedInOAuthClient(string consumerKey, string consumerSecret) : this(consumerKey, consumerSecret, null, null, null) {
            // Call overloaded constructor
        }

        public LinkedInOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret) : this(consumerKey, consumerSecret, token, tokenSecret, null) {
            // Call overloaded constructor
        }

        public LinkedInOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret, string callback) {
        
            // Common properties
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Token = token;
            TokenSecret = tokenSecret;
            Callback = callback;

            // Specific to LinkedIn
            RequestTokenUrl = "https://api.linkedin.com/uas/oauth/requestToken";
            AuthorizeUrl = "https://api.linkedin.com/uas/oauth/authenticate";
            AccessTokenUrl = "https://api.linkedin.com/uas/oauth/accessToken";
        
        }

        public string Test(params string[] fields) {

            string url = "https://api.linkedin.com/v1/people/~" + ((fields.Length == 0) ? "" : (":(" + String.Join(",", fields) + ")"));

            return DoHttpRequestAsString("GET", url);

        }

        #endregion

        #region Methods from interface ILinkedInOAuthClient

        public string GetBasicProfile() {
            throw new NotImplementedException();
        }

        public string GetBasicProfile(string[] fields) {
            throw new NotImplementedException();
        }

        public string GetGroupPosts(long groupId) {
            return GetGroupPosts(groupId, LinkedInConstants.GroupPostsDefaultFields);
        }

        public string GetGroupPosts(long groupId, string[] fields) {

            // Declare the base URL
            string url = String.Format(
                "{0}{1}",
                "https://api.linkedin.com/v1/groups/" + groupId + "/posts",
                (fields.Length == 0) ? "" : (":(" + String.Join(",", fields) + ")")
            );

            // Make the request and return the response body
            return DoHttpRequestAsString("GET", url);

        }

        #endregion
    }

}