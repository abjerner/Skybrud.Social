using System.Text;
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

        [TestMethod]
        public void GetMd5Hash() {

            var samples = new[] {
                new { Input = "Hello World", Expected = "b10a8db164e0754105b7a99be72e3fe5" },
                new { Input = "Rød grød med fløde", Expected = "64d6f69ac402593bc004c8adf3db4b22" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SocialUtils.Security.GetMd5Hash(sample.Input), "Failed hashing " + sample.Input + " (no encoding)");
                Assert.AreEqual(sample.Expected, SocialUtils.Security.GetMd5Hash(sample.Input, Encoding.UTF8), "Failed hashing " + sample.Input + " (UTF8)");
            }
        
        }

        [TestMethod]
        public void GetSha1Hash() {

            var samples = new[] {
                new { Input = "Hello World", Expected = "0a4d55a8d778e5022fab701977c5d840bbc486d0" },
                new { Input = "Rød grød med fløde", Expected = "20a219e95c358780bfc974bd47ae13ba49a6e871" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SocialUtils.Security.GetSha1Hash(sample.Input), "Failed hashing " + sample.Expected + " (no encoding)");
                Assert.AreEqual(sample.Expected, SocialUtils.Security.GetSha1Hash(sample.Input, Encoding.UTF8), "Failed hashing " + sample.Expected + " (UTF8)");
            }
        
        }

        [TestMethod]
        public void GetSha256Hash() {

            var samples = new[] {
                new { Input = "Hello World", Expected = "a591a6d40bf420404a011733cfb7b190d62c65bf0bcda32b57b277d9ad9f146e" },
                new { Input = "Rød grød med fløde", Expected = "16037d3adef43eb338b1b96bb6ee1211c5906bdb671a5aae92be62a744ada72b" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SocialUtils.Security.GetSha256Hash(sample.Input), "Failed hashing " + sample.Expected + " (no encoding)");
                Assert.AreEqual(sample.Expected, SocialUtils.Security.GetSha256Hash(sample.Input, Encoding.UTF8), "Failed hashing " + sample.Expected + " (UTF8)");
            }
        
        }

        [TestMethod]
        public void GetSha512Hash() {

            var samples = new[] {
                new { Input = "Hello World", Expected = "2c74fd17edafd80e8447b0d46741ee243b7eb74dd2149a0ab1b9246fb30382f27e853d8585719e0e67cbda0daa8f51671064615d645ae27acb15bfb1447f459b" },
                new { Input = "Rød grød med fløde", Expected = "23d6e34e1a04aff3c4971d9666d4b4e490dda54ea4241083dc4f18f9bd813333de4731c90ea6c9b7913cc42cd0a9f5b8bd734b07cad5fb5359de4db3e9bb7476" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SocialUtils.Security.GetSha512Hash(sample.Input), "Failed hashing " + sample.Expected + " (no encoding)");
                Assert.AreEqual(sample.Expected, SocialUtils.Security.GetSha512Hash(sample.Input, Encoding.UTF8), "Failed hashing " + sample.Expected + " (UTF8)");
            }
        
        }

    }

}