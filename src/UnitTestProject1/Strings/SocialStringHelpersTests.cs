using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Social;

namespace UnitTestProject1.Strings {

    [TestClass]
    public class SocialStringHelpersTests {

        [TestMethod]
        public void ToUnderscore() {

            var samples = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "HelloWorld", Expected = "hello_world" },
                new { Input = "helloWorld", Expected = "hello_world" },
                new { Input = "HELLO_WORLD", Expected = "hello_world" },
                new { Input = "HelloWorld", Expected = "hello_world" },
                new { Input = "Hello World", Expected = "hello_world" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SocialUtils.Strings.ToUnderscore(sample.Input));
            }

        }

        [TestMethod]
        public void ToCamelCase() {

            var samples = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "helloWorld" },
                new { Input = "HELLO_WORLD", Expected = "helloWorld" },
                new { Input = "HelloWorld", Expected = "helloWorld" },
                new { Input = "Hello World", Expected = "helloWorld" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SocialUtils.Strings.ToCamelCase(sample.Input));
            }

        }

        [TestMethod]
        public void ToPascalCase() {

            var samples = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "HelloWorld" },
                new { Input = "HELLO_WORLD", Expected = "HelloWorld" },
                new { Input = "HelloWorld", Expected = "HelloWorld" },
                new { Input = "Hello World", Expected = "HelloWorld" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SocialUtils.Strings.ToPascalCase(sample.Input));
            }

        }

        [TestMethod]
        public void FirstCharToUpper() {

            var samples = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "Hello_world" },
                new { Input = "HELLO_WORLD", Expected = "HELLO_WORLD" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SocialUtils.Strings.FirstCharToUpper(sample.Input));
            }

        }

    }

}