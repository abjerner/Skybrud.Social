using System;
using System.Globalization;

namespace Skybrud.Social.Time {
    
    /// <summary>
    /// Static class with helper methods related to date and time.
    /// </summary>
    public static class SocialDateHelpers {

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

    }

}