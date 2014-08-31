using System;
using System.Linq;
using System.Reflection;

namespace Skybrud.Social.Google.YouTube.Objects.Playlist {
    
    public class YouTubePlaylistPart {

        public static readonly YouTubePlaylistPart Id = new YouTubePlaylistPart("id");
        public static readonly YouTubePlaylistPart Snippet = new YouTubePlaylistPart("snippet");
        public static readonly YouTubePlaylistPart Status = new YouTubePlaylistPart("status");

        #region Static properties

        public static YouTubePlaylistPart[] Values {
            get {
                return (
                    from property in typeof(YouTubePlaylistPart).GetFields(BindingFlags.Public | BindingFlags.Static)
                    select (YouTubePlaylistPart) property.GetValue(null)
                ).ToArray();
            }
        }

        #endregion

        public string Name { get; private set; }

        private YouTubePlaylistPart(string name) {
            Name = name;
        }

        #region Static methods

        public static YouTubePlaylistPart Parse(string str) {
            YouTubePlaylistPart part;
            if (TryParse(str, out part)) return part;
            throw new Exception("Invalid part '" + str + "'");
        }

        public static bool TryParse(string str, out YouTubePlaylistPart part) {
            part = Values.FirstOrDefault(temp => temp.Name == str);
            return part != null;
        }

        #endregion

        #region Operator overloading

        public static implicit operator YouTubePlaylistPart(string name) {
            return Parse(name);
        }

        public static YouTubePlaylistPartsCollection operator +(YouTubePlaylistPart left, YouTubePlaylistPart right) {
            return new YouTubePlaylistPartsCollection(left, right);
        }

        #endregion
    
    }

}