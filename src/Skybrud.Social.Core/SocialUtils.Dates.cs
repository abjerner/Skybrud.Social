using System;
using System.Globalization;
using Skybrud.Social.Time;

namespace Skybrud.Social {

    public static partial class SocialUtils {

        /// <summary>
        /// Class used for calculating the dates of varios international and national days.
        /// </summary>
        public static class Dates {

            #region Easter dates according to the Gregorian calendar

            /// <summary>
            /// Gets the date of <strong>Palm Sunday</strong>, which falls on the Sunday before <strong>Easter</strong>.
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <code>Palm Sunday</code>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Palm_Sunday#Observance_in_the_liturgy</cref>
            /// </see>
            public static DateTime GetPalmSunday(int year) {
                return GetEasterSunday(year).AddDays(-7);
            }

            /// <summary>
            /// Gets the date of <strong>Moundy Thursday</strong>, which falls on the Thursday before <strong>Easter</strong>.
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <code>Moundy Thursday</code>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Maundy_Thursday</cref>
            /// </see>
            public static DateTime GetMoundyThursday(int year) {
                return GetEasterSunday(year).AddDays(-3);
            }

            /// <summary>
            /// Gets the date of <strong>Good Friday</strong>, which falls on the Friday before <strong>Easter</strong>.
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <code>Good Friday</code>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Good_Friday</cref>
            /// </see>
            public static DateTime GetGoodFriday(int year) {
                return GetEasterSunday(year).AddDays(-2);
            }

            /// <summary>
            /// Gets the date of <strong>Holy Saturday</strong>, which falls on the Saturday before <strong>Easter</strong>.
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <code>Holy Saturday</code>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Holy_Saturday</cref>
            /// </see>
            public static DateTime GetHolySaturday(int year) {
                return GetEasterSunday(year).AddDays(-1);
            }

            /// <summary>
            /// Calculates the date of <strong>Easter Sunday</strong> in the specified <code>year</code> according to
            /// Western Christianity and the <see cref="GregorianCalendar"/>.
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <code>Easter Sunday</code>.</returns>
            /// <see>
            ///     <cref>https://da.wikipedia.org/wiki/Påske#Beregning_af_p.C3.A5skedagens_dato</cref>
            /// </see>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Easter#Date</cref>
            /// </see>
            public static DateTime GetEasterSunday(int year) {

                int a = year % 19;
                int b = (int) Math.Floor(year / 100.00);

                int c = year % 100;
                int d = (int) Math.Floor(b / 4.00);

                int e = b % 4;
                int f = (int) Math.Floor((b + 8) / 25.00);
                int g = (int) Math.Floor((b - f + 1) / 3.00);

                int h = (19 * a + b - d - g + 15) % 30;
                int i = (int) Math.Floor(c / 4.00);

                int k = c % 4;
                int l = (32 + 2 * e + 2 * i - h - k) % 7;

                int m = (int) Math.Floor((a + 11 * h + 22 * l) / 451.00);

                int n = (int) Math.Floor((h + l - 7 * m + 114) / 31.00);
                int p = (h + l - 7 * m + 114) % 31 + 1;

                return new DateTime(year, n, p);

            }

            /// <summary>
            /// Gets the date of <strong>Easter Monday</strong>, which falls on the Monday after <strong>Easter</strong>.
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>Easter Monday</strong>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Easter_Monday</cref>
            /// </see>
            public static DateTime GetEasterMonday(int year) {
                return GetEasterSunday(year).AddDays(1);
            }

            /// <summary>
            /// Gets the date of <strong>Ascension Day</strong>, which is celebrated on a Thursday, the fortieth day of
            /// <strong>Easter</strong> (the 6th Thursday after <strong>Moundy Thursday</strong>).
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>Ascension Day</strong>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Feast_of_the_Ascension</cref>
            /// </see>
            public static DateTime GetAscensionDay(int year) {
                return GetMoundyThursday(year).AddDays(7 * 6);
            }

