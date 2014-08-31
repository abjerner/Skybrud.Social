#region

using Skybrud.Social.Json;

#endregion

namespace Skybrud.Social.Facebook.Objects
{
    public class FacebookAlbum : SocialJsonObject {
        public long Id { get; set; }
        public FacebookObject From { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string CoverPhoto { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
        public string CreatedTime { get; set; }
        public string UpdatedTime { get; set; }
        public bool CanUpload { get; set; }


        /// <summary>
        ///     Gets a JSON string representing the object.
        /// </summary>
        public string ToJson()
        {
            return JsonObject == null ? null : JsonObject.ToJson();
        }

        /// <summary>
        ///     Saves the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path)
        {
            if (JsonObject != null) JsonObject.SaveJson(path);
        }

        /// <summary>
        ///     Loads a album from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static FacebookAlbum LoadJson(string path)
        {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        ///     Gets a album from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static FacebookAlbum ParseJson(string json)
        {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        ///     Gets a album from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static FacebookAlbum Parse(JsonObject obj)
        {
            if (obj == null) return null;
            return new FacebookAlbum
            {
                JsonObject = obj,
                Id = obj.GetLong("id"),
                From = obj.GetObject("from", FacebookObject.Parse),
                Name = obj.GetString("name"),
                Link = obj.GetString("link"),
                CoverPhoto = obj.GetString("cover_photo"),
                Count = obj.GetInt("count"),
                Type = obj.GetString("type"),
                CreatedTime = obj.GetString("created_time"),
                UpdatedTime = obj.GetString("updated_time"),
                CanUpload = obj.GetBoolean("can_upload")
            };
        }
    }
}