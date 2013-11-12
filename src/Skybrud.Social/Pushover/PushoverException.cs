using System;
using System.Net;

namespace Skybrud.Social.Pushover {

    public class PushoverException : Exception {

        public int StatusCode {
            get; internal set;
        }

        public string[] Errors {
            get; internal set;
        }

        public PushoverException(int statusCode, string[] errors) : base(errors == null || errors.Length == 0 ? null : statusCode + ": " + errors[0]) {
            StatusCode = statusCode;
            Errors = errors;
        }

        public PushoverException(HttpStatusCode statusCode, string[] errors) : base(errors == null || errors.Length == 0 ? null : statusCode + ": " + errors[0]) {
            StatusCode = (int) statusCode;
            Errors = errors;
        }

    }

}
