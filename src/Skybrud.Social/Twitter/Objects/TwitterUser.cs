using System;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Entities;

namespace Skybrud.Social.Twitter.Objects {
    
    /// <see>
    ///     <cref>https://dev.twitter.com/docs/platform-objects/users</cref>
    /// </see>
    public class TwitterUser : SocialJsonObject {

        #region Properties

        /// <summary>
        /// The integer representation of the unique identifier for this User. This number is greater
        /// than 64 bits and some programming languages may have difficulty/silent defects in
        /// interpreting it. Using a signed 64 bit integer for storing this identifier is safe.
        /// Use <code>id_str</code> for fetching the identifier to stay on the safe side.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// The string representation of the unique identifier for this Tweet.
        /// Implementations should use this rather than the large integer in id.
        /// <a href="http://groups.google.com/group/twitter-development-talk/browse_thread/thread/6a16efa375532182/">Discussion</a>.
        /// </summary>
        public string IdStr { get; private set; }

        /// <summary>
        /// The screen name, handle, or alias that this user identifies themselves with. <var>screen_names</var>
        /// are unique but subject to change. Use <var>id_str</var> as a user identifier whenever possible.
        /// Typically a maximum of 15 characters long, but some historical accounts may exist with longer names.
        /// </summary>
        public string ScreenName { get; private set; }

        /// <summary>
        /// The name of the user, as they've defined it. Not necessarily a person's name. Typically
        /// capped at 20 characters, but subject to change.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// <em>Nullable</em>. The user-defined location for this account's profile. Not necessarily a location
        /// nor parseable. This field will occasionally be fuzzily interpreted by the Search service.
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// <em>Nullable</em>. A URL provided by the user in association with their profile.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// <em>Nullable</em>. The user-defined UTF-8 string describing their account.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// When true, indicates that this user has chosen to protect their Tweets.
        /// See <a href="https://support.twitter.com/articles/14016">About Public and Protected Tweets</a>.
        /// </summary>
        public bool IsProtected { get; private set; }

        /// <summary>
        /// The number of followers this account currently has. Under certain conditions of duress,
        /// this field will temporarily indicate "0".
        /// </summary>
        public int FollowersCount { get; private set; }

        /// <summary>
        /// The number of users this account is following (AKA their "followings"). Under certain
        /// conditions of duress, this field will temporarily indicate "0".
        /// </summary>
        public int FriendsCount { get; private set; }

        /// <summary>
        /// The number of public lists that this user is a member of.
        /// </summary>
        public int ListedCount { get; private set; }

        /// <summary>
        /// The UTC datetime that the user account was created on Twitter.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// The number of tweets this user has favorited in the account's lifetime. British spelling used
        /// in the field name for historical reasons.
        /// </summary>
        public int FavouritesCount { get; private set; }

        /// <summary>
        /// The number of tweets this user has favorited in the account's lifetime.
        /// </summary>
        public int FavoritesCount {
            get { return FavouritesCount; }
        }

        /// <summary>
        /// <em>Nullable</em>. The offset from GMT/UTC in seconds.
        /// </summary>
        public int? UtcOffset { get; private set; }

        /// <summary>
        /// <em>Nullable</em>. A string describing the Time Zone this user declares themselves within.
        /// </summary>
        public string TimeZone { get; private set; }

        /// <summary>
        /// When true, indicates that the user has enabled the possibility of geotagging their Tweets.
        /// This field must be true for the current user to attach geographic data when using
        /// POST statuses/update.
        /// </summary>
        public bool IsGeoEnabled { get; private set; }

        /// <summary>
        /// When true, indicates that the user has a verified account.
        /// See <a href="https://support.twitter.com/articles/119135">Verified Accounts</a>.
        /// </summary>
        public bool IsVerified { get; private set; }

        /// <summary>
        /// The number of tweets (including retweets) issued by the user.
        /// </summary>
        public int StatusesCount { get; private set; }

        /// <summary>
        /// The <var>BCP 47</var> code for the user's self-declared user interface language.
        /// May or may not have anything to do with the content of their Tweets.
        /// </summary>
        /// <see cref="http://tools.ietf.org/html/bcp47" />
        public string Language { get; private set; }

        /// <summary>
        /// Indicates that the user has an account with "contributor mode" enabled, allowing for
        /// Tweets issued by the user to be co-authored by another account. Rarely <var>true</var>.
        /// </summary>
        public bool ContributorsEnabled { get; private set; }

        /// <summary>
        /// When true, indicates that the user is a participant in Twitter's translator community.
        /// </summary>
        public bool IsTranslator { get; private set; }

        /// <summary>
        /// <em>Nullable</em>. <em>Perspectival</em>. When true, indicates that the authenticating user has issued a
        /// follow request to this protected user account.
        /// </summary>
        public bool? FollowRequestSent { get; private set; }

        /// <summary>
        /// The hexadecimal color chosen by the user for their background.
        /// </summary>
        public string ProfileBackgroundColor { get; private set; }

        /// <summary>
        /// A HTTP-based URL pointing to the background image the user has uploaded for their
        /// profile.
        /// </summary>
        public string ProfileBackgroundImageUrl { get; private set; }

        /// <summary>
        /// A HTTPS-based URL pointing to the background image the user has uploaded for their
        /// profile.
        /// </summary>
        public string ProfileBackgroundImageUrlHttps { get; private set; }

        /// <summary>
        /// When true, indicates that the user's <var>profile_background_image_url</var> should be tiled
        /// when displayed.
        /// </summary>
        public bool ProfileBackgroundTile { get; private set; }

