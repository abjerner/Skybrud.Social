using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookAlbum : SocialJsonObject {

        #region Properties

        public string Id { get; set; }
        public FacebookObject From { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string CoverPhoto { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
        public string CreatedTime { get; set; }
        public string UpdatedTime { get; set; }
        public bool CanUpload { get; set; }

        #endregion

        #region Constructor

        private FacebookAlbum(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an album from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static FacebookAlbum LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an album from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static FacebookAlbum ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an album from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static FacebookAlbum Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookAlbum(obj) {
                Id = obj.GetString("id"),
                From = obj.GetObject("from", FacebookObject.Parse),
                Name = obj.GetString("name"),
                Link = obj.GetString("link"),
                CoverPhoto = obj.GetString("cover_photo"),
                Count = obj.GetInt32("count"),
                Type = obj.GetString("type"),
                CreatedTime = obj.GetString("created_time"),
                UpdatedTime = obj.GetString("updated_time"),
                CanUpload = obj.GetBoolean("can_upload")
            };
        }

        #endregion

    }

}