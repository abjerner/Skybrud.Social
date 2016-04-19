using System;
using System.Globalization;
using Skybrud.Social.Time;

namespace Skybrud.Social {

    public static partial class SocialUtils {

        /// <summary>
        /// Static class with helper methods related to date and time.
        /// </summary>
        public static class Time {

            /// <summary>
            /// Gets the amount of whole years that has elapsed since the specified <code>date</code>.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>Returns the amount of whole years elapsed since the specified <code>date</code>.</returns>
            public static int GetAge(DateTime date) {
                return GetAge(date, DateTime.Today);
            }

            /// <summary>
            /// Gets the amount of whole years that has elapsed between the specified <code>date1</code> and
            /// <code>date2</code>.
            /// </summary>
            /// <param name="date1">The first date.</param>
            /// <param name="date2">The second date.</param>
            /// <returns>Returns the amount of whole years elapsed since the specified <code>date1</code> and
            /// <code>date2</code>.</returns>
            public static int GetAge(DateTime date1, DateTime date2) {
                int age = date2.Year - date1.Year;
                if (date2.Month < date1.Month || (date2.Month == date1.Month && date2.Day < date1.Day)) age--;
                return age;
            }

            /// <summary>
            /// Gets the week number of <code>date</code> according to the ISO8601 specification.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>Returns the week number.</returns>
            public static int GetIso8601WeekNumber(DateTime date) {
                int day = (int) CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
                return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                    date.AddDays(4 - (day == 0 ? 7 : day)),
                    CalendarWeekRule.FirstFourDayWeek,
                    DayOfWeek.Monday
                );
            }

            /// <summary>
            /// Gets whether the specified <code>date</code> is a weekday.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>Returns <code>true</code> if the specified day is weekday; otherwise <code>false</code>.</returns>
            public static bool IsWeekday(DateTime date) {
                return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
            }

            /// <summary>
            /// Gets whether the specified <code>date</code> is within a weekend, that is either <code>Saturday</code> or
            /// <code>Sunday</code>.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>
            /// Returns <code>true</code> if the specified day is within a weekend; otherwise <code>false</code>.</returns>
            public static bool IsWeekend(DateTime date) {
                return !IsWeekday(date);
            }

            /// <summary>
            /// Gets whether the year of the specified <code>date</code> is a leap year.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>
            /// Returns <code>true</code> if the year of the specified <code>date</code> is a leap year; otherwise
            /// <code>false</code>.
            /// </returns>
            public static bool IsLeapYear(DateTime date) {
                return IsLeapYear(date.Year);
            }

            /// <summary>
            /// Gets whether the specified <code>year</code> is a leap year.
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>
            /// Returns <code>true</code> if the specified <code>year</code> is a leap year; otherwise <code>false</code>.
            /// </returns>
            public static bool IsLeapYear(int year) {
                return (DateTime.DaysInMonth(year, 2).Equals(29));
            }

            /// <summary>
            /// Gets the week number of <code>date</code> according to the ISO8601 specification.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>Returns the week number.</returns>
            public static int GetIso8601WeekNumber(SocialDateTime date) {
                return GetIso8601WeekNumber(date.DateTime);
            }

            /// <summary>
            /// Gets the first day of the month of the specified <code>date</code>.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the month.</returns>
            public static DateTime GetFirstDayOfMonth(DateTime date) {
                return new DateTime(date.Year, date.Month, 1);
            }

            /// <summary>
            /// Gets the last day of the month of the specified <code>date</code>.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the month.</returns>
            public static DateTime GetLastDayOfMonth(DateTime date) {
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                return new DateTime(date.Year, date.Month, daysInMonth, 23, 59, 59);
            }

            /// <summary>
            /// Gets the first day of the week of the specified <code>date</code>. <code>Monday</code> is considered
            /// the first day of the week.
            /// </summary>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the week.</returns>
            public static DateTime GetFirstDayOfWeek(DateTime date) {
                return GetFirstDayOfWeek(date, DayOfWeek.Monday);
            }

            /// <summary>
            /// Gets the first day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <param name="startOfWeek">The first day of the week (eg. <code>Monday</code> or <code>Sunday</code>).</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the week.</returns>
            public static DateTime GetFirstDayOfWeek(DateTime date, DayOfWeek startOfWeek) {
                int diff = date.DayOfWeek - startOfWeek;
                if (diff < 0) diff += 7;
                return date.AddDays(-1 * diff).Date;
            }

            /// <summary>
            /// Gets the last day of the week of the specified <code>date</code>. Monday is considered the first day of the
            /// week.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the week.</returns>
            public static DateTime GetLastDayOfWeek(DateTime date) {
                return GetLastDayOfWeek(date, DayOfWeek.Monday);
            }

