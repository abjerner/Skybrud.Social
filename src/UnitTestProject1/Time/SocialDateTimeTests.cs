using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Social.Time;

namespace UnitTestProject1.Time {
    
    [TestClass]
    public class SocialDateTimeTests {

        [TestMethod]
        public void PlusTimeSpanOperator() {

            SocialDateTime a = new SocialDateTime(2016, 3, 4, 21, 0, 0);
            SocialDateTime b = new SocialDateTime(2016, 3, 5, 21, 0, 0);
            TimeSpan ts1 = TimeSpan.FromHours(23);
            TimeSpan ts2 = TimeSpan.FromHours(24);
            TimeSpan ts3 = TimeSpan.FromHours(25);

            Assert.AreEqual(false, (a + ts1).DateTime == b.DateTime);
            Assert.AreEqual(true, (a + ts2) == b.DateTime);
            Assert.AreEqual(false, (a + ts3) == b.DateTime);

        }

        [TestMethod]
        public void MinusTimeSpanOperator() {

            SocialDateTime a = new SocialDateTime(2016, 3, 4, 21, 0, 0);
            SocialDateTime b = new SocialDateTime(2016, 3, 3, 21, 0, 0);
            TimeSpan ts1 = TimeSpan.FromHours(23);
            TimeSpan ts2 = TimeSpan.FromHours(24);
            TimeSpan ts3 = TimeSpan.FromHours(25);

            Assert.AreEqual(false, (a - ts1).DateTime == b.DateTime);
            Assert.AreEqual(true, (a - ts2) == b.DateTime);
            Assert.AreEqual(false, (a - ts3) == b.DateTime);

        }

        [TestMethod]
        public void MinusOperator() {

            SocialDateTime a = new SocialDateTime(2016, 3, 4, 21, 0, 0);
            SocialDateTime b = new SocialDateTime(2016, 3, 3, 21, 0, 0);

            Assert.AreEqual(24, (a - b).TotalHours);

        }

        [TestMethod]
        public void EqualityOperator() {

            SocialDateTime a = new SocialDateTime(2016, 3, 4, 21, 0, 0);
            SocialDateTime b = new SocialDateTime(2016, 3, 3, 21, 0, 0);
            SocialDateTime c = new SocialDateTime(2016, 3, 4, 21, 0, 0);

            Assert.AreEqual(false, a == b);
            Assert.AreEqual(true, a == c);

        }

        [TestMethod]
        public void InequalityOperator() {

            SocialDateTime a = new SocialDateTime(2016, 3, 4, 21, 0, 0);
            SocialDateTime b = new SocialDateTime(2016, 3, 3, 21, 0, 0);
            SocialDateTime c = new SocialDateTime(2016, 3, 4, 21, 0, 0);

            Assert.AreEqual(true, a != b);
            Assert.AreEqual(false, a != c);

        }
        
        [TestMethod]
        public void LessThanOperator() {

            // Notice: this unit test will proably fail if run exactly at midnight

            // ReSharper disable ExpressionIsAlwaysNull
            // ReSharper disable EqualExpressionComparison
            
            SocialDateTime nada = null;
            SocialDateTime now = SocialDateTime.Now;
            SocialDateTime today = SocialDateTime.Today;
            
            Assert.AreEqual(false, now < nada);
            Assert.AreEqual(true, nada < now);
            Assert.AreEqual(true, today < now);
            Assert.AreEqual(false, now < today);
            Assert.AreEqual(false, nada < nada);

            // ReSharper restore ExpressionIsAlwaysNull
            // ReSharper restore EqualExpressionComparison

        }

        [TestMethod]
        public void LessThanOrEqualToOperator() {

            // Notice: this unit test will proably fail if run exactly at midnight

            // ReSharper disable ExpressionIsAlwaysNull
            // ReSharper disable EqualExpressionComparison

            SocialDateTime nada = null;
            SocialDateTime now = SocialDateTime.Now;
            SocialDateTime today = SocialDateTime.Today;

            Assert.AreEqual(false, now <= nada, "#1");
            Assert.AreEqual(true, nada <= now, "#2");
            Assert.AreEqual(true, today <= now, "#3");
            Assert.AreEqual(false, now <= today, "#4");
            Assert.AreEqual(true, nada <= nada, "#5");
            Assert.AreEqual(true, today <= today, "#6");

            // ReSharper restore ExpressionIsAlwaysNull
            // ReSharper restore EqualExpressionComparison

        }

        [TestMethod]
        public void GreaterThanOperator() {

            // Notice: this unit test will proably fail if run exactly at midnight

            // ReSharper disable ExpressionIsAlwaysNull
            // ReSharper disable EqualExpressionComparison

            SocialDateTime nada = null;
            SocialDateTime now = SocialDateTime.Now;
            SocialDateTime today = SocialDateTime.Today;

            Assert.AreEqual(true, now > nada, "#1");
            Assert.AreEqual(false, nada > now, "#2");
            Assert.AreEqual(false, today > now, "#3");
            Assert.AreEqual(true, now > today, "#4");
            Assert.AreEqual(false, nada > nada, "#5");

            // ReSharper restore ExpressionIsAlwaysNull
            // ReSharper restore EqualExpressionComparison

        }

        [TestMethod]
        public void GreaterThanOrEqualToOperator() {

            // Notice: this unit test will proably fail if run exactly at midnight

            // ReSharper disable ExpressionIsAlwaysNull
            // ReSharper disable EqualExpressionComparison

            SocialDateTime nada = null;
            SocialDateTime now = SocialDateTime.Now;
            SocialDateTime today = SocialDateTime.Today;

            Assert.AreEqual(true, now >= nada, "#1");
            Assert.AreEqual(false, nada >= now, "#2");
            Assert.AreEqual(false, today >= now, "#3");
            Assert.AreEqual(true, now >= today, "#4");
            Assert.AreEqual(true, nada >= nada, "#5");
            Assert.AreEqual(true, today >= today, "#6");

            // ReSharper restore ExpressionIsAlwaysNull
            // ReSharper restore EqualExpressionComparison

        }
    
    }

}