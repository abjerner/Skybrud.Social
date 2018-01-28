using Skybrud.Essentials.Time;

namespace Skybrud.Social.Interfaces {

    /// <summary>
    /// Interface describing an object in a timeline.
    /// </summary>
    public interface ISocialTimelineEntry {

        /// <summary>
        /// Gets the date of the object that represents how the object can be sorted in a timeline.
        /// </summary>
        EssentialsDateTime SortDate { get; }

    }

}
