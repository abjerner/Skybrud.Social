using System;
using System.Net;

namespace Skybrud.Social.OAuth {
    
    public class OAuthException : Exception {

        public HttpStatusCode StatusCode { get; private set; }

        public OAuthException(HttpStatusCode status, string message) : base(message) {
            StatusCode = status;
        }

    }

}