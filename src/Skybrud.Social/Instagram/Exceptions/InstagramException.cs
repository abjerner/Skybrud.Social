using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Exceptions {

    public class InstagramException : Exception {

        public int Code { get; private set; }
        public string Type { get; private set; }

        internal InstagramException(int code, string type, string message) : base(message) {
            Code = code;
            Type = type;
        }

        internal InstagramException(JsonObject obj) : base(obj.GetString("error_message")) {
            Code = obj.GetInt("code");
            Type = obj.GetString("error_type");
        }

    }

}