        /// <summary>
        /// The HTTPS-based URL pointing to the standard web representation of the user's uploaded
        /// profile banner. By adding a final path element of the URL, you can obtain different
        /// image sizes optimized for specific displays. In the future, an API method will be
        /// provided to serve these URLs so that you need not modify the original URL. For size
        /// variations, please see <a href="https://dev.twitter.com/docs/user-profile-images-and-banners">User Profile Images and Banners</a>.
        /// </summary>
        public string ProfileBannerUrl { get; private set; }

        /// <summary>
        /// A HTTP-based URL pointing to the user's avatar image. See <a href="https://dev.twitter.com/docs/user-profile-images-and-banners">User Profile Images and Banners</a>.
        /// </summary>
        public string ProfileImageUrl { get; private set; }

        /// <summary>
        /// A HTTPS-based URL pointing to the user's avatar image.
        /// </summary>
        public string ProfileImageUrlHttps { get; private set; }

        /// <summary>
        /// The hexadecimal color the user has chosen to display links with in their Twitter UI.
        /// </summary>
        public string ProfileLinkColor { get; private set; }

        /// <summary>
        /// The hexadecimal color the user has chosen to display sidebar borders with in their Twitter UI.
        /// </summary>
        public string ProfileSidebarBorderColor { get; private set; }

        /// <summary>
        /// The hexadecimal color the user has chosen to display sidebar backgrounds with in their Twitter UI.
        /// </summary>
        public string ProfileSidebarFillColor { get; private set; }

        /// <summary>
        /// The hexadecimal color the user has chosen to display text with in their Twitter UI.
        /// </summary>
        public string ProfileTextColor { get; private set; }

        /// <summary>
        /// When true, indicates the user wants their uploaded background image to be used.
        /// </summary>
        public bool ProfileUseBackgroundImage { get; private set; }

        /// <summary>
        /// Boolean	When true, indicates that the user has not altered the theme or background of their user profile.
        /// </summary>
        public bool HasDefaultProfile { get; private set; }

        /// <summary>
        /// When true, indicates that the user has not uploaded their own avatar and a default egg avatar is used instead.
        /// </summary>
        public bool HasDefaultProfileImage { get; private set; }

        /// <summary>
        /// <em>Nullable</em>. If possible, the user's most recent tweet or retweet. In some circumstances,
        /// this data cannot be provided and this field will be omitted, null, or empty. Perspectival
        /// attributes within tweets embedded within users cannot always be relied upon.
        /// See <a href="https://dev.twitter.com/docs/faq/#6981">Why are embedded objects stale or inaccurate?</a>.
        /// </summary>
        public object Status { get; private set; }

        /// <summary>
        /// Entities which have been parsed out of the url or description fields defined by the user.
        /// Read more about <a href="https://dev.twitter.com/docs/entities#users">Entities for Users</a>.
        /// </summary>
        public TwitterUserEntities Entities { get; private set; }

        #endregion

        #region Constructors

        private TwitterUser(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>TwitterUser</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static TwitterUser Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterUser(obj) {
                Id = obj.GetInt64("id"),
                IdStr = obj.GetString("id_str"),
                Name = obj.GetString("name"),
                ScreenName = obj.GetString("screen_name"),
                Location = obj.GetString("location"),
                Url = obj.GetString("url"),
                Description = obj.GetString("description"),
                IsProtected = obj.GetBoolean("protected"),
                FollowersCount = obj.GetInt32("followers_count"),
                FriendsCount = obj.GetInt32("friends_count"),
                ListedCount = obj.GetInt32("listed_count"),
                CreatedAt = TwitterUtils.ParseDateTime(obj.GetString("created_at")),
                FavouritesCount = obj.GetInt32("favourites_count"),
                UtcOffset = obj.HasValue("utc_offset") ? obj.GetInt32("utc_offset") : (int?) null,
                TimeZone = obj.GetString("time_zone"),
                IsGeoEnabled = obj.GetBoolean("geo_enabled"),
                IsVerified = obj.GetBoolean("verified"),
                StatusesCount = obj.GetInt32("statuses_count"),
                Language = obj.GetString("lang"),
                ContributorsEnabled = obj.GetBoolean("contributors_enabled"),
                IsTranslator = obj.GetBoolean("is_translator"),
                FollowRequestSent = obj.HasValue("follow_request_sent") && obj.GetBoolean("follow_request_sent"),
                Status = obj.GetObject("status", TwitterStatusMessage.Parse),
                Entities = obj.GetObject("entities", TwitterUserEntities.Parse),
                HasDefaultProfile = obj.GetBoolean("default_profile"),
                HasDefaultProfileImage = obj.GetBoolean("default_profile_image"),
                ProfileBackgroundColor = obj.GetString("profile_background_color"),
                ProfileBackgroundImageUrl = obj.GetString("profile_background_image_url"),
                ProfileBackgroundImageUrlHttps = obj.GetString("profile_background_image_url_https"),
                ProfileBackgroundTile = obj.GetBoolean("profile_background_tile"),
                ProfileBannerUrl = obj.GetString("profile_banner_url"),
                ProfileImageUrl = obj.GetString("profile_image_url"),
                ProfileImageUrlHttps = obj.GetString("profile_image_url_https"),
                ProfileLinkColor = obj.GetString("profile_link_color"),
                ProfileSidebarBorderColor = obj.GetString("profile_sidebar_border_color"),
                ProfileSidebarFillColor = obj.GetString("profile_sidebar_fill_color"),
                ProfileTextColor = obj.GetString("profile_text_color"),
                ProfileUseBackgroundImage = obj.GetBoolean("profile_use_background_image")
            };
        }

        #endregion

    }

}