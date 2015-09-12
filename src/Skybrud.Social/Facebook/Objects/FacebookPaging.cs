using System;
using System.Collections.Specialized;
using System.Web;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookPaging : SocialJsonObject {

        #region Properties

        /// <summary>
        /// A link to the previous page.
        /// </summary>
        public string Previous { get; private set; }

        /// <summary>
        /// A link to the next page.
        /// </summary>
        public string Next { get; private set; }

        /// <summary>
        /// The timestamp used for the <var>Previous</var> link.
        /// </summary>
        public int? Since {
            get {
                if (Previous != null) {
                    NameValueCollection response = SocialUtils.ParseQueryString(Previous);
                    if (response["since"] != null) return Int32.Parse(response["since"]);
                }
                return null;
            }
        }

        /// <summary>
        /// The timestamp used for the <var>Next</var> link.
        /// </summary>
        public int? Until {
            get {
                if (Next != null) {
                    NameValueCollection response = SocialUtils.ParseQueryString(Next);
                    if (response["until"] != null) return Int32.Parse(response["until"]);
                }
                return null;
            }
        }

        #endregion

        #region Constructors

        private FacebookPaging(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookPaging Parse(JsonObject obj) {
            // TODO: Should we just return NULL if "obj" is NULL?
            if (obj == null) return new FacebookPaging(null);
            return new FacebookPaging(obj) {
                Previous =  obj.GetString("previous"),
                Next = obj.GetString("next")
            };
        }

        #endregion

    }

}