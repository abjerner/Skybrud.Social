using System;
using System.Globalization;

namespace Skybrud.Social.Time {
    
    /// <summary>
    /// Class wrapping an instance to <code>DateTime</code> (as an alternative to using <code>DateTime?</code>).
    /// </summary>
    public class SocialDateTime {

        #region Properties

        /// <summary>
        /// Gets the wrapped <code>DateTime</code>.
        /// </summary>
        public DateTime DateTime { get; private set; }


        // Returns the day-of-month part of this DateTime. The returned
        // value is an integer between 1 and 31.
        //
        public int Day {
            get { return DateTime.Day; }
        }

        // Returns the day-of-week part of this DateTime. The returned value
        // is an integer between 0 and 6, where 0 indicates Sunday, 1 indicates
        // Monday, 2 indicates Tuesday, 3 indicates Wednesday, 4 indicates
        // Thursday, 5 indicates Friday, and 6 indicates Saturday.
        //
        public DayOfWeek DayOfWeek {
            get { return DateTime.DayOfWeek; }
        }

        // Returns the day-of-year part of this DateTime. The returned value
        // is an integer between 1 and 366.
        //
        public int DayOfYear {
            get { return DateTime.DayOfYear; }
        }

        // Returns the hour part of this DateTime. The returned value is an
        // integer between 0 and 23.
        //
        public int Hour {
            get { return DateTime.Hour; }
        }

        public DateTimeKind Kind {
            get { return DateTime.Kind; }
        }

        // Returns the millisecond part of this DateTime. The returned value
        // is an integer between 0 and 999.
        //
        public int Millisecond {
            get { return DateTime.Millisecond; }
        }

        // Returns the minute part of this DateTime. The returned value is
        // an integer between 0 and 59.
        //
        public int Minute {
            get { return DateTime.Minute; }
        }

        // Returns the month part of this DateTime. The returned value is an
        // integer between 1 and 12.
        //
        public int Month {
            get { return DateTime.Month; }
        }

        // Returns the second part of this DateTime. The returned value is
        // an integer between 0 and 59.
        //
        public int Second {
            get { return DateTime.Second; }
        }

        // Returns the tick count for this DateTime. The returned value is
        // the number of 100-nanosecond intervals that have elapsed since 1/1/0001
        // 12:00am.
        //
        public long Ticks {
            get { return DateTime.Ticks; }
        }

        // Returns the time-of-day part of this DateTime. The returned value
        // is a TimeSpan that indicates the time elapsed since midnight.
        //
        public TimeSpan TimeOfDay {
            get { return DateTime.TimeOfDay; }
        }
        
        // Returns the year part of this DateTime. The returned value is an
        // integer between 1 and 9999.
        //
        public int Year {
            get { return DateTime.Year; }
        }

        #endregion

        #region Constructors

        public SocialDateTime() {
            DateTime = new DateTime();
        }

        public SocialDateTime(DateTime dt) {
            DateTime = dt;
        }

        public SocialDateTime(long ticks) {
            DateTime = new DateTime(ticks);
        }      
 
        public SocialDateTime(long ticks, DateTimeKind kind) {
            DateTime = new DateTime(ticks, kind);  
        }    
             
        public SocialDateTime(int year, int month, int day) {
            DateTime = new DateTime(year, month, day);
        }

        public SocialDateTime(int year, int month, int day, Calendar calendar) {
            DateTime = new DateTime(year, month, day, calendar);
        }
    
        public SocialDateTime(int year, int month, int day, int hour, int minute, int second) {
            DateTime = new DateTime(year, month, day, hour, minute, second);
        }

        public SocialDateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind) {
            DateTime = new DateTime(year, month, day, hour, minute, second, kind);
        }
    
        public SocialDateTime(int year, int month, int day, int hour, int minute, int second, Calendar calendar) {
            DateTime = new DateTime(year, month, day, hour, minute, second, calendar);
        }

        public SocialDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
        }

        public SocialDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond, kind);
        }

        public SocialDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond, calendar);
        }

        public SocialDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind);
        }

        #endregion

        #region Member methods

        public override string ToString() {
            return DateTime.ToString(DateTimeFormatInfo.CurrentInfo);
        }

        public string ToString(IFormatProvider provider) {
            return DateTime.ToString(provider);
        }

        public string ToString(string format) {
            return DateTime.ToString(format, DateTimeFormatInfo.CurrentInfo);
        }

        public string ToString(string format, IFormatProvider provider) {
            return DateTime.ToString(format, provider);
        }

        #endregion

        #region Static methods

        public static SocialDateTime Parse(string str) {
            if (String.IsNullOrWhiteSpace(str)) return null;
            return new SocialDateTime(DateTime.Parse(str));
        }

        #endregion

    }

}