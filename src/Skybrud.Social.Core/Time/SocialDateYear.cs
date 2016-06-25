using System;

namespace Skybrud.Social.Time {
    
    /// <summary>
    /// Class representing a year in the Gregorian calendar.
    /// </summary>
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/Gregorian_calendar</cref>
    /// </see>
    public class SocialDateYear {

        #region Properties

        /// <summary>
        /// Gets the year of this instance.
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// Gets whether the year is a leap year.
        /// </summary>
        public bool IsLeapYear {
            get { return SocialUtils.Time.IsLeapYear(Year); }
        }

        /// <summary>
        /// Gets the amount of days in the yeay - <code>366</code> if <see cref="IsLeapYear"/> is <code>true</code>, otherwise <code>365</code>.
        /// </summary>
        public int Days {
            get { return IsLeapYear ? 366 : 365; }
        }

        #region Calendar dates

        /// <summary>
        /// Gets the date of <strong>Palm Sunday</strong>, which falls on the Sunday before <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Palm_Sunday#Observance_in_the_liturgy</cref>
        /// </see>
        public DateTime PalmSunday {
            get { return SocialUtils.Dates.GetPalmSunday(Year); }
        }

        /// <summary>
        /// Gets the date of <strong>Moundy Thursday</strong>, which falls on the Thursday before <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Maundy_Thursday</cref>
        /// </see>
        public DateTime GetMoundyThursday {
            get { return SocialUtils.Dates.GetMoundyThursday(Year); }
        }

        /// <summary>
        /// Gets the date of <strong>Good Friday</strong>, which falls on the Friday before <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Good_Friday</cref>
        /// </see>
        public DateTime GetGoodFriday {
            get { return SocialUtils.Dates.GetGoodFriday(Year); }
        }

        /// <summary>
        /// Gets the date of <strong>Holy Saturday</strong>, which falls on the Saturday before <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Holy_Saturday</cref>
        /// </see>
        public DateTime GetHolySaturday {
            get { return SocialUtils.Dates.GetHolySaturday(Year); }
        }

        /// <summary>
        /// Gets the date of <strong>Easter Sunday</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://da.wikipedia.org/wiki/Påske#Beregning_af_p.C3.A5skedagens_dato</cref>
        /// </see>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Easter#Date</cref>
        /// </see>
        public DateTime EasterSunday {
            get { return SocialUtils.Dates.GetEasterSunday(Year); }
        }

        /// <summary>
        /// Gets the date of <strong>Easter Monday</strong>, which falls on the Monday after <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Easter_Monday</cref>
        /// </see>
        public DateTime EasterMonday {
            get { return SocialUtils.Dates.GetEasterMonday(Year); }
        }

        /// <summary>
        /// Gets the date of <strong>General Prayer Day</strong> (or <code>Store Bededag</code>in Danish) - a national
        /// holiday in Denmark. It falls on the 4th Friday after <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://da.wikipedia.org/wiki/Store_bededag</cref>
        /// </see>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Store_Bededag</cref>
        /// </see>
        public DateTime StoreBededag {
            get { return SocialUtils.Dates.Denmark.GetGeneralPrayerDay(Year); }
        }

        /// <summary>
        /// Gets the date of <strong>Ascension Day</strong>, which is celebrated on a Thursday, the fortieth day of
        /// <strong>Easter</strong> (the 6th Thursday after <strong>Moundy Thursday</strong>).
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Feast_of_the_Ascension</cref>
        /// </see>
        public DateTime AscensionDay {
            get { return SocialUtils.Dates.GetAscensionDay(Year); }
        }

        /// <summary>
        /// Gets the date of <strong>Whit Sunday</strong>, which is celebrated on the 7th Sunday after
        /// <strong>Easter</strong>.
        /// 
        /// Depending on the year, Whit Sunday falls within the period from the
        /// <code>10th of May</code> to the <code>13th of June</code> (both inclusive).
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Whitsun</cref>
        /// </see>
        public DateTime WhitSunday {
            get { return SocialUtils.Dates.GetWhitSunday(Year); }
        }

        /// <summary>
        /// Gets the date of <strong>Whit Monday</strong>, which is celebrated the day after
        /// <strong>Whit Sunday</strong>. Whit Sunday is the 7th Sunday after
        /// <strong>Easter</strong>.
        /// 
        /// Depending on the year, Whit Monday falls within the period from the <code>11th of May</code> to the
        /// <code>14th of June</code> (both inclusive).
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Whit_Monday</cref>
        /// </see>
        public DateTime WhitMonday {
            get { return SocialUtils.Dates.GetWhitMonday(Year); }
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <code>year</code>.
        /// </summary>
        /// <param name="year">The year.</param>
        public SocialDateYear(int year) {
            Year = year;
        }

        /// <summary>
        /// Initializes a new instance from the specified <code>timestamp</code>.
        /// </summary>
        /// <param name="timestamp">A timestamp represented by an instance of <see cref="DateTime"/>.</param>
        public SocialDateYear(DateTime timestamp) {
            Year = timestamp.Year;
        }

        /// <summary>
        /// Initializes a new instance from the specified <code>timestamp</code>.
        /// </summary>
        /// <param name="timestamp">A timestamp represented by an instance of <see cref="SocialDateTime"/>.</param>
        public SocialDateYear(SocialDateTime timestamp) {
            if (timestamp == null) throw new ArgumentNullException("timestamp");
            Year = timestamp.Year;
        }

        #endregion

    }

}