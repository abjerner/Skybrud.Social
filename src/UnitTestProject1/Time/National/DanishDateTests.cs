using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Social;

namespace UnitTestProject1.Time.National {
    
    [TestClass]
    public class DanishDateTests {

        [TestMethod]
        public void GetGeneralPrayerDay() {
            Assert.AreEqual("2000-05-19", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-05-11", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-04-26", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-05-16", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-07", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-04-22", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-05-12", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-04", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-04-18", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-05-08", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-30", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-05-20", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-04", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-04-26", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-05-16", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-01", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-04-22", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-05-12", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-04-27", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-05-17", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-05-08", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-30", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-05-13", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-05", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-04-26", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-05-16", SocialUtils.Dates.Denmark.GetGeneralPrayerDay(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetConstitutionDay() {
            Assert.AreEqual("2000-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-06-05", SocialUtils.Dates.Denmark.GetConstitutionDay(2025).ToString("yyyy-MM-dd"));
        }


    }

}