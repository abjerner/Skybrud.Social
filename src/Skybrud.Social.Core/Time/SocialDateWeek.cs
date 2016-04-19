namespace Skybrud.Social.Time {

    /// <summary>
    /// Class representing a week as defined by the ISO8601 specification.
    /// </summary>
    public class SocialDateWeek {

        #region Properties

        /// <summary>
        /// Gets the year of the week.
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// Gets the number of the week.
        /// </summary>
        public int Week { get; private set; }

        /// <summary>
        /// Gets a reference to the timestamp representing the start of the week.
        /// </summary>
        public SocialDateTime Start { get; private set; }

        /// <summary>
        /// Gets a reference to the timestamp representing the end of the week.
        /// </summary>
        public SocialDateTime End { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance based on the specified <code>timestamp</code>.
        /// </summary>
        /// <param name="timestamp">A timestamp.</param>
        public SocialDateWeek(SocialDateTime timestamp) {

            Week = SocialUtils.Time.GetIso8601WeekNumber(timestamp);
            Start = SocialUtils.Time.GetFirstDayOfWeek(timestamp.DateTime);
            End = SocialUtils.Time.GetLastDayOfWeek(timestamp.DateTime);

            if (End.Month == 1 && Week == 1) {
                Year = End.Year;
            } else if (Start.Month == 12 && Week >= 50) {
                Year = Start.Year;
            } else {
                Year = timestamp.Year;
            }

        }

        #endregion

    }

}