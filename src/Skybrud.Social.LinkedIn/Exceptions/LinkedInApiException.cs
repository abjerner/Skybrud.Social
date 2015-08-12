using System;
using System.Xml.Linq;
using Skybrud.Social.LinkedIn.ExtensionMethods;

namespace Skybrud.Social.LinkedIn.Exceptions {
    
    public class LinkedInApiException : Exception {
        
        public int Status { get; private set; }
        public int Timestamp { get; private set; }
        public string RequestId { get; private set; }
        public int ErrorCode { get; private set; }

        public LinkedInApiException(XElement xml) : base(xml.GetElementValueOrDefault<string>("message")) {
            Status = xml.GetElementValueOrDefault<int>("status");
            Timestamp = xml.GetElementValueOrDefault<int>("timestamp");
            RequestId = xml.GetElementValueOrDefault<string>("request-id");
            ErrorCode = xml.GetElementValueOrDefault<int>("error-code");
        }
    
    }

}
