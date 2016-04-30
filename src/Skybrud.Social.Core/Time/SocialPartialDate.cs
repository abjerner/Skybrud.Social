using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Time {

    /// <summary>
    /// Class representing a partial date (eg. only year and month).
    /// </summary>
    public class SocialPartialDate {

        #region Properties

        /// <summary>
        /// Gets the year, or <code>0</code> if not specified.
        /// </summary>
        public int Year { get; private set; }
        
        /// <summary>
        /// Gets the month, or <code>0</code> if not specified.
        /// </summary>
        public int Month { get; private set; }
        
        /// <summary>
        /// Gets the day, or <code>0</code> if not specified.
        /// </summary>
        public int Day { get; private set; }

        /// <summary>
        /// Gets an instance of <code>DateTime</code> representing the publication date. This instance will not be
        /// realiable in the way that an instance of <code>DateTime</code> can't represent a partial date.
        /// </summary>
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// Gets whether a year has been specified for this date.
        /// </summary>
        public bool HasYear {
            get { return Year > 0; }
        }
        
        /// <summary>
        /// Gets whether a month has been specified for this date.
        /// </summary>
        public bool HasMonth {
            get { return Month > 0; }
        }
        
        /// <summary>
        /// Gets whether a day has been specified for this date.
        /// </summary>
        public bool HasDay {
            get { return Day > 0; }
        }
        
        /// <summary>
        /// Gets whether the date is partial (missing either year, month or day).
        /// </summary>
        public bool IsPartialDate {
            get { return HasYear && HasMonth && HasDay; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <code>date</code>.
        /// </summary>
        /// <param name="date">An instance of <see cref="SocialDateTime"/> representing the full date.</param>
        public SocialPartialDate(SocialDateTime date) {
            Year = date == null ? 0 : date.Year;
            Month = date == null ? 0 : date.Month;
            Day = date == null ? 0 : date.Day;
            DateTime = new DateTime(Year == 0 ? 1 : Year, Month == 0 ? 1 : Month, Day == 0 ? 1 : Day);
        }

        /// <summary>
        /// Initializes a new instance from the specified <code>year</code>, <code>month</code> and <code>day</code>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        /// <param name="day">The day of the date.</param>
        public SocialPartialDate(int year, int month, int day) {
            Year = Math.Max(0, year);
            Month = Math.Max(0, month);
            Day = Math.Max(0, day);
            DateTime = new DateTime(Year == 0 ? 1 : Year, Month == 0 ? 1 : Month, Day == 0 ? 1 : Day);
        }

        #endregion

        #region Member methods

        public override string ToString() {
            return String.Format("{0:0000}-{1:00}-{2:00}", Year, Month, Day);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>str</code>. If the string is either <code>null</code> or whitespace,
        /// <code>null</code> will be returned. The method will parse dates specified in the format
        /// <code>yyyy-MM-dd</code>. If specified in any other format, an exception will be thrown.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>Returnns an instance of <see cref="SocialPartialDate"/>.</returns>
        public static SocialPartialDate Parse(string str) {
            if (String.IsNullOrWhiteSpace(str)) return null;
            Match match = Regex.Match(str, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$");
            if (!match.Success) throw new ArgumentException("Specified string is not a valid date", "str");
            return new SocialPartialDate(
                Int32.Parse(match.Groups[1].Value),
                Int32.Parse(match.Groups[2].Value),
                Int32.Parse(match.Groups[3].Value)
            );
        }

        #endregion

    }

}