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

        /// <summary>
        /// Returns the day-of-month part of this <code>SocialDateTime</code>. The returned value is an integer between
        /// <code>1</code> and <code>31</code>.
        /// </summary>
        public int Day {
            get { return DateTime.Day; }
        }

        /// <summary>
        /// Returns the day-of-week part of this <code>SocialDateTime</code>. The returned value is an integer between
        /// <code>0</code> and <code>6</code>, where <code>0</code> indicates <strong>Sunday</strong>, <code>1</code>
        /// indicates <strong>Monday</strong>, <code>2</code> indicates <strong>Tuesday</strong>, <code>3</code>
        /// indicates <strong>Wednesday</strong>, <code>4</code> indicates <strong>Thursday</strong>, <code>5</code>
        /// indicates <strong>Friday</strong>, and <code>6</code> indicates <strong>Saturday</strong>.
        /// </summary>
        public DayOfWeek DayOfWeek {
            get { return DateTime.DayOfWeek; }
        }

        /// <summary>
        /// Gets the day-of-year part of this <code>SocialDateTime</code>. The returned value is an integer between <code>1</code> and <code>366</code>.
        /// </summary>
        public int DayOfYear {
            get { return DateTime.DayOfYear; }
        }

        /// <summary>
        /// Gets the hour part of this DateTime. The returned value is an integer between <code>0</code> and <code>23</code>.
        /// </summary>
        public int Hour {
            get { return DateTime.Hour; }
        }

        /// <summary>
        /// Gets the kind of the underlying <code>DateTime</code>.
        /// </summary>
        public DateTimeKind Kind {
            get { return DateTime.Kind; }
        }

        /// <summary>
        /// Gets the millisecond part of this <code>SocialDateTime</code>. The returned value is an integer between <code>0</code> and <code>999</code>.
        /// </summary>
        public int Millisecond {
            get { return DateTime.Millisecond; }
        }

        /// <summary>
        /// Gets the minute part of this <code>SocialDateTime</code>. The returned value is an integer between <code>0</code> and <code>59</code>.
        /// </summary>
        public int Minute {
            get { return DateTime.Minute; }
        }

        /// <summary>
        /// Gets the month part of this <code>SocialDateTime</code>. The returned value is an integer between <code>1</code> and <code>12</code>.
        /// </summary>
        public int Month {
            get { return DateTime.Month; }
        }

        /// <summary>
        /// Gets the second part of this <code>SocialDateTime</code>. The returned value is an integer between <code>0</code> and <code>59</code>.
        /// </summary>
        public int Second {
            get { return DateTime.Second; }
        }

        /// <summary>
        /// Gets the tick count for this <code>SocialDateTime</code>. The returned value is the number of 100-nanosecond intervals that have elapsed since <code>1/1/0001 12:00am</code>.
        /// </summary>
        public long Ticks {
            get { return DateTime.Ticks; }
        }

        /// <summary>
        /// Gets the time-of-day part of this <code>SocialDateTime</code>. The returned value is a <code>TimeSpan</code> that indicates the time elapsed since midnight.
        /// </summary>
        public TimeSpan TimeOfDay {
            get { return DateTime.TimeOfDay; }
        }
        
        /// <summary>
        /// Returns the year part of this <code>SocialDateTime</code>. The returned value is an integer between <code>1</code> and <code>9999</code>.
        /// </summary>
        public int Year {
            get { return DateTime.Year; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on <code>DateTime.MinValue</code>.
        /// </summary>
        public SocialDateTime() {
            DateTime = DateTime.MinValue;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>dt</code>.
        /// </summary>
        /// <param name="dt">The an instance <code>DateTime</code> the instance should be based on.</param>
        public SocialDateTime(DateTime dt) {
            DateTime = dt;
        }

        /// <summary>
        /// Initializes a new instance based on the specified amount of <code>ticks</code>.
        /// </summary>
        /// <param name="ticks">The amount <code>ticks</code> the instance should be based on.</param>
        public SocialDateTime(long ticks) {
            DateTime = new DateTime(ticks);
        }

        /// <summary>
        /// Initializes a new instance based on the specified amount of <code>ticks</code> and <code>kind</code>.
        /// </summary>
        /// <param name="ticks">The amount <code>ticks</code> the instance should be based on.</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public SocialDateTime(long ticks, DateTimeKind kind) {
            DateTime = new DateTime(ticks, kind);  
        }    

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code> and
        /// <code>day</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        public SocialDateTime(int year, int month, int day) {
            DateTime = new DateTime(year, month, day);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code> and
        /// <code>day</code> for the specified <code>calendar</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        public SocialDateTime(int year, int month, int day, Calendar calendar) {
            DateTime = new DateTime(year, month, day, calendar);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>, <code>day</code>,
        /// <code>hour</code>, <code>minute</code> and <code>second</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        public SocialDateTime(int year, int month, int day, int hour, int minute, int second) {
            DateTime = new DateTime(year, month, day, hour, minute, second);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>, <code>day</code>,
        /// <code>hour</code>, <code>minute</code>, <code>second</code> and <code>kind</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public SocialDateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind) {
            DateTime = new DateTime(year, month, day, hour, minute, second, kind);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>, <code>day</code>,
        /// <code>hour</code>, <code>minute</code> and <code>second</code> for the specified <code>calendar</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        public SocialDateTime(int year, int month, int day, int hour, int minute, int second, Calendar calendar) {
            DateTime = new DateTime(year, month, day, hour, minute, second, calendar);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>, <code>day</code>,
        /// <code>hour</code>, <code>minute</code>, <code>second</code> and <code>millisecond</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        /// <param name="millisecond">The milliseconds (<code>0</code> through <code>999</code>).</param>
        public SocialDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>, <code>day</code>,
        /// <code>hour</code>, <code>minute</code>, <code>second</code>, <code>millisecond</code> and <code>kind</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        /// <param name="millisecond">The milliseconds (<code>0</code> through <code>999</code>).</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public SocialDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond, kind);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>, <code>day</code>,
        /// <code>hour</code>, <code>minute</code>, <code>second</code> and <code>millisecond</code> for the specified
        /// <code>calendar</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        /// <param name="millisecond">The milliseconds (<code>0</code> through <code>999</code>).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        public SocialDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond, calendar);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>, <code>day</code>,
        /// <code>hour</code>, <code>minute</code>, <code>second</code> and <code>millisecond</code> for the specified
        /// <code>calendar</code> and <code>kind</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        /// <param name="millisecond">The milliseconds (<code>0</code> through <code>999</code>).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public SocialDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind);
        }

        #endregion

        #region Member methods

        public override string ToString() {
            return DateTime.ToString(DateTimeFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current <code>SocialDateTime</code> to its equivalent string representation
        /// using the specified <code>provider</code>.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <code>SocialDateTime</code> object as specified by
        /// <code>provider</code>.</returns>
        public string ToString(IFormatProvider provider) {
            return DateTime.ToString(provider);
        }

        /// <summary>
        /// Converts the value of the current <code>SocialDateTime</code> to its equivalent string representation using
        /// the specified <code>format</code>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of value of the current <code>SocialDateTime</code> object as specified by
        /// <code>format</code>.</returns>
        public string ToString(string format) {
            return DateTime.ToString(format, DateTimeFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current <code>SocialDateTime</code> to its equivalent string representation using
        /// the specified <code>format</code> and <code>provider</code>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <code>SocialDateTime</code> object as specified by
        /// <code>format</code> and <code>provider</code>.</returns>
        public string ToString(string format, IFormatProvider provider) {
            return DateTime.ToString(format, provider);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified string into an instance of <code>SocialDateTime</code>.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An instance of <code>SocialDateTime</code>.</returns>
        public static SocialDateTime Parse(string str) {
            return String.IsNullOrWhiteSpace(str) ? null : new SocialDateTime(DateTime.Parse(str));
        }

        #endregion

    }

}