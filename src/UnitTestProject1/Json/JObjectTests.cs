using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace UnitTestProject1.Json {

    [TestClass]
    public class UnitTest1 {
        
        [TestMethod]
        public void HasValue() {

            JObject obj = new JObject {
                {"property1", null},
                {"property2", ""},
                {"property3", " "}
            };
            
            Assert.IsFalse(obj.HasValue("property1"), "Check for property 1 failed");
            Assert.IsFalse(obj.HasValue("property2"), "Check for property 2 failed");
            Assert.IsTrue(obj.HasValue("property3"), "Check for property 3 failed");

        }

        [TestMethod]
        public void GetStringArray() {

            JObject obj = new JObject {
                {"property1", null},
                {"property2", new JArray("hello", "world")}
            };

            //Assert.AreEqual(null, obj.GetStringArray("property1")); // <-- probably throws an exception
            Assert.AreEqual("hello,world", String.Join(",", obj.GetStringArray("property2")));

        }

        [TestMethod]
        public void GetInt32() {

            JObject obj = new JObject {
                {"property1", null},
                {"property2", 0},
                {"property3", "0"},
                {"property4", 12345},
                {"property5", "12345"}
            };

            Assert.AreEqual(0, obj.GetInt32("property1"));
            Assert.AreEqual(0, obj.GetInt32("property2"));
            Assert.AreEqual(0, obj.GetInt32("property3"));
            Assert.AreEqual(12345, obj.GetInt32("property4"));
            Assert.AreEqual(12345, obj.GetInt32("property5"));

        }

        [TestMethod]
        public void GetInt64() {

            JObject obj = new JObject {
                {"property1", null},
                {"property2", 0},
                {"property3", "0"},
                {"property4", 12345},
                {"property5", "12345"}
            };

            Assert.AreEqual(0, obj.GetInt64("property1"));
            Assert.AreEqual(0, obj.GetInt64("property2"));
            Assert.AreEqual(0, obj.GetInt64("property3"));
            Assert.AreEqual(12345, obj.GetInt64("property4"));
            Assert.AreEqual(12345, obj.GetInt64("property5"));

        }
    
    }

}