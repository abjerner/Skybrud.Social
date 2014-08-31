using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Exceptions {

    public class FacebookException : Exception {

        public int Code { get; private set; }
        public string Type { get; private set; }
        public int Subcode { get; private set; }

        public FacebookException(int code, string type, string message, int subcode = 0) : base(message) {
            Code = code;
            Type = type;
            Subcode = subcode;
        }

        public static FacebookException Parse(JsonObject obj) {

            return new FacebookException(
                obj.GetInt("code"),
                obj.GetString("type"),
                obj.GetString("message"),
                obj.HasValue("error_subcode") ? obj.GetInt("error_subcode") : 0
            );

        }

    }

}
