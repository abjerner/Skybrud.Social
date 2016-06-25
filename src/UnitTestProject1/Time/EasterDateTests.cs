using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Social;

namespace UnitTestProject1.Time {
    
    [TestClass]
    public class EasterDateTests {
        
        [TestMethod]
        public void GetPalmSunday() {
            Assert.AreEqual("2000-04-16", SocialUtils.Dates.GetPalmSunday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-08", SocialUtils.Dates.GetPalmSunday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-24", SocialUtils.Dates.GetPalmSunday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-13", SocialUtils.Dates.GetPalmSunday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-04", SocialUtils.Dates.GetPalmSunday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-20", SocialUtils.Dates.GetPalmSunday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-09", SocialUtils.Dates.GetPalmSunday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-01", SocialUtils.Dates.GetPalmSunday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-16", SocialUtils.Dates.GetPalmSunday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-05", SocialUtils.Dates.GetPalmSunday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-03-28", SocialUtils.Dates.GetPalmSunday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-17", SocialUtils.Dates.GetPalmSunday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-01", SocialUtils.Dates.GetPalmSunday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-24", SocialUtils.Dates.GetPalmSunday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-13", SocialUtils.Dates.GetPalmSunday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-03-29", SocialUtils.Dates.GetPalmSunday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-20", SocialUtils.Dates.GetPalmSunday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-09", SocialUtils.Dates.GetPalmSunday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-03-25", SocialUtils.Dates.GetPalmSunday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-14", SocialUtils.Dates.GetPalmSunday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-05", SocialUtils.Dates.GetPalmSunday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-03-28", SocialUtils.Dates.GetPalmSunday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-10", SocialUtils.Dates.GetPalmSunday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-02", SocialUtils.Dates.GetPalmSunday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-24", SocialUtils.Dates.GetPalmSunday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-13", SocialUtils.Dates.GetPalmSunday(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetMoundyThursday() {
            Assert.AreEqual("2000-04-20", SocialUtils.Dates.GetMoundyThursday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-12", SocialUtils.Dates.GetMoundyThursday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-28", SocialUtils.Dates.GetMoundyThursday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-17", SocialUtils.Dates.GetMoundyThursday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-08", SocialUtils.Dates.GetMoundyThursday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-24", SocialUtils.Dates.GetMoundyThursday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-13", SocialUtils.Dates.GetMoundyThursday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-05", SocialUtils.Dates.GetMoundyThursday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-20", SocialUtils.Dates.GetMoundyThursday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-09", SocialUtils.Dates.GetMoundyThursday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-01", SocialUtils.Dates.GetMoundyThursday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-21", SocialUtils.Dates.GetMoundyThursday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-05", SocialUtils.Dates.GetMoundyThursday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-28", SocialUtils.Dates.GetMoundyThursday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-17", SocialUtils.Dates.GetMoundyThursday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-02", SocialUtils.Dates.GetMoundyThursday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-24", SocialUtils.Dates.GetMoundyThursday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-13", SocialUtils.Dates.GetMoundyThursday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-03-29", SocialUtils.Dates.GetMoundyThursday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-18", SocialUtils.Dates.GetMoundyThursday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-09", SocialUtils.Dates.GetMoundyThursday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-01", SocialUtils.Dates.GetMoundyThursday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-14", SocialUtils.Dates.GetMoundyThursday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-06", SocialUtils.Dates.GetMoundyThursday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-28", SocialUtils.Dates.GetMoundyThursday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-17", SocialUtils.Dates.GetMoundyThursday(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetGoodFriday() {
            Assert.AreEqual("2000-04-21", SocialUtils.Dates.GetGoodFriday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-13", SocialUtils.Dates.GetGoodFriday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-29", SocialUtils.Dates.GetGoodFriday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-18", SocialUtils.Dates.GetGoodFriday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-09", SocialUtils.Dates.GetGoodFriday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-25", SocialUtils.Dates.GetGoodFriday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-14", SocialUtils.Dates.GetGoodFriday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-06", SocialUtils.Dates.GetGoodFriday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-21", SocialUtils.Dates.GetGoodFriday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-10", SocialUtils.Dates.GetGoodFriday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-02", SocialUtils.Dates.GetGoodFriday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-22", SocialUtils.Dates.GetGoodFriday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-06", SocialUtils.Dates.GetGoodFriday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-29", SocialUtils.Dates.GetGoodFriday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-18", SocialUtils.Dates.GetGoodFriday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-03", SocialUtils.Dates.GetGoodFriday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-25", SocialUtils.Dates.GetGoodFriday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-14", SocialUtils.Dates.GetGoodFriday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-03-30", SocialUtils.Dates.GetGoodFriday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-19", SocialUtils.Dates.GetGoodFriday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-10", SocialUtils.Dates.GetGoodFriday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-02", SocialUtils.Dates.GetGoodFriday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-15", SocialUtils.Dates.GetGoodFriday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-07", SocialUtils.Dates.GetGoodFriday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-29", SocialUtils.Dates.GetGoodFriday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-18", SocialUtils.Dates.GetGoodFriday(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetHolySaturday() {
            Assert.AreEqual("2000-04-22", SocialUtils.Dates.GetHolySaturday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-14", SocialUtils.Dates.GetHolySaturday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-30", SocialUtils.Dates.GetHolySaturday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-19", SocialUtils.Dates.GetHolySaturday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-10", SocialUtils.Dates.GetHolySaturday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-26", SocialUtils.Dates.GetHolySaturday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-15", SocialUtils.Dates.GetHolySaturday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-07", SocialUtils.Dates.GetHolySaturday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-22", SocialUtils.Dates.GetHolySaturday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-11", SocialUtils.Dates.GetHolySaturday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-03", SocialUtils.Dates.GetHolySaturday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-23", SocialUtils.Dates.GetHolySaturday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-07", SocialUtils.Dates.GetHolySaturday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-30", SocialUtils.Dates.GetHolySaturday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-19", SocialUtils.Dates.GetHolySaturday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-04", SocialUtils.Dates.GetHolySaturday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-26", SocialUtils.Dates.GetHolySaturday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-15", SocialUtils.Dates.GetHolySaturday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-03-31", SocialUtils.Dates.GetHolySaturday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-20", SocialUtils.Dates.GetHolySaturday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-11", SocialUtils.Dates.GetHolySaturday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-03", SocialUtils.Dates.GetHolySaturday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-16", SocialUtils.Dates.GetHolySaturday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-08", SocialUtils.Dates.GetHolySaturday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-30", SocialUtils.Dates.GetHolySaturday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-19", SocialUtils.Dates.GetHolySaturday(2025).ToString("yyyy-MM-dd"));
        }

        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Easter#Table_of_the_dates_of_Easter</cref>
        /// </see>
        [TestMethod]
        public void GetEasterSunday() {
            Assert.AreEqual("2000-04-23", SocialUtils.Dates.GetEasterSunday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-15", SocialUtils.Dates.GetEasterSunday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-31", SocialUtils.Dates.GetEasterSunday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-20", SocialUtils.Dates.GetEasterSunday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-11", SocialUtils.Dates.GetEasterSunday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-27", SocialUtils.Dates.GetEasterSunday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-16", SocialUtils.Dates.GetEasterSunday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-08", SocialUtils.Dates.GetEasterSunday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-23", SocialUtils.Dates.GetEasterSunday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-12", SocialUtils.Dates.GetEasterSunday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-04", SocialUtils.Dates.GetEasterSunday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-24", SocialUtils.Dates.GetEasterSunday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-08", SocialUtils.Dates.GetEasterSunday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-31", SocialUtils.Dates.GetEasterSunday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-20", SocialUtils.Dates.GetEasterSunday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-05", SocialUtils.Dates.GetEasterSunday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-27", SocialUtils.Dates.GetEasterSunday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-16", SocialUtils.Dates.GetEasterSunday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-04-01", SocialUtils.Dates.GetEasterSunday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-21", SocialUtils.Dates.GetEasterSunday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-12", SocialUtils.Dates.GetEasterSunday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-04", SocialUtils.Dates.GetEasterSunday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-17", SocialUtils.Dates.GetEasterSunday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-09", SocialUtils.Dates.GetEasterSunday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-31", SocialUtils.Dates.GetEasterSunday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-20", SocialUtils.Dates.GetEasterSunday(2025).ToString("yyyy-MM-dd"));
        }
        
        [TestMethod]
        public void GetEasterMonday() {
            Assert.AreEqual("2000-04-24", SocialUtils.Dates.GetEasterMonday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-16", SocialUtils.Dates.GetEasterMonday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-04-01", SocialUtils.Dates.GetEasterMonday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-21", SocialUtils.Dates.GetEasterMonday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-12", SocialUtils.Dates.GetEasterMonday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-28", SocialUtils.Dates.GetEasterMonday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-17", SocialUtils.Dates.GetEasterMonday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-09", SocialUtils.Dates.GetEasterMonday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-24", SocialUtils.Dates.GetEasterMonday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-13", SocialUtils.Dates.GetEasterMonday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-05", SocialUtils.Dates.GetEasterMonday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-25", SocialUtils.Dates.GetEasterMonday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-09", SocialUtils.Dates.GetEasterMonday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-04-01", SocialUtils.Dates.GetEasterMonday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-21", SocialUtils.Dates.GetEasterMonday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-06", SocialUtils.Dates.GetEasterMonday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-28", SocialUtils.Dates.GetEasterMonday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-17", SocialUtils.Dates.GetEasterMonday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-04-02", SocialUtils.Dates.GetEasterMonday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-22", SocialUtils.Dates.GetEasterMonday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-13", SocialUtils.Dates.GetEasterMonday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-05", SocialUtils.Dates.GetEasterMonday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-18", SocialUtils.Dates.GetEasterMonday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-10", SocialUtils.Dates.GetEasterMonday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-04-01", SocialUtils.Dates.GetEasterMonday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-21", SocialUtils.Dates.GetEasterMonday(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetAscensionDay() {
            Assert.AreEqual("2000-06-01", SocialUtils.Dates.GetAscensionDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-05-24", SocialUtils.Dates.GetAscensionDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-05-09", SocialUtils.Dates.GetAscensionDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-05-29", SocialUtils.Dates.GetAscensionDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-20", SocialUtils.Dates.GetAscensionDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-05-05", SocialUtils.Dates.GetAscensionDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-05-25", SocialUtils.Dates.GetAscensionDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-17", SocialUtils.Dates.GetAscensionDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-05-01", SocialUtils.Dates.GetAscensionDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-05-21", SocialUtils.Dates.GetAscensionDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-05-13", SocialUtils.Dates.GetAscensionDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-06-02", SocialUtils.Dates.GetAscensionDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-17", SocialUtils.Dates.GetAscensionDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-05-09", SocialUtils.Dates.GetAscensionDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-05-29", SocialUtils.Dates.GetAscensionDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-14", SocialUtils.Dates.GetAscensionDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-05-05", SocialUtils.Dates.GetAscensionDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-05-25", SocialUtils.Dates.GetAscensionDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-05-10", SocialUtils.Dates.GetAscensionDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-05-30", SocialUtils.Dates.GetAscensionDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-05-21", SocialUtils.Dates.GetAscensionDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-05-13", SocialUtils.Dates.GetAscensionDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-05-26", SocialUtils.Dates.GetAscensionDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-18", SocialUtils.Dates.GetAscensionDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-05-09", SocialUtils.Dates.GetAscensionDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-05-29", SocialUtils.Dates.GetAscensionDay(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetWhitSunday() {
            Assert.AreEqual("2000-06-11", SocialUtils.Dates.GetWhitSunday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-06-03", SocialUtils.Dates.GetWhitSunday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-05-19", SocialUtils.Dates.GetWhitSunday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-06-08", SocialUtils.Dates.GetWhitSunday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-30", SocialUtils.Dates.GetWhitSunday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-05-15", SocialUtils.Dates.GetWhitSunday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-06-04", SocialUtils.Dates.GetWhitSunday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-27", SocialUtils.Dates.GetWhitSunday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-05-11", SocialUtils.Dates.GetWhitSunday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-05-31", SocialUtils.Dates.GetWhitSunday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-05-23", SocialUtils.Dates.GetWhitSunday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-06-12", SocialUtils.Dates.GetWhitSunday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-27", SocialUtils.Dates.GetWhitSunday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-05-19", SocialUtils.Dates.GetWhitSunday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-06-08", SocialUtils.Dates.GetWhitSunday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-24", SocialUtils.Dates.GetWhitSunday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-05-15", SocialUtils.Dates.GetWhitSunday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-06-04", SocialUtils.Dates.GetWhitSunday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-05-20", SocialUtils.Dates.GetWhitSunday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-06-09", SocialUtils.Dates.GetWhitSunday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-05-31", SocialUtils.Dates.GetWhitSunday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-05-23", SocialUtils.Dates.GetWhitSunday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-06-05", SocialUtils.Dates.GetWhitSunday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-28", SocialUtils.Dates.GetWhitSunday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-05-19", SocialUtils.Dates.GetWhitSunday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-06-08", SocialUtils.Dates.GetWhitSunday(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetWhitMonday() {
            Assert.AreEqual("2000-06-12", SocialUtils.Dates.GetWhitMonday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-06-04", SocialUtils.Dates.GetWhitMonday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-05-20", SocialUtils.Dates.GetWhitMonday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-06-09", SocialUtils.Dates.GetWhitMonday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-31", SocialUtils.Dates.GetWhitMonday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-05-16", SocialUtils.Dates.GetWhitMonday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-06-05", SocialUtils.Dates.GetWhitMonday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-28", SocialUtils.Dates.GetWhitMonday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-05-12", SocialUtils.Dates.GetWhitMonday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-06-01", SocialUtils.Dates.GetWhitMonday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-05-24", SocialUtils.Dates.GetWhitMonday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-06-13", SocialUtils.Dates.GetWhitMonday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-28", SocialUtils.Dates.GetWhitMonday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-05-20", SocialUtils.Dates.GetWhitMonday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-06-09", SocialUtils.Dates.GetWhitMonday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-25", SocialUtils.Dates.GetWhitMonday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-05-16", SocialUtils.Dates.GetWhitMonday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-06-05", SocialUtils.Dates.GetWhitMonday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-05-21", SocialUtils.Dates.GetWhitMonday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-06-10", SocialUtils.Dates.GetWhitMonday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-06-01", SocialUtils.Dates.GetWhitMonday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-05-24", SocialUtils.Dates.GetWhitMonday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-06-06", SocialUtils.Dates.GetWhitMonday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-29", SocialUtils.Dates.GetWhitMonday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-05-20", SocialUtils.Dates.GetWhitMonday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-06-09", SocialUtils.Dates.GetWhitMonday(2025).ToString("yyyy-MM-dd"));
        }

    }

}