            /// <summary>
            /// Gets the date of <strong>Whit Sunday</strong>, which is celebrated on the 7th Sunday after
            /// <strong>Easter</strong>.
            /// 
            /// Depending on the year, Whit Sunday falls within the period from the
            /// <code>10th of May</code> to the <code>13th of June</code> (both inclusive).
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <code>Whit Sunday</code>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Whitsun</cref>
            /// </see>
            public static DateTime GetWhitSunday(int year) {
                return GetEasterSunday(year).AddDays(7 * 7);
            }

            /// <summary>
            /// Gets the date of <strong>Whit Monday</strong>, which is celebrated the day after
            /// <strong>Whit Sunday</strong>. Whit Sunday is the 7th Sunday after
            /// <strong>Easter</strong>.
            /// 
            /// Depending on the year, Whit Monday falls within the period from the <code>11th of May</code> to the
            /// <code>14th of June</code> (both inclusive).
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <code>Whit Monday</code>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Whit_Monday</cref>
            /// </see>
            public static DateTime GetWhitMonday(int year) {
                return GetWhitSunday(year).AddDays(1);
            }

            #endregion

            #region Dates in relation to Christmas and New Year

            /// <summary>
            /// Gets an instance of <see cref="DateTime"/> representing the date of <strong>Saint Lucy's Day</strong> (13th of December).
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of Saint Lucy's Day.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Saint_Lucy's_Day</cref>
            /// </see>
            public static DateTime SaintLucysDay(int year) {
                return GetDate(year, SocialDateMonth.December, 13);
            }

            /// <summary>
            /// Gets an instance of <see cref="DateTime"/> representing the date of <strong>Christmas Eve</strong> (24th of December).
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of Christmas Eve.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Christmas_Eve</cref>
            /// </see>
            public static DateTime GetChristmasEve(int year) {
                return GetDate(year, SocialDateMonth.December, 24);
            }

            /// <summary>
            /// Gets an instance of <see cref="DateTime"/> representing the date of <strong>Christmas Day</strong> (25th of December).
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>Christmas Day</strong>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Christmas_Day</cref>
            /// </see>
            public static DateTime GetChristmasDay(int year) {
                return GetDate(year, SocialDateMonth.December, 25);
            }

            /// <summary>
            /// Gets an instance of <see cref="DateTime"/> representing the date of <strong>Boxing Day</strong> (26th of December).
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>Boxing Day</strong>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Boxing_Day</cref>
            /// </see>
            public static DateTime GetBoxingDay(int year) {
                return GetDate(year, SocialDateMonth.December, 26);
            }

            /// <summary>
            /// Gets an instance of <see cref="DateTime"/> representing the date of <strong>New Year's Eve</strong> (31st of December).
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>New Year's Eve</strong>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/New_Year's_Eve</cref>
            /// </see>
            public static DateTime GetNewYearsEve(int year) {
                return GetDate(year, SocialDateMonth.December, 31);
            }

            /// <summary>
            /// Gets an instance of <see cref="DateTime"/> representing <strong>New Year's Day</strong> (1st of January).
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>New Year's Day</strong>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/New_Year's_Day</cref>
            /// </see>
            public static DateTime GetNewYearsDay(int year) {
                return GetDate(year, SocialDateMonth.January, 1);
            }

            #endregion

            #region Other dates

            /// <summary>
            /// Gets an instance of <see cref="DateTime"/> representing <strong>Groundhog Day</strong> (2nd of February).
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>Groundhog Day</strong>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Groundhog_Day</cref>
            /// </see>
            public static DateTime GetGroundhogDay(int year) {
                return GetDate(year, SocialDateMonth.February, 2);
            }

            /// <summary>
            /// Gets an instance of <see cref="DateTime"/> representing <strong>Saint Patrick's Day</strong>. Saint
            /// Partick's Day is a cultural and religious celebration held on 17 March, the traditional death date of
            /// Saint Patrick, the foremost patron saint of Ireland.
            /// </summary>
            /// <param name="year">The year.</param>
            /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>Saint Patrick's Day</strong>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Saint_Patrick's_Day</cref>
            /// </see>
            public static DateTime SaintPatricksDay(int year) {
                return GetDate(year, SocialDateMonth.March, 17);
            }
            
            #endregion

            #region Canada

            /// <summary>
            /// Natianal holidays and special dates in <strong>Canada</strong>.
            /// </summary>
            public static class Canada {

