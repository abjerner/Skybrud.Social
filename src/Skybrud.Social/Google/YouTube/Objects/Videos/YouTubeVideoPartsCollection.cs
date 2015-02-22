using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Google.YouTube.Objects.Videos {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos/list#part</cref>
    /// </see>
    public class YouTubeVideoPartsCollection {

        #region Private fields

        private readonly List<YouTubeVideoPart> _list = new List<YouTubeVideoPart>();

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
        public YouTubeVideoPartsCollection() { }

        /// <summary>
        /// Initializes a collection containing the specified parts.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public YouTubeVideoPartsCollection(params YouTubeVideoPart[] parts) {
            _list.AddRange(parts);
        }

        /// <summary>
        /// Initializes a collection containing the specified parts.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public YouTubeVideoPartsCollection(IEnumerable<YouTubeVideoPart> parts) {
            _list.AddRange(parts);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified part to the collection.
        /// </summary>
        /// <param name="part">The part to add.</param>
        public void Add(YouTubeVideoPart part) {
            _list.Add(part);
        }

        /// <summary>
        /// Adds the specified range of parts to the collection.
        /// </summary>
        /// <param name="parts">The dimensions to add.</param>
        public void AddRange(IEnumerable<YouTubeVideoPart> parts) {
            _list.AddRange(parts);
        }

        /// <summary>
        /// Gets an array of the parts currently in the collection.
        /// </summary>
        public YouTubeVideoPart[] ToArray() {
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

        public static implicit operator YouTubeVideoPartsCollection(YouTubeVideoPart part) {
            return new YouTubeVideoPartsCollection(part);
        }

        public static implicit operator YouTubeVideoPartsCollection(YouTubeVideoPart[] parts) {
            return new YouTubeVideoPartsCollection(parts);
        }

        public static YouTubeVideoPartsCollection operator +(YouTubeVideoPartsCollection left, YouTubeVideoPart right) {
            left.Add(right);
            return left;
        }

        public static implicit operator YouTubeVideoPartsCollection(string[] parts) {
            return new YouTubeVideoPartsCollection(from YouTubeVideoPart part in parts select part);
        }

        #endregion

    }

}