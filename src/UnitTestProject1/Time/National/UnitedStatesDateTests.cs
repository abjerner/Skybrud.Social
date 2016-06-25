using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Social;

namespace UnitTestProject1.Time.National {
    
    [TestClass]
    public class UnitedStatesDateTests {

        [TestMethod]
        public void GetIndependenceDay() {
            Assert.AreEqual("2000-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-07-04", SocialUtils.Dates.UnitedStates.GetIndependenceDay(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetLaborDay() {
            Assert.AreEqual("2000-09-04", SocialUtils.Dates.UnitedStates.GetLaborDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-09-03", SocialUtils.Dates.UnitedStates.GetLaborDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-09-02", SocialUtils.Dates.UnitedStates.GetLaborDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-09-01", SocialUtils.Dates.UnitedStates.GetLaborDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-09-06", SocialUtils.Dates.UnitedStates.GetLaborDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-09-05", SocialUtils.Dates.UnitedStates.GetLaborDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-09-04", SocialUtils.Dates.UnitedStates.GetLaborDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-09-03", SocialUtils.Dates.UnitedStates.GetLaborDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-09-01", SocialUtils.Dates.UnitedStates.GetLaborDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-09-07", SocialUtils.Dates.UnitedStates.GetLaborDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-09-06", SocialUtils.Dates.UnitedStates.GetLaborDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-09-05", SocialUtils.Dates.UnitedStates.GetLaborDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-09-03", SocialUtils.Dates.UnitedStates.GetLaborDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-09-02", SocialUtils.Dates.UnitedStates.GetLaborDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-09-01", SocialUtils.Dates.UnitedStates.GetLaborDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-09-07", SocialUtils.Dates.UnitedStates.GetLaborDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-09-05", SocialUtils.Dates.UnitedStates.GetLaborDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-09-04", SocialUtils.Dates.UnitedStates.GetLaborDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-09-03", SocialUtils.Dates.UnitedStates.GetLaborDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-09-02", SocialUtils.Dates.UnitedStates.GetLaborDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-09-07", SocialUtils.Dates.UnitedStates.GetLaborDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-09-06", SocialUtils.Dates.UnitedStates.GetLaborDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-09-05", SocialUtils.Dates.UnitedStates.GetLaborDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-09-04", SocialUtils.Dates.UnitedStates.GetLaborDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-09-02", SocialUtils.Dates.UnitedStates.GetLaborDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-09-01", SocialUtils.Dates.UnitedStates.GetLaborDay(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetMemorialDay() {
            Assert.AreEqual("2000-05-01", SocialUtils.Dates.UnitedStates.GetMemorialDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-05-07", SocialUtils.Dates.UnitedStates.GetMemorialDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-05-06", SocialUtils.Dates.UnitedStates.GetMemorialDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-05-05", SocialUtils.Dates.UnitedStates.GetMemorialDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-03", SocialUtils.Dates.UnitedStates.GetMemorialDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-05-02", SocialUtils.Dates.UnitedStates.GetMemorialDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-05-01", SocialUtils.Dates.UnitedStates.GetMemorialDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-07", SocialUtils.Dates.UnitedStates.GetMemorialDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-05-05", SocialUtils.Dates.UnitedStates.GetMemorialDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-05-04", SocialUtils.Dates.UnitedStates.GetMemorialDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-05-03", SocialUtils.Dates.UnitedStates.GetMemorialDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-05-02", SocialUtils.Dates.UnitedStates.GetMemorialDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-07", SocialUtils.Dates.UnitedStates.GetMemorialDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-05-06", SocialUtils.Dates.UnitedStates.GetMemorialDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-05-05", SocialUtils.Dates.UnitedStates.GetMemorialDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-04", SocialUtils.Dates.UnitedStates.GetMemorialDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-05-02", SocialUtils.Dates.UnitedStates.GetMemorialDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-05-01", SocialUtils.Dates.UnitedStates.GetMemorialDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-05-07", SocialUtils.Dates.UnitedStates.GetMemorialDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-05-06", SocialUtils.Dates.UnitedStates.GetMemorialDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-05-04", SocialUtils.Dates.UnitedStates.GetMemorialDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-05-03", SocialUtils.Dates.UnitedStates.GetMemorialDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-05-02", SocialUtils.Dates.UnitedStates.GetMemorialDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-01", SocialUtils.Dates.UnitedStates.GetMemorialDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-05-06", SocialUtils.Dates.UnitedStates.GetMemorialDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-05-05", SocialUtils.Dates.UnitedStates.GetMemorialDay(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetPatriotDay() {
            Assert.AreEqual("2000-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-09-11", SocialUtils.Dates.UnitedStates.GetPatriotDay(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetThanksgivingDay() {
            Assert.AreEqual("2000-11-23", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-11-22", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-11-28", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-11-27", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-11-25", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-11-24", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-11-23", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-11-22", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-11-27", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-11-26", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-11-25", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-11-24", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-11-22", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-11-28", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-11-27", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-11-26", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-11-24", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-11-23", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-11-22", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-11-28", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-11-26", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-11-25", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-11-24", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-11-23", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-11-28", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-11-27", SocialUtils.Dates.UnitedStates.GetThanksgivingDay(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetVeteransDay() {
            Assert.AreEqual("2000-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-11-11", SocialUtils.Dates.UnitedStates.GetVeteransDay(2025).ToString("yyyy-MM-dd"));
        }

    }

}