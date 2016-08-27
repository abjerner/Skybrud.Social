using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Social;

namespace UnitTestProject1.Utils {

    [TestClass]
    public class Security {

        [TestMethod]
        public void Base64Encode() {

            var samples = new[] {
                new { Input = "Hello World", Expected = "SGVsbG8gV29ybGQ=" },
                new { Input = "Rød grød med fløde", Expected = "UsO4ZCBncsO4ZCBtZWQgZmzDuGRl" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SocialUtils.Security.Base64Encode(sample.Input));
            }

        }

        [TestMethod]
        public void Base64Decode() {

            var samples = new[] {
                new { Input = "SGVsbG8gV29ybGQ=", Expected = "Hello World" },
                new { Input = "UsO4ZCBncsO4ZCBtZWQgZmzDuGRl", Expected = "Rød grød med fløde" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SocialUtils.Security.Base64Decode(sample.Input));
            }

        }

    }

}