using System;
using System.Globalization;

namespace Skybrud.Social.Time {
    
    /// <summary>
    /// Class wrapping an instance of <see cref="DateTime"/> (as an alternative to using <see cref="Nullable{DateTime}"/>).
    /// </summary>
    public class SocialDateTime {

        #region Properties

        /// <summary>
        /// Gets the wrapped <see cref="DateTime"/>.
        /// </summary>
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// Returns the day-of-month part of this <see cref="SocialDateTime"/>. The returned value is an integer between
        /// <code>1</code> and <code>31</code>.
        /// </summary>
        public int Day {
            get { return DateTime.Day; }
        }

        /// <summary>
        /// Returns the day-of-week part of this <see cref="SocialDateTime"/>. The returned value is an integer between
        /// <code>0</code> and <code>6</code>, where <code>0</code> indicates <strong>Sunday</strong>, <code>1</code>
        /// indicates <strong>Monday</strong>, <code>2</code> indicates <strong>Tuesday</strong>, <code>3</code>
        /// indicates <strong>Wednesday</strong>, <code>4</code> indicates <strong>Thursday</strong>, <code>5</code>
        /// indicates <strong>Friday</strong>, and <code>6</code> indicates <strong>Saturday</strong>.
        /// </summary>
        public DayOfWeek DayOfWeek {
            get { return DateTime.DayOfWeek; }
        }

        /// <summary>
        /// Gets the day-of-year part of this <see cref="SocialDateTime"/>. The returned value is an integer between
        /// <code>1</code> and <code>366</code>.
        /// </summary>
        public int DayOfYear {
            get { return DateTime.DayOfYear; }
        }

        /// <summary>
        /// Gets the hour part of this <see cref="SocialDateTime"/>. The returned value is an integer between
        /// <code>0</code> and <code>23</code>.
        /// </summary>
        public int Hour {
            get { return DateTime.Hour; }
        }

        /// <summary>
        /// Gets the kind of the underlying <see cref="DateTime"/>.
        /// </summary>
        public DateTimeKind Kind {
            get { return DateTime.Kind; }
        }

        /// <summary>
        /// Gets the millisecond part of this <see cref="SocialDateTime"/>. The returned value is an integer between
        /// <code>0</code> and <code>999</code>.
        /// </summary>
        public int Millisecond {
            get { return DateTime.Millisecond; }
        }

        /// <summary>
        /// Gets the minute part of this <see cref="SocialDateTime"/>. The returned value is an integer between
        /// <code>0</code> and <code>59</code>.
        /// </summary>
        public int Minute {
            get { return DateTime.Minute; }
        }

        /// <summary>
        /// Gets the month part of this <see cref="SocialDateTime"/>. The returned value is an integer between
        /// <code>1</code> and <code>12</code>.
        /// </summary>
        public int Month {
            get { return DateTime.Month; }
        }

        /// <summary>
        /// Gets the second part of this <see cref="SocialDateTime"/>. The returned value is an integer between
        /// <code>0</code> and <code>59</code>.
        /// </summary>
        public int Second {
            get { return DateTime.Second; }
        }

        /// <summary>
        /// Gets the tick count for this <see cref="SocialDateTime"/>. The returned value is the number of
        /// 100-nanosecond intervals that have elapsed since <code>1/1/0001 12:00am</code>.
        /// </summary>
        public long Ticks {
            get { return DateTime.Ticks; }
        }

        /// <summary>
        /// Gets the time-of-day part of this <see cref="SocialDateTime"/>. The returned value is a
        /// <see cref="TimeSpan"/> that indicates the time elapsed since midnight.
        /// </summary>
        public TimeSpan TimeOfDay {
            get { return DateTime.TimeOfDay; }
        }
        
