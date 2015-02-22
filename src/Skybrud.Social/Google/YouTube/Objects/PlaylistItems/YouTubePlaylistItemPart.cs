using System;
using System.Linq;

namespace Skybrud.Social.Google.YouTube.Objects.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems/list#part</cref>
    /// </see>
    public class YouTubePlaylistItemPart {

        #region Properties

        public static readonly YouTubePlaylistItemPart Id = new YouTubePlaylistItemPart("id");
        public static readonly YouTubePlaylistItemPart Snippet = new YouTubePlaylistItemPart("snippet");
        public static readonly YouTubePlaylistItemPart ContentDetails = new YouTubePlaylistItemPart("contentDetails");
        public static readonly YouTubePlaylistItemPart Status = new YouTubePlaylistItemPart("status");

        public static readonly YouTubePlaylistItemPartsCollection Basic = new YouTubePlaylistItemPartsCollection(
            Id, Snippet
        );

        public static readonly YouTubePlaylistItemPartsCollection All = new YouTubePlaylistItemPartsCollection(
            Id, Snippet, ContentDetails, Status, Status
        );

        public static YouTubePlaylistItemPart[] Values {
            get { return All.ToArray(); }
        }

        public string Name { get; private set; }

        #endregion

        #region Constructors

        private YouTubePlaylistItemPart(string name) {
            Name = name;
        }

        #endregion

        #region Static methods

        public static YouTubePlaylistItemPart Parse(string str) {
            YouTubePlaylistItemPart part;
            if (TryParse(str, out part)) return part;
            throw new Exception("Invalid part '" + str + "'");
        }

        public static bool TryParse(string str, out YouTubePlaylistItemPart part) {
            part = Values.FirstOrDefault(temp => temp.Name == str);
            return part != null;
        }

        #endregion

        #region Operator overloading

        public static implicit operator YouTubePlaylistItemPart(string name) {
            return Parse(name);
        }

        public static YouTubePlaylistItemPartsCollection operator +(YouTubePlaylistItemPart left, YouTubePlaylistItemPart right) {
            return new YouTubePlaylistItemPartsCollection(left, right);
        }

        #endregion
    
    }

}