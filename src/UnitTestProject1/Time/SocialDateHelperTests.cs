using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Social;
using Skybrud.Social.Time;

namespace UnitTestProject1.Time {

    [TestClass]
    public class SocialDateHelperTests {

        [TestMethod]
        public void GetAge() {

            // Since the age doesn't have a fixed value, we fake the value of "now"
            DateTime fakeNow = new DateTime(2014, 02, 15);

            var samples = new[] {
                new { Date = new DateTime(1970, 01, 01), Age = 44 },
                new { Date = new DateTime(1988, 08, 17), Age = 25 }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Age, SocialUtils.Time.GetAge(sample.Date, fakeNow));
            }

        }

        [TestMethod]
        public void GetWeekNumber() {

            var samples = new[] {
                new { Date = new DateTime(2014, 12, 29), Week = 1 },
                new { Date = new DateTime(2014, 12, 30), Week = 1 },
                new { Date = new DateTime(2014, 12, 31), Week = 1 },
                new { Date = new DateTime(2015,  1,  1), Week = 1 },
                new { Date = new DateTime(2015,  1,  2), Week = 1 },
                new { Date = new DateTime(2015,  1,  3), Week = 1 },
                new { Date = new DateTime(2015,  1,  4), Week = 1 }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Week, SocialUtils.Time.GetIso8601WeekNumber(sample.Date), "\n\n" + sample.Date + " (DateTimeHelpers)");
            }

        }

        [TestMethod]
        public void IsWeekDay() {

            Assert.AreEqual(true, SocialUtils.Time.IsWeekday(new DateTime(2014, 2, 10)));
            Assert.AreEqual(true, SocialUtils.Time.IsWeekday(new DateTime(2014, 2, 11)));
            Assert.AreEqual(true, SocialUtils.Time.IsWeekday(new DateTime(2014, 2, 12)));
            Assert.AreEqual(true, SocialUtils.Time.IsWeekday(new DateTime(2014, 2, 13)));
            Assert.AreEqual(true, SocialUtils.Time.IsWeekday(new DateTime(2014, 2, 14)));
            Assert.AreEqual(false, SocialUtils.Time.IsWeekday(new DateTime(2014, 2, 15)));
            Assert.AreEqual(false, SocialUtils.Time.IsWeekday(new DateTime(2014, 2, 16)));

        }

        [TestMethod]
        public void IsWeekend() {

            Assert.AreEqual(false, SocialUtils.Time.IsWeekend(new DateTime(2014, 2, 10)));
            Assert.AreEqual(false, SocialUtils.Time.IsWeekend(new DateTime(2014, 2, 11)));
            Assert.AreEqual(false, SocialUtils.Time.IsWeekend(new DateTime(2014, 2, 12)));
            Assert.AreEqual(false, SocialUtils.Time.IsWeekend(new DateTime(2014, 2, 13)));
            Assert.AreEqual(false, SocialUtils.Time.IsWeekend(new DateTime(2014, 2, 14)));
            Assert.AreEqual(true, SocialUtils.Time.IsWeekend(new DateTime(2014, 2, 15)));
            Assert.AreEqual(true, SocialUtils.Time.IsWeekend(new DateTime(2014, 2, 16)));

        }

        [TestMethod]
        public void IsLeapYear() {

            // Se more here: http://en.wikipedia.org/wiki/Leap_year#Algorithm

            var samples = new[] {
            
                new { Year = 2000, IsLeapYear = true },
                new { Year = 2001, IsLeapYear = false },
                new { Year = 2002, IsLeapYear = false },
                new { Year = 2003, IsLeapYear = false },
                new { Year = 2004, IsLeapYear = true },
                new { Year = 2005, IsLeapYear = false },
                new { Year = 2006, IsLeapYear = false },
                new { Year = 2007, IsLeapYear = false },
                new { Year = 2008, IsLeapYear = true },
                new { Year = 2009, IsLeapYear = false },
                new { Year = 2010, IsLeapYear = false },
                new { Year = 2011, IsLeapYear = false },
                new { Year = 2012, IsLeapYear = true },
                new { Year = 2013, IsLeapYear = false },
                new { Year = 2014, IsLeapYear = false },
            
                new { Year = 1500, IsLeapYear = false },
                new { Year = 1600, IsLeapYear = true },
                new { Year = 1700, IsLeapYear = false },
                new { Year = 1800, IsLeapYear = false },
                new { Year = 1900, IsLeapYear = false },
                new { Year = 2000, IsLeapYear = true },
                new { Year = 2100, IsLeapYear = false },
                new { Year = 2200, IsLeapYear = false },
                new { Year = 2300, IsLeapYear = false },
                new { Year = 2400, IsLeapYear = true }
            
            };

            foreach (var sample in samples) {

                DateTime dt = new DateTime(sample.Year, 1, 1);

                Assert.AreEqual(sample.IsLeapYear, SocialUtils.Time.IsLeapYear(sample.Year), "\n\n" + sample.Year + " (DateTimeHelpers)");
                Assert.AreEqual(sample.IsLeapYear, SocialUtils.Time.IsLeapYear(dt), "\n\n" + sample.Year + " (DateTimeHelpers)");

            }

        }

        #region Unix time

        [TestMethod]
        public void GetUnixTimeFromDateTime() {

            var samples = new[] {
                // TODO: Add more samples
                new { Timestamp = 1408269600, Text = "2014-08-17T10:00:00Z" },
                new { Timestamp = 1408269600, Text = "2014-08-17T12:00:00+02:00" },
                new { Timestamp = 1419440400, Text = "2014-12-24T17:00:00Z" },
                new { Timestamp = 1419440400, Text = "2014-12-24T18:00:00+01:00" }
            };

            foreach (var sample in samples) {

                DateTime date = DateTime.Parse(sample.Text);

                long local = SocialUtils.Time.GetUnixTimeFromDateTime(date);
                long utc = SocialUtils.Time.GetUnixTimeFromDateTime(date.ToUniversalTime());

                Assert.AreEqual(sample.Timestamp, local);
                Assert.AreEqual(sample.Timestamp, utc);



            }

        }

        [TestMethod]
        public void GetDateTimeFromUnixTime() {

            var samples = new[] {
                // TODO: Add more samples
                new { Timestamp = 1408269600, TextUTC = "2014-08-17T10:00:00Z", TextLocal = "2014-08-17T12:00:00+02:00", TimeZone = "Paris" },
                new { Timestamp = 1419440400, TextUTC = "2014-12-24T17:00:00Z", TextLocal = "2014-12-24T18:00:00+01:00", TimeZone = "Paris" }
            };

            //string temp = "\n\n\n\n\n";
            //foreach (var tz in TimeZoneInfo.GetSystemTimeZones()) {
            //    temp += "--" + tz.Id + "--" + tz.DisplayName + "--\n";
            //}
            //throw new Exception(temp);

            foreach (var sample in samples) {

                DateTime date = SocialUtils.Time.GetDateTimeFromUnixTime(sample.Timestamp);

                // TODO: Find a way to explicitly specify the local time zone (so the Unit test will complete even when not in Danish timezone).
                DateTime dateLocal = date;// TimeZoneInfo.ConvertTime(date, TimeZoneInfo.Utc, GetTimeZone(sample.TimeZone));

                string local = dateLocal.ToLocalTime().ToString(SocialUtils.Time.IsoDateFormat);
                string utc = date.ToUniversalTime().ToString(SocialUtils.Time.IsoDateFormat);

                Assert.AreEqual(sample.TextLocal, local, "local");
                Assert.AreEqual(sample.TextUTC, utc, "utc");

            }

        }

        #endregion

        [TestMethod]
        public void GetFirstDayOfMonth() {

            var samples = new[] {
                // TODO: Add more samples
                new { Date = new DateTime(2014, 1, 15), Expected = new DateTime(2014, 1, 1) },
                new { Date = new DateTime(2014, 2, 15), Expected = new DateTime(2014, 2, 1) },
                new { Date = new DateTime(2014, 3, 15), Expected = new DateTime(2014, 3, 1) },
                new { Date = new DateTime(2014, 4, 15), Expected = new DateTime(2014, 4, 1) },
                new { Date = new DateTime(2014, 5, 15), Expected = new DateTime(2014, 5, 1) },
                new { Date = new DateTime(2014, 6, 15), Expected = new DateTime(2014, 6, 1) },
                new { Date = new DateTime(2014, 7, 15), Expected = new DateTime(2014, 7, 1) },
                new { Date = new DateTime(2014, 8, 15), Expected = new DateTime(2014, 8, 1) },
                new { Date = new DateTime(2014, 9, 15), Expected = new DateTime(2014, 9, 1) },
                new { Date = new DateTime(2014, 10, 15), Expected = new DateTime(2014, 10, 1) },
                new { Date = new DateTime(2014, 11, 15), Expected = new DateTime(2014, 11, 1) },
                new { Date = new DateTime(2014, 12, 15), Expected = new DateTime(2014, 12, 1) }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SocialUtils.Time.GetFirstDayOfMonth(sample.Date), "DateTimeHelpers");
            }

        }

        [TestMethod]
        public void GetLastDayOfMonth() {

            var samples = new[] {
                new { Date = new DateTime(2014, 1, 15), Expected = new DateTime(2014, 1, 31, 23, 59, 59) },
                new { Date = new DateTime(2014, 2, 15), Expected = new DateTime(2014, 2, 28, 23, 59, 59) },
                new { Date = new DateTime(2015, 2, 15), Expected = new DateTime(2015, 2, 28, 23, 59, 59) },
                new { Date = new DateTime(2016, 2, 15), Expected = new DateTime(2016, 2, 29, 23, 59, 59) },
                new { Date = new DateTime(2014, 3, 15), Expected = new DateTime(2014, 3, 31, 23, 59, 59) },
                new { Date = new DateTime(2014, 4, 15), Expected = new DateTime(2014, 4, 30, 23, 59, 59) },
                new { Date = new DateTime(2014, 5, 15), Expected = new DateTime(2014, 5, 31, 23, 59, 59) },
                new { Date = new DateTime(2014, 6, 15), Expected = new DateTime(2014, 6, 30, 23, 59, 59) },
                new { Date = new DateTime(2014, 7, 15), Expected = new DateTime(2014, 7, 31, 23, 59, 59) },
                new { Date = new DateTime(2014, 8, 15), Expected = new DateTime(2014, 8, 31, 23, 59, 59) },
                new { Date = new DateTime(2014, 9, 15), Expected = new DateTime(2014, 9, 30, 23, 59, 59) },
                new { Date = new DateTime(2014, 10, 15), Expected = new DateTime(2014, 10, 31, 23, 59, 59) },
                new { Date = new DateTime(2014, 11, 15), Expected = new DateTime(2014, 11, 30, 23, 59, 59) },
                new { Date = new DateTime(2014, 12, 15), Expected = new DateTime(2014, 12, 31, 23, 59, 59) }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SocialUtils.Time.GetLastDayOfMonth(sample.Date), "DateTimeHelpers");
            }

        }

        [TestMethod]
        public void GetFirstDayOfWeek() {

            var samples = new[] {
                new { Date = new DateTime(2014, 12, 29), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2014, 12, 28) },
                new { Date = new DateTime(2014, 12, 30), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2014, 12, 28) },
                new { Date = new DateTime(2014, 12, 31), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2014, 12, 28) },
                new { Date = new DateTime(2015,  1,  1), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2014, 12, 28) },
                new { Date = new DateTime(2015,  1,  2), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2014, 12, 28) },
                new { Date = new DateTime(2015,  1,  3), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2014, 12, 28) },
                new { Date = new DateTime(2015,  1,  4), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2015,  1,  4) }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Monday, SocialUtils.Time.GetFirstDayOfWeek(sample.Date), "\n\n" + sample.Date + " (DateTimeHelpers - implicit)");

                Assert.AreEqual(sample.Monday, SocialUtils.Time.GetFirstDayOfWeek(sample.Date, DayOfWeek.Monday), "\n\n" + sample.Date + " (DateTimeHelpers - explicit: Monday)");

                Assert.AreEqual(sample.Sunday, SocialUtils.Time.GetFirstDayOfWeek(sample.Date, DayOfWeek.Sunday), "\n\n" + sample.Date + " (DateTimeHelpers - explicit: Sunday)");

            }

        }

        [TestMethod]
        public void GetLastDayOfWeek() {

            var samples = new[] {
                new { Date = new DateTime(2014, 12, 29), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1,  3, 23, 59, 59) },
                new { Date = new DateTime(2014, 12, 30), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1,  3, 23, 59, 59) },
                new { Date = new DateTime(2014, 12, 31), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1,  3, 23, 59, 59) },
                new { Date = new DateTime(2015,  1,  1), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1,  3, 23, 59, 59) },
                new { Date = new DateTime(2015,  1,  2), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1,  3, 23, 59, 59) },
                new { Date = new DateTime(2015,  1,  3), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1,  3, 23, 59, 59) },
                new { Date = new DateTime(2015,  1,  4), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1, 10, 23, 59, 59) }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Monday, SocialUtils.Time.GetLastDayOfWeek(sample.Date), "\n\n" + sample.Date + " (DateTimeHelpers - implicit)");

                Assert.AreEqual(sample.Monday, SocialUtils.Time.GetLastDayOfWeek(sample.Date, DayOfWeek.Monday), "\n\n" + sample.Date + " (DateTimeHelpers - explicit: Monday)");

                Assert.AreEqual(sample.Sunday, SocialUtils.Time.GetLastDayOfWeek(sample.Date, DayOfWeek.Sunday), "\n\n" + sample.Date + " (DateTimeHelpers - explicit: Sunday)");

            }

        }

    }

}