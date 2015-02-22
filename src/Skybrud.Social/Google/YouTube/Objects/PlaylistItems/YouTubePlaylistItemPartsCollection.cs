using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Google.YouTube.Objects.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems/list#part</cref>
    /// </see>
    public class YouTubePlaylistItemPartsCollection {

        #region Private fields

        private readonly List<YouTubePlaylistItemPart> _list = new List<YouTubePlaylistItemPart>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the amount of parts currently in the collection.
        /// </summary>
        public int Count {
            get { return _list.Count; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an empty collection.
        /// </summary>
        public YouTubePlaylistItemPartsCollection() { }

        /// <summary>
        /// Initializes a collection containing the specified parts.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public YouTubePlaylistItemPartsCollection(params YouTubePlaylistItemPart[] parts) {
            _list.AddRange(parts);
        }

        /// <summary>
        /// Initializes a collection containing the specified parts.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public YouTubePlaylistItemPartsCollection(IEnumerable<YouTubePlaylistItemPart> parts) {
            _list.AddRange(parts);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified part to the collection.
        /// </summary>
        /// <param name="part">The part to add.</param>
        public void Add(YouTubePlaylistItemPart part) {
            _list.Add(part);
        }

        /// <summary>
        /// Adds the specified range of parts to the collection.
        /// </summary>
        /// <param name="parts">The dimensions to add.</param>
        public void AddRange(IEnumerable<YouTubePlaylistItemPart> parts) {
            _list.AddRange(parts);
        }

        /// <summary>
        /// Gets an array of the parts currently in the collection.
        /// </summary>
        public YouTubePlaylistItemPart[] ToArray() {
            return _list.ToArray();
        }

        /// <summary>
        /// Gets a string array of the parts currently in the collection.
        /// </summary>
        public string[] ToStringArray() {
            return (from part in _list select part.Name).ToArray();
        }

        /// <summary>
        /// Gets a string representation if the parts currently in the collection.
        /// </summary>
        public override string ToString() {
            return String.Join(",", from part in _list select part.Name);
        }

        #endregion

        #region Operator overloading

        public static implicit operator YouTubePlaylistItemPartsCollection(YouTubePlaylistItemPart part) {
            return new YouTubePlaylistItemPartsCollection(part);
        }

        public static implicit operator YouTubePlaylistItemPartsCollection(YouTubePlaylistItemPart[] parts) {
            return new YouTubePlaylistItemPartsCollection(parts);
        }

        public static YouTubePlaylistItemPartsCollection operator +(YouTubePlaylistItemPartsCollection left, YouTubePlaylistItemPart right) {
            left.Add(right);
            return left;
        }

        public static implicit operator YouTubePlaylistItemPartsCollection(string[] parts) {
            return new YouTubePlaylistItemPartsCollection(from YouTubePlaylistItemPart part in parts select part);
        }

        #endregion

    }

}