            /// <summary>
            /// Gets the last day of the week of the specified <code>date</code> and based on <code>startOfWeek</code>.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <param name="startOfWeek">The first day of the week (eg. <code>Monday</code> or <code>Sunday</code>).</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the last day of the week.</returns>
            public static DateTime GetLastDayOfWeek(DateTime date, DayOfWeek startOfWeek) {
                return GetFirstDayOfWeek(date, startOfWeek).AddDays(7).AddSeconds(-1);
            }

            #region Days

            /// <summary>
            /// Gets the English name of the day from the specified <code>date</code>.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>Returns the English name of the day.</returns>
            public static string GetDayName(DateTime date) {
                return date.ToString("dddd", CultureInfo.InvariantCulture);
            }

            /// <summary>
            /// Gets the name of the day from the specified <code>date</code> and according to <see cref="CultureInfo.CurrentCulture"/>.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>Returns the local name of the day.</returns>
            public static string GetLocalDayName(DateTime date) {
                return date.ToString("dddd", CultureInfo.CurrentCulture);
            }

            /// <summary>
            /// Gets the name of the day from the specified <code>date</code> and according to <code>culture</code>.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <param name="culture">The culture to be used.</param>
            /// <returns>Returns the local name of the day.</returns>
            public static string GetLocalDayName(DateTime date, CultureInfo culture) {
                return date.ToString("dddd", culture);
            }

            #endregion

            #region Months

            /// <summary>
            /// Gets the English name of the month from the specified <code>date</code>
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>Returns the English name of the month.</returns>
            public static string GetMonthName(DateTime date) {
                return date.ToString("MMMM", CultureInfo.InvariantCulture);
            }

            /// <summary>
            /// Gets the name of the month from the specified <code>date</code> and according to <see cref="CultureInfo.CurrentCulture"/>.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns>Returns the local name of the month.</returns>
            public static string GetLocalMonthName(DateTime date) {
                return date.ToString("MMMM", CultureInfo.CurrentCulture);
            }

            /// <summary>
            ///     Gets the name of the month from the specified <code>date</code> and according to <code>culture</code>.
            /// </summary>
            /// <param name="date">The date.</param>
            /// <param name="culture">The culture to be used.</param>
            /// <returns>Returns the local name of the month.</returns>
            public static string GetLocalMonthName(DateTime date, CultureInfo culture) {
                return date.ToString("MMMM", culture);
            }

            #endregion

            #region Timestamps

            /// <summary>
            /// ISO 8601 date format.
            /// </summary>
            public const string IsoDateFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";

            /// <summary>
            /// Returns the current Unix timestamp which is defined as the amount of seconds since the start of the Unix
            /// epoch - that is <code>1st of January, 1970 - 00:00:00 GMT</code>.
            /// </summary>
            /// <returns>Returns a 64-bit integer representing the current UNIX timestamp.</returns>
            public static long GetCurrentUnixTimestamp() {
                return (long) Math.Floor(GetCurrentUnixTimestampAsDouble());
            }

            /// <summary>
            /// Returns the current unix timestamp which is defined as the amount of seconds since the start of the Unix
            /// epoch - that is <code>1st of January, 1970 - 00:00:00 GMT</code>.
            /// </summary>
            /// <returns>Returns a <see cref="double"/> representing the current Unix timestamp.</returns>
            public static double GetCurrentUnixTimestampAsDouble() {
                return (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            }

            /// <summary>
            /// Gets an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.
            /// </summary>
            /// <param name="timestamp">The Unix timestamp.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.</returns>
            public static DateTime GetDateTimeFromUnixTime(int timestamp) {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
            }

            /// <summary>
            /// Gets an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.
            /// </summary>
            /// <param name="timestamp">The Unix timestamp.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.</returns>
            public static DateTime GetDateTimeFromUnixTime(double timestamp) {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
            }

            /// <summary>
            /// Gets an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.
            /// </summary>
            /// <param name="timestamp">The Unix timestamp.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.</returns>
            public static DateTime GetDateTimeFromUnixTime(long timestamp) {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
            }

            /// <summary>
            /// Gets an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.
            /// </summary>
            /// <param name="timestamp">The Unix timestamp.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.</returns>
            public static DateTime GetDateTimeFromUnixTime(string timestamp) {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Int64.Parse(timestamp));
            }

            /// <summary>
            /// Gets a Unix timestamp from the specified <code>dateTime</code>.
            /// </summary>
            /// <param name="dateTime">The instance of <see cref="DateTime"/> to be converted.</param>
            /// <returns>Returns a 64-bit integer representing the the specified <code>dateTime</code>.</returns>
            public static long GetUnixTimeFromDateTime(DateTime dateTime) {
                return (long) (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            }

            #endregion

        }

    }

}