                /// <summary>
                /// Gets an instance of <see cref="DateTime"/> representing <strong>Canada Day</strong>. Canada Day is
                /// the national day of Canada, a federal statutory holiday celebrating the anniversary of the
                /// July 1, 1867, enactment of the Constitution Act, 1867 (then called the British North America Act,
                /// 1867), which united three colonies into a single country called Canada within the British Empire.
                /// </summary>
                /// <param name="year">The year.</param>
                /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>Canada Day</strong>.</returns>
                /// <see>
                ///     <cref>https://en.wikipedia.org/wiki/Canada_Day</cref>
                /// </see>
                public static DateTime GetCanadaDay(int year) {
                    return GetDate(year, SocialDateMonth.July, 1);
                }

                /// <summary>
                /// Gets an instance of <see cref="DateTime"/> representing <strong>Labour Day</strong>. Labour Day is a
                /// public holiday celebrated on the first Monday in September.
                /// </summary>
                /// <param name="year">The year.</param>
                /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>Labour Day</strong>.</returns>
                /// <see>
                ///     <cref>https://en.wikipedia.org/wiki/Labour_Day</cref>
                /// </see>
                public static DateTime GetLabourDay(int year) {
                    return Time.GetFirstWeekdayOfMonth(year, SocialDateMonth.September, DayOfWeek.Monday);
                }

                /// <summary>
                /// Gets an instance of <see cref="DateTime"/> representing <strong>Thanksgiving Day</strong>.
                /// Thanksgiving Day occurs on the second Monday in October, which celebrates the harvest and other blessings of the past year.
                /// </summary>
                /// <param name="year">The year.</param>
                /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>Thanksgiving Day</strong>.</returns>
                /// <see>
                ///     <cref>https://en.wikipedia.org/wiki/Thanksgiving_(Canada)</cref>
                /// </see>
                public static DateTime GetThanksgivingDay(int year) {
                    return Time.GetFirstWeekdayOfMonth(year, SocialDateMonth.October, DayOfWeek.Monday).AddDays(7);
                }

            }

            #endregion

            #region Denmark

            /// <summary>
            /// Natianal holidays and special dates in <strong>Denmark</strong>.
            /// </summary>
            public static class Denmark {

                /// <summary>
                /// Calculates the date of <strong>General Prayer Day</strong> (or <code>Store Bededag</code>in Danish)
                /// - a national holiday in Denmark. It falls on the 4th Friday after <strong>Easter</strong>.
                /// </summary>
                /// <param name="year">The year.</param>
                /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of Store Bededag.</returns>
                /// <see>
                ///     <cref>https://da.wikipedia.org/wiki/Store_bededag</cref>
                /// </see>
                /// <see>
                ///     <cref>https://en.wikipedia.org/wiki/Store_Bededag</cref>
                /// </see>
                public static DateTime GetGeneralPrayerDay(int year) {
                    return GetGoodFriday(year).AddDays(7 * 4);
                }

                /// <summary>
                /// Gets an instance of <see cref="DateTime"/> representing <strong>Constitution Day</strong>
                /// (<strong>Grundlovsdag</strong> in Danish). Constitution Day is observed on 5 June, and commemorates
                /// the anniversary of the signing of the Danish Constitution of 1849, which established Denmark as a
                /// constitutional monarchy, and honors the constitution of 1953, which was adopted on the same date.
                /// </summary>
                /// <param name="year">The year.</param>
                /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>Independence Day</strong>.</returns>
                /// <see>
                ///     <cref>https://da.wikipedia.org/wiki/Grundlovsdag</cref>
                /// </see>
                /// <see>
                ///     <cref>https://en.wikipedia.org/wiki/Constitution_Day_(Denmark)</cref>
                /// </see>
                public static DateTime GetConstitutionDay(int year) {
                    return GetDate(year, SocialDateMonth.June, 5);
                }

            }

            #endregion

            #region United States

            /// <summary>
            /// Natianal holidays and special dates in the <strong>United States</strong>.
            /// </summary>
            public static class UnitedStates {

