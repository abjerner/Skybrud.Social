using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Slack.Objects.Users {
    
    public class SlackUserProfile : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the first name of the user.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the last name of the user.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Gets the job title of the user, or <code>null</code> if not specified.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the real name of the user.
        /// </summary>
        public string RealName { get; private set; }

        /// <summary>
        /// Gets the normalized real name of the user.
        /// </summary>
        public string RealNameNormalized { get; private set; }

        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the Skype name of the user, or <code>null</code> if not specified.
        /// </summary>
        public string Skype { get; private set; }

        /// <summary>
        /// Gets the phone number of the user, or <code>null</code> if not specified.
        /// </summary>
        public string Phone { get; private set; }

        /// <summary>
        /// Gets the URL of the profile image in 24x24 pixels.
        /// </summary>
        public string Image24 { get; private set; }

        /// <summary>
        /// Gets the URL of the profile image in 32x32 pixels.
        /// </summary>
        public string Image32 { get; private set; }

        /// <summary>
        /// Gets the URL of the profile image in 48x48 pixels.
        /// </summary>
        public string Image48 { get; private set; }

        /// <summary>
        /// Gets the URL of the profile image in 72x72 pixels.
        /// </summary>
        public string Image72 { get; private set; }

        /// <summary>
        /// Gets the URL of the profile image in 192x192 pixels.
        /// </summary>
        public string Image192 { get; private set; }

        /// <summary>
        /// Gets whether the user has specified a job title.
        /// </summary>
        public bool HasTitle {
            get { return !String.IsNullOrWhiteSpace(Title); }
        }

        /// <summary>
        /// Gets whether the user has specified a Skype name.
        /// </summary>
        public bool HasSkype {
            get { return !String.IsNullOrWhiteSpace(Skype); }
        }

        /// <summary>
        /// Gets whether the user has specified a phone number.
        /// </summary>
        public bool HasPhone {
            get { return !String.IsNullOrWhiteSpace(Phone); }
        }

        #endregion

        #region Constructors

        private SlackUserProfile(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>SlackUserProfile</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static SlackUserProfile Parse(JsonObject obj) {
            if (obj == null) return null;
            return new SlackUserProfile(obj) {
                FirstName = obj.GetString("first_name"),
                LastName = obj.GetString("last_name"),
                Title = obj.GetString("title"),
                RealName = obj.GetString("real_name"),
                RealNameNormalized = obj.GetString("real_name_normalized"),
                Email = obj.GetString("email"),
                Skype = obj.GetString("skype"),
                Phone = obj.GetString("phone"),
                Image24 = obj.GetString("image_24"),
                Image32 = obj.GetString("image_32"),
                Image48 = obj.GetString("image_48"),
                Image72 = obj.GetString("image_72"),
                Image192 = obj.GetString("image_192")
            };
        }

        #endregion

    }

}