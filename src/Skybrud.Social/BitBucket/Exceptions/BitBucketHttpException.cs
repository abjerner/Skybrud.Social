using System;
using System.Net;

namespace Skybrud.Social.BitBucket.Exceptions {
    
    public class BitBucketHttpException : Exception {

        public HttpStatusCode StatusCode { get; private set; }

        public BitBucketHttpException(HttpStatusCode status) : base("Invalid response received from the BitBucket API (Status: " + ((int) status) + ")") {

            StatusCode = status;

        }

    }

}
