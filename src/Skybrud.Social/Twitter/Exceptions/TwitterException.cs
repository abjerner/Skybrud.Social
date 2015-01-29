using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Twitter.Exceptions {

    public class TwitterException : Exception {

        #region Properties

        public SocialHttpResponse Response { get; private set; }

        public int Code { get; private set; }

        #endregion

        #region Constructors

        internal TwitterException(SocialHttpResponse response, string message, int code) : base(message) {
            Response = response;
            Code = code;
        }

        #endregion

    }

}