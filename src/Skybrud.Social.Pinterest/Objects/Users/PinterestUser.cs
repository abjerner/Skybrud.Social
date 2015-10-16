using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;
using Skybrud.Social.Time;

namespace Skybrud.Social.Pinterest.Objects.Users {
    
    public class PinterestUser : PinterestObject {

        #region Properties

        public string Id { get; private set; }

        public string Username { get; private set; }

        public string Bio { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string AccountType { get; private set; }

        public string Url { get; private set; }

        public SocialDateTime CreatedAt { get; private set; }

        public PinterestUserImage Image { get; private set; }

        public PinterestUserCounts Counts { get; private set; }

        public bool HasUsername {
            get { return !String.IsNullOrWhiteSpace(Username); }
        }

        public bool HasBio {
            get { return !String.IsNullOrWhiteSpace(Bio); }
        }

        public bool HasFirstName {
            get { return !String.IsNullOrWhiteSpace(FirstName); }
        }

        public bool HasLastName {
            get { return !String.IsNullOrWhiteSpace(LastName); }
        }

        public bool HasAccountType {
            get { return !String.IsNullOrWhiteSpace(AccountType); }
        }

        public bool HasUrl {
            get { return !String.IsNullOrWhiteSpace(Url); }
        }

        public bool HasCreatedAt {
            get { return CreatedAt != null; }
        }

        public bool HasImage {
            get { return Image != null; }
        }

        public bool HasCounts {
            get { return Counts != null; }
        }

        #endregion

        #region Constructors

        private PinterestUser(JObject obj) : base(obj) {
            Username = obj.GetString("username");
            Bio = obj.GetString("bio");
            FirstName = obj.GetString("first_name");
            LastName = obj.GetString("last_name");
            AccountType = obj.GetString("account_type");
            Url = obj.GetString("url");
            CreatedAt = obj.GetString("created_at", SocialDateTime.Parse);
            Image = obj.GetObject("image", PinterestUserImage.Parse);
            Counts = obj.GetObject("counts", PinterestUserCounts.Parse);
            Id = obj.GetString("id");
        }

        #endregion

        #region Static methods

        public static PinterestUser Parse(JObject obj) {
            return obj == null ? null : new PinterestUser(obj);
        }

        #endregion

    }

}