using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Microsoft.WindowsLive.Objects.Users {
    
    public class WindowsLiveUser : SocialJsonObject {

        #region Properties

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Gender { get; private set; }

        public string Link { get; private set; }

        public WindowsLiveUserEmailsInfo Emails { get; private set; }

        public string Locale { get; private set; }

        public DateTime? UpdatedTime { get; private set; }

        #endregion

        #region Constructors

        private WindowsLiveUser(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>WindowsLiveUser</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static WindowsLiveUser Parse(JsonObject obj) {
            if (obj == null) return null;
            return new WindowsLiveUser(obj) {
                Id = obj.GetString("id"),
                Name = obj.GetString("name"),
                FirstName = obj.GetString("first_name"),
                LastName = obj.GetString("last_name"),
                Gender = obj.GetString("gender"),
                Link = obj.GetString("link"),
                Emails = obj.GetObject("emails", WindowsLiveUserEmailsInfo.Parse),
                Locale = obj.GetString("locale"),
                UpdatedTime = obj.HasValue("updated_time") ? obj.GetString("updated_time", DateTime.Parse) : (DateTime?) null
            };
        }

        #endregion

    }

}