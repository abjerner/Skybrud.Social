using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Google.YouTube.Objects.Channels {

    public class YouTubeChannelPartsCollection {

        #region Private fields

        private readonly List<YouTubeChannelPart> _list = new List<YouTubeChannelPart>();

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
        public YouTubeChannelPartsCollection() {
            // Expose parameterless constructor
        }

        /// <summary>
        /// Initializes a collection containing the specified parts.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public YouTubeChannelPartsCollection(params YouTubeChannelPart[] parts) {
            _list.AddRange(parts);
        }

        /// <summary>
        /// Initializes a collection containing the specified parts.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public YouTubeChannelPartsCollection(IEnumerable<YouTubeChannelPart> parts) {
            _list.AddRange(parts);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified part to the collection.
        /// </summary>
        /// <param name="part">The part to add.</param>
        public void Add(YouTubeChannelPart part) {
            _list.Add(part);
        }

        /// <summary>
        /// Adds the specified range of parts to the collection.
        /// </summary>
        /// <param name="parts">The dimensions to add.</param>
        public void AddRange(IEnumerable<YouTubeChannelPart> parts) {
            _list.AddRange(parts);
        }

        /// <summary>
        /// Gets an array of the parts currently in the collection.
        /// </summary>
        public YouTubeChannelPart[] ToArray() {
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

        public static implicit operator YouTubeChannelPartsCollection(YouTubeChannelPart part) {
            return new YouTubeChannelPartsCollection(part);
        }

        public static implicit operator YouTubeChannelPartsCollection(YouTubeChannelPart[] parts) {
            return new YouTubeChannelPartsCollection(parts);
        }

        public static YouTubeChannelPartsCollection operator +(YouTubeChannelPartsCollection left, YouTubeChannelPart right) {
            left.Add(right);
            return left;
        }

        public static implicit operator YouTubeChannelPartsCollection(string[] parts) {
            return new YouTubeChannelPartsCollection(from YouTubeChannelPart part in parts select part);
        }

        #endregion

    }

}