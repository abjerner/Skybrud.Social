using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Social;

namespace UnitTestProject1.Utils {

    [TestClass]
    public class Locations {

        [TestMethod]
        public void GetDistance() {

            // Values used for comparison comes from lines plotted into Google Maps. Google uses a varying number
            // decimals depending on the distance, so we loose a bit precision when rounding. But the results of this
            // unit test still shows that the method works (eg. the test will fail if using the mean radius rather than
            // the equatorial radius).

            var samples = new[] {
                new { From = new SocialLocation(55.6946159, 10.0366974), To = new SocialLocation(55.6477614, 10.1589203), Expected = "9.28", Decimals = 2 },
                new { From = new SocialLocation(54.8671242, 7.7124023), To = new SocialLocation(56.8159142, 12.2113037), Expected = "355", Decimals = 0 },
                new { From = new SocialLocation(49.2104204, -6.1083984), To = new SocialLocation(59.578851, 22.9833984), Expected = "2184", Decimals = 0 },
                new { From = new SocialLocation(12.3829283, -71.3671875), To = new SocialLocation(71.2443555, 25.4882813), Expected = "8958", Decimals = 0 }
            };

            foreach (var sample in samples) {

                string format = "{0:0." + ("".PadLeft(sample.Decimals, '0')) + "}";

                Assert.AreEqual(sample.Expected, String.Format(format, SocialUtils.Locations.GetDistance(sample.From, sample.To) / 1000));
            
            }

        }

    }

}