                /// <summary>
                /// Gets an instance of <see cref="DateTime"/> representing <strong>Independence Day</strong> (4th of July).
                /// </summary>
                /// <param name="year">The year.</param>
                /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>Independence Day</strong>.</returns>
                /// <see>
                ///     <cref>https://en.wikipedia.org/wiki/Independence_Day_(United_States)</cref>
                /// </see>
                public static DateTime GetIndependenceDay(int year) {
                    return GetDate(year, SocialDateMonth.July, 4);
                }

                /// <summary>
                /// Gets an instance of <see cref="DateTime"/> representing <strong>Patriot Day</strong> also known as
                /// <code>National Day of Service and Remembrance</code>. The day occurs on September 11 of each year
                /// in memory of the 2,977 people killed in the 2001 September 11 attacks.
                /// </summary>
                /// <param name="year">The year.</param>
                /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of
                /// <strong>Patriot Day</strong>.</returns>
                /// <see>
                ///     <cref>https://en.wikipedia.org/wiki/Patriot_Day</cref>
                /// </see>
                public static DateTime GetPatriotDay(int year) {
                    return GetDate(year, SocialDateMonth.September, 11);
                }

                /// <summary>
                /// Gets an instance of <see cref="DateTime"/> representing <strong>Labor Day</strong>. Labor Day is a
                /// public holiday celebrated on the first Monday in September.
                /// </summary>
                /// <param name="year">The year.</param>
                /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of
                /// <strong>Patriot Day</strong>.</returns>
                /// <see>
                ///     <cref>https://en.wikipedia.org/wiki/Labor_Day</cref>
                /// </see>
                public static DateTime GetLaborDay(int year) {
                    return Time.GetFirstWeekdayOfMonth(year, SocialDateMonth.September, DayOfWeek.Monday);
                }

                /// <summary>
                /// Gets an instance of <see cref="DateTime"/> representing <strong>Memorial Day</strong>. Memorial Day
                /// is a federal holiday in the United States for remembering the people who died while serving in the
                /// country's armed forces. The holiday is observed every year on the last Monday of May.
                /// </summary>
                /// <param name="year">The year.</param>
                /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of
                /// <strong>Memorial Day</strong>.</returns>
                /// <see>
                ///     <cref>https://en.wikipedia.org/wiki/Labor_Day</cref>
                /// </see>
                public static DateTime GetMemorialDay(int year) {
                    return Time.GetFirstWeekdayOfMonth(year, SocialDateMonth.May, DayOfWeek.Monday);
                }

                /// <summary>
                /// Gets an instance of <see cref="DateTime"/> representing <strong>Veterans Day</strong>. Veterans Day
                /// is an official United States public holiday, observed annually on November 11, that honors military
                /// veterans, that is, persons who served in the United States Armed Forces.
                /// </summary>
                /// <param name="year">The year.</param>
                /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of
                /// <strong>Veterans Day</strong>.</returns>
                /// <see>
                ///     <cref>https://en.wikipedia.org/wiki/Veterans_Day</cref>
                /// </see>
                public static DateTime GetVeteransDay(int year) {
                    return GetDate(year, SocialDateMonth.November, 11);
                }

                /// <summary>
                /// Gets an instance of <see cref="DateTime"/> representing <strong>Thanksgiving Day</strong>.
                /// Thanksgiving, or Thanksgiving Day, is an important public holiday, celebrated on the fourth
                /// Thursday in November in the United States. It originated as a harvest festival. Thanksgiving has
                /// been celebrated nationally on and off since 1789, after a proclamation by George Washington.
                /// </summary>
                /// <param name="year">The year.</param>
                /// <returns>Returns an instance of <see cref="DateTime"/> representing the date of <strong>Thanksgiving Day</strong>.</returns>
                /// <see>
                ///     <cref>https://en.wikipedia.org/wiki/Thanksgiving_(United_States)</cref>
                /// </see>
                public static DateTime GetThanksgivingDay(int year) {
                    return Time.GetFirstWeekdayOfMonth(year, SocialDateMonth.November, DayOfWeek.Thursday).AddDays(7 * 3);
                }

            }

            #endregion

            #region Static methods

            private static DateTime GetDate(int year, SocialDateMonth month, int day) {
                return new DateTime(year, (int) month, day);
            }

            #endregion

        }

    }

}