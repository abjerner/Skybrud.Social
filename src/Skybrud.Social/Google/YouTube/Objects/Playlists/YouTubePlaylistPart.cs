using System;
using System.Linq;

namespace Skybrud.Social.Google.YouTube.Objects.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists/list#part</cref>
    /// </see>
    public class YouTubePlaylistPart {

        #region Properties

        public static readonly YouTubePlaylistPart Id = new YouTubePlaylistPart("id");
        public static readonly YouTubePlaylistPart Snippet = new YouTubePlaylistPart("snippet");
        public static readonly YouTubePlaylistPart Status = new YouTubePlaylistPart("status");
        public static readonly YouTubePlaylistPart ContentDetails = new YouTubePlaylistPart("contentDetails");

        public static readonly YouTubePlaylistPartsCollection Basic = new YouTubePlaylistPartsCollection(
            Id, Snippet
        );

        public static readonly YouTubePlaylistPartsCollection All = new YouTubePlaylistPartsCollection(
            Id, Snippet, Status, ContentDetails
        );

        public static YouTubePlaylistPart[] Values {
            get { return All.ToArray(); }
        }

        public string Name { get; private set; }

        #endregion

        #region Constructors

        private YouTubePlaylistPart(string name) {
            Name = name;
        }

        #endregion

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