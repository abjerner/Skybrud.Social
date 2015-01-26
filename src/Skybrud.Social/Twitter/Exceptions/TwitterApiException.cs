using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Twitter.Exceptions {

    public class TwitterApiException : Exception {

        #region Properties

        public SocialHttpResponse Response { get; private set; }

        public int Code { get; private set; }

        #endregion

        #region Constructors

        internal TwitterApiException(SocialHttpResponse response, string message, int code) : base(message) {
            Response = response;
            Code = code;
        }

        #endregion

    }

}