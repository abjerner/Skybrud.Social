using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;
using Skybrud.Social.Time;

namespace Skybrud.Social.Pinterest.Objects {

    public class PinterestError : PinterestObject {

        #region Properties
        
        /// <summary>
        /// Gets the status of the exception.
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// Gets the error code of the exception.
        /// </summary>
        public int Code { get; private set; }

        public string Host { get; private set; }

        public SocialDateTime GeneratedAt { get; private set; }

        public string Message { get; private set; }

        public string Type { get; private set; }

        #endregion

        #region Constructors

        private PinterestError(JObject obj) : base(obj) {
            Status = obj.GetString("status");
            Code = obj.GetInt32("code");
            Host = obj.GetString("host");
            GeneratedAt = obj.GetString("generated_at", SocialDateTime.Parse);
            Message = obj.GetString("message");
            Type = obj.GetString("type");
        }

        #endregion

        #region Static methods

        public static PinterestError Parse(JObject obj) {
            return obj == null ? null : new PinterestError(obj);
        }

        #endregion

    }

}