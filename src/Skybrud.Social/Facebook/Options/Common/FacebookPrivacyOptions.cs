using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Facebook.Enums;

namespace Skybrud.Social.Facebook.Options.Common {
    
    public class FacebookPrivacyOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the value of the privacy setting.
        /// </summary>
        public FacebookPrivacy Value { get; set; }

        /// <summary>
        /// When <code>Value</code> is <code>Custom</code>, this is a comma-separated list of user IDs and friend list
        /// IDs that <strong>can</strong> see the post. This can also be <code>ALL_FRIENDS</code> or
        /// <code>FRIENDS_OF_FRIENDS</code> to include all members of those sets.
        /// </summary>
        public string[] Allow { get; set; }

        /// <summary>
        /// When <code>Value</code> is <code>Custom</code>, this is a comma-separated list of user IDs and friend list
        /// IDs that cannot see the post.
        /// </summary>
        public string[] Deny { get; set; }

        #endregion

        #region Member methods

        public override string ToString() {
           
            // If set to "Default", the privacy shouldn't be specified
            if (Value == FacebookPrivacy.Default) return "";
            
            // Initialize an instance of JObject
            JObject json = new JObject();

            // Add the "Value" property
            string value = "";
            foreach (char chr in Value.ToString()) {
                if (chr >= 65 && chr <= 90) {
                    value += "_" + chr;
                } else if (chr >= 97 && chr <= 122) {
                    value += (char) (chr - 32);
                } else {
                    value += chr; 
                }
            }
            json.Add("value", value.Trim('_'));

            // Add the "Allow" and/or "Deny" properties
            if (Value == FacebookPrivacy.Custom) {
                if (Allow != null && Allow.Length > 0) json.Add("allow", String.Join(",", Allow));
                if (Deny != null && Deny.Length > 0) json.Add("deny", String.Join(",", Deny));
            }

            // Serialize to a JSON string
            return json.ToString(Formatting.None);

        }

        #endregion

    }

}
