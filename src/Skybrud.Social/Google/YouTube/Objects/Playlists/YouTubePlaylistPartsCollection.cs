using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Google.YouTube.Objects.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists/list#part</cref>
    /// </see>
    public class YouTubePlaylistPartsCollection {

        #region Private fields

        private readonly List<YouTubePlaylistPart> _list = new List<YouTubePlaylistPart>();

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
        public YouTubePlaylistPartsCollection() {
            // Expose parameterless constructor
        }

        /// <summary>
        /// Initializes a collection containing the specified parts.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public YouTubePlaylistPartsCollection(params YouTubePlaylistPart[] parts) {
            _list.AddRange(parts);
        }

        /// <summary>
        /// Initializes a collection containing the specified parts.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public YouTubePlaylistPartsCollection(IEnumerable<YouTubePlaylistPart> parts) {
            _list.AddRange(parts);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified part to the collection.
        /// </summary>
        /// <param name="part">The part to add.</param>
        public void Add(YouTubePlaylistPart part) {
            _list.Add(part);
        }

        /// <summary>
        /// Adds the specified range of parts to the collection.
        /// </summary>
        /// <param name="parts">The dimensions to add.</param>
        public void AddRange(IEnumerable<YouTubePlaylistPart> parts) {
            _list.AddRange(parts);
        }

        /// <summary>
        /// Gets an array of the parts currently in the collection.
        /// </summary>
        public YouTubePlaylistPart[] ToArray() {
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

        public static implicit operator YouTubePlaylistPartsCollection(YouTubePlaylistPart part) {
            return new YouTubePlaylistPartsCollection(part);
        }

        public static implicit operator YouTubePlaylistPartsCollection(YouTubePlaylistPart[] parts) {
            return new YouTubePlaylistPartsCollection(parts);
        }

        public static YouTubePlaylistPartsCollection operator +(YouTubePlaylistPartsCollection left, YouTubePlaylistPart right) {
            left.Add(right);
            return left;
        }

        public static implicit operator YouTubePlaylistPartsCollection(string[] parts) {
            return new YouTubePlaylistPartsCollection(from YouTubePlaylistPart part in parts select part);
        }

        #endregion

    }

}