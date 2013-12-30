using System;

namespace Skybrud.Social.Google.Exceptions {
    
    public class GoogleApiException : Exception {

        #region Properties

        public int Code { get; private set; }

        #endregion

        #region Constructors

        public GoogleApiException(int code, string message) : base(message) {
            Code = code;
        }

        #endregion

    }

}