        /// <summary>
        /// Returns the year part of this <see cref="SocialDateTime"/>. The returned value is an integer between
        /// <code>1</code> and <code>9999</code>.
        /// </summary>
        public int Year {
            get { return DateTime.Year; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on <see cref="System.DateTime.MinValue"/>.
        /// </summary>
        public SocialDateTime() {
            DateTime = DateTime.MinValue;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <see cref="dt"/>.
        /// </summary>
        /// <param name="dt">The an instance <see cref="DateTime"/> the instance should be based on.</param>
        public SocialDateTime(DateTime dt) {
            DateTime = dt;
        }

        /// <summary>
        /// Initializes a new instance based on the specified amount of <see cref="ticks"/>.
        /// </summary>
        /// <param name="ticks">The amount ticks the instance should be based on.</param>
        public SocialDateTime(long ticks) {
            DateTime = new DateTime(ticks);
        }

        /// <summary>
        /// Initializes a new instance based on the specified amount of <see cref="ticks"/> and <see cref="kind"/>.
        /// </summary>
        /// <param name="ticks">The amount ticks the instance should be based on.</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public SocialDateTime(long ticks, DateTimeKind kind) {
            DateTime = new DateTime(ticks, kind);  
        }    

        /// <summary>
        /// Initializes a new instance based on the specified <see cref="year"/>, <see cref="month"/> and
        /// <see cref="day"/>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        public SocialDateTime(int year, int month, int day) {
            DateTime = new DateTime(year, month, day);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <see cref="year"/>, <see cref="month"/> and
        /// <see cref="day"/> for the specified <see cref="calendar"/>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        public SocialDateTime(int year, int month, int day, Calendar calendar) {
            DateTime = new DateTime(year, month, day, calendar);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <see cref="year"/>, <see cref="month"/>,
        /// <see cref="day"/>, <see cref="hour"/>, <see cref="minute"/> and <see cref="second"/>.
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
        /// Initializes a new instance based on the specified <see cref="year"/>, <see cref="month"/>,
        /// <see cref="day"/>, <see cref="hour"/>, <see cref="minute"/>, <see cref="second"/> and <see cref="kind"/>.
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
        /// Initializes a new instance based on the specified <see cref="year"/>, <see cref="month"/>,
        /// <see cref="day"/>, <see cref="hour"/>, <see cref="minute"/> and <see cref="second"/> for the specified
        /// <see cref="calendar"/>.
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
        /// Initializes a new instance based on the specified <see cref="year"/>, <see cref="month"/>,
        /// <see cref="day"/>, <see cref="hour"/>, <see cref="minute"/>, <see cref="second"/> and
        /// <see cref="millisecond"/>.
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
        /// Initializes a new instance based on the specified <see cref="year"/>, <see cref="month"/>, <see cref="day"/>,
        /// <see cref="hour"/>, <see cref="minute"/>, <see cref="second"/>, <see cref="millisecond"/> and <see cref="kind"/>.
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
        /// Initializes a new instance based on the specified <see cref="year" />, <see cref="month" />,
        /// <see cref="day" />, <see cref="hour" />, <see cref="minute" />, <see cref="second" /> and
        /// <see cref="millisecond" /> for the specified <see cref="calendar" />.
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
        /// Initializes a new instance based on the specified <see cref="year" />, <see cref="month" />,
        /// <see cref="day" />, <see cref="hour" />, <see cref="minute" />, <see cref="second" /> and
        /// <see cref="millisecond" /> for the specified <see cref="calendar" /> and <see cref="kind" />.
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
        /// Converts the value of the current <see cref="SocialDateTime"/> to its equivalent string representation
        /// using the specified <see cref="provider"/>.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="SocialDateTime"/> object as specified by
        /// <see cref="provider"/>.</returns>
        public string ToString(IFormatProvider provider) {
            return DateTime.ToString(provider);
        }

        /// <summary>
        /// Converts the value of the current <see cref="SocialDateTime"/> to its equivalent string representation using
        /// the specified <see cref="format"/>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of value of the current <see cref="SocialDateTime"/> object as specified by
        /// <see cref="format"/>.</returns>
        public string ToString(string format) {
            return DateTime.ToString(format, DateTimeFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current <see cref="SocialDateTime"/> to its equivalent string representation using
        /// the specified <see cref="format"/> and <see cref="provider"/>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="SocialDateTime"/> object as specified by
        /// <see cref="format"/> and <see cref="provider"/>.</returns>
        public string ToString(string format, IFormatProvider provider) {
            return DateTime.ToString(format, provider);
        }

        /// <summary>
        /// Gets the UNIX timestamp for this <see cref="SocialDateTime"/>.
        /// </summary>
        /// <returns>Returns the UNIX timestamp in seconds.</returns>
        public long GetUnixTimestamp() {
            return SocialUtils.GetUnixTimeFromDateTime(DateTime);
        }

        /// <summary>
        /// Returns a new <see cref="SocialDateTime"/> that adds the value of the specified
        /// <see cref="System.TimeSpan"/> to the value of this instance.
        /// </summary>
        /// <param name="value">A positive or negative time interval.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time
        /// interval represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="SocialDateTime"/> is less than
        /// <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public SocialDateTime Add(TimeSpan value) {
            return new SocialDateTime(DateTime.Add(value));
        }

        /// <summary>
        /// Returns a new <see cref="SocialDateTime"/> that adds the specified number of days to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional days. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of days represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="SocialDateTime"/> is less than
        /// <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public SocialDateTime AddDays(double value) {
            return new SocialDateTime(DateTime.AddDays(value));
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime"/> that adds the specified number of hours to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional hours. The value parameter can be negative or
        /// positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of hours represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="SocialDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public SocialDateTime AddHours(double value) {
            return new SocialDateTime(DateTime.AddHours(value));
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime"/> that adds the specified number of milliseconds to the value of
        /// this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional milliseconds. The value parameter can be negative or
        /// positive. Note that this value is rounded to the nearest integer.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of milliseconds represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="SocialDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public SocialDateTime AddMilliseconds(double value) {
            return new SocialDateTime(DateTime.AddMilliseconds(value));
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime"/> that adds the specified number of minutes to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional minutes. The value parameter can be negative or
        /// positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of minutes represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="SocialDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public SocialDateTime AddMinutes(double value) {
            return new SocialDateTime(DateTime.AddMinutes(value));
        }

        /// <summary>
        /// Returns a new System.DateTime that adds the specified number of months to the value of this instance.
        /// </summary>
        /// <param name="months">A number of months. The months parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and months.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="SocialDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>. Or
        /// <see cref="months"/> is less than <code>-120000</code> or greater than <code>120000</code>.</exception>
        public SocialDateTime AddMonths(int months) {
            return new SocialDateTime(DateTime.AddMonths(months));
        }

        /// <summary>
        /// Returns a new <see cref="SocialDateTime"/> that adds the specified number of seconds to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional seconds. The value parameter can be negative or
        /// positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of seconds represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="SocialDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public SocialDateTime AddSeconds(double value) {
            return new SocialDateTime(DateTime.AddSeconds(value));
        }

        /// <summary>
        /// Returns a new <see cref="SocialDateTime"/> that adds the specified number of ticks to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of 100-nanosecond ticks. The value parameter can be positive or negative.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time
        /// represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="SocialDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public SocialDateTime AddTicks(long value) {
            return new SocialDateTime(DateTime.AddTicks(value));
        }

        /// <summary>
        /// Returns a new <see cref="SocialDateTime"/> that adds the specified number of years to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of years. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of years represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="SocialDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public SocialDateTime AddYears(int value) {
            return new SocialDateTime(DateTime.AddYears(value));
        }

        /// <summary>
        /// Subtracts the specified duration from this instance.
        /// </summary>
        /// <param name="value">The time interval to subtract.</param>
        /// <returns>An object that is equal to the date and time represented by this instance minus the time interval
        /// represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="SocialDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public SocialDateTime Subtract(TimeSpan value) {
            return new SocialDateTime(DateTime.Subtract(value));
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified string into an instance of <see cref="SocialDateTime"/>.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An instance of <see cref="SocialDateTime"/>.</returns>
        public static SocialDateTime Parse(string str) {
            return String.IsNullOrWhiteSpace(str) ? null : new SocialDateTime(DateTime.Parse(str));
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="SocialDateTime"/>.</returns>
        public static SocialDateTime FromUnixTimestamp(long timestamp) {
            return new SocialDateTime(SocialUtils.GetDateTimeFromUnixTime(timestamp));
        }

        #endregion

    }

}