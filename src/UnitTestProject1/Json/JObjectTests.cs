using Newtonsoft.Json;
using Skybrud.Social.Json.Extensions;
// ReSharper disable UseObjectOrCollectionInitializer
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace UnitTestProject1.Json {

    [TestClass]
    public class JObjectTests {

        [TestMethod]
        public void GetObject() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"obj\":{\"value\":\"1234\"}}}");

            Assert.AreEqual(null, obj.GetObject("nope"), "#1");
            Assert.AreEqual(null, obj.GetObject("root.nothing"), "#2");
            Assert.IsNotNull(obj.GetObject("root.obj"), "#3");
            Assert.AreEqual("1234", obj.GetObject<TestObject>("root.obj").Value, "#4");
            Assert.AreEqual("1234", obj.GetObject("root.obj", TestObject.Parse).Value, "#5");

        }
        
        [TestMethod]
        public void HasValue() {

            JObject obj = new JObject();
            obj.Add("property1", null);
            obj.Add("property2", "");
            obj.Add("property3", " ");

            Assert.AreEqual(false, obj.HasValue("property0"), "0");
            Assert.AreEqual(false, obj.HasValue("property1"), "1");
            Assert.AreEqual(false, obj.HasValue("property2"), "2");
            Assert.AreEqual(true, obj.HasValue("property3"), "3");
            
            //Assert.IsFalse(obj.HasValue("property1"), "Check for property 1 failed");
            //Assert.IsFalse(obj.HasValue("property2"), "Check for property 2 failed");
            //Assert.IsTrue(obj.HasValue("property3"), "Check for property 3 failed");

        }

        [TestMethod]
        public void GetStringArray() {

            JObject obj = new JObject();
            obj.Add("property1", null);
            obj.Add("property2", new JArray("hello", "world"));

            Assert.AreEqual(null, obj.GetStringArray("property1"));
            Assert.AreEqual("hello,world", String.Join(",", obj.GetStringArray("property2")));

        }

        [TestMethod]
        public void GetInt32Array() {

            JObject obj = new JObject();
            obj.Add("property1", null);
            obj.Add("property2", new JArray(123, 456));
            obj.Add("property3", new JArray("123", "456"));

            Assert.AreEqual(null, obj.GetInt32Array("property1"));
            Assert.AreEqual("123,456", String.Join(",", obj.GetInt32Array("property2")));
            Assert.AreEqual("123,456", String.Join(",", obj.GetInt32Array("property3")));

        }

        [TestMethod]
        public void GetInt64Array() {

            JObject obj = new JObject();
            obj.Add("property1", null);
            obj.Add("property2", new JArray(123, 456));
            obj.Add("property3", new JArray("123", "456"));

            Assert.AreEqual(null, obj.GetInt32Array("property1"));
            Assert.AreEqual("123,456", String.Join(",", obj.GetInt64Array("property2")));
            Assert.AreEqual("123,456", String.Join(",", obj.GetInt64Array("property3")));

        }

        [TestMethod]
        public void GetInt32() {

            JObject obj = new JObject();
            obj.Add("property1", null);
            obj.Add("property2", 0);
            obj.Add("property3", "0");
            obj.Add("property4", 12345);
            obj.Add("property5", "12345");

            Assert.AreEqual(0, obj.GetInt32("property1"));
            Assert.AreEqual(0, obj.GetInt32("property2"));
            Assert.AreEqual(0, obj.GetInt32("property3"));
            Assert.AreEqual(12345, obj.GetInt32("property4"));
            Assert.AreEqual(12345, obj.GetInt32("property5"));

        }

        [TestMethod]
        public void GetInt64() {

            JObject obj = new JObject();
            obj.Add("property1", null);
            obj.Add("property2", 0);
            obj.Add("property3", "0");
            obj.Add("property4", 12345);
            obj.Add("property5", "12345");

            Assert.AreEqual(0, obj.GetInt64("property1"));
            Assert.AreEqual(0, obj.GetInt64("property2"));
            Assert.AreEqual(0, obj.GetInt64("property3"));
            Assert.AreEqual(12345, obj.GetInt64("property4"));
            Assert.AreEqual(12345, obj.GetInt64("property5"));

        }

        [TestMethod]
        public void GetFloat() {

            JObject obj = new JObject();
            obj.Add("property1", null);
            obj.Add("property2", 0);
            obj.Add("property3", "0.12");
            obj.Add("property4", 0.123);
            obj.Add("property5", 1234.567);

            Assert.AreEqual("0.000", String.Format("{0:0.000}", obj.GetFloat("property0")));
            Assert.AreEqual("0.000", String.Format("{0:0.000}", obj.GetFloat("property1")));
            Assert.AreEqual("0.000", String.Format("{0:0.000}", obj.GetFloat("property2")));
            Assert.AreEqual("0.120", String.Format("{0:0.000}", obj.GetFloat("property3")));
            Assert.AreEqual("0.123", String.Format("{0:0.000}", obj.GetFloat("property4")));
            Assert.AreEqual("1234.567", String.Format("{0:0.000}", obj.GetFloat("property5")));

        }

        [TestMethod]
        public void GetDouble() {

            JObject obj = new JObject();
            obj.Add("property1", null);
            obj.Add("property2", 0);
            obj.Add("property3", "0.12");
            obj.Add("property4", 0.123);
            obj.Add("property5", 1234.567);

            Assert.AreEqual("0.000", String.Format("{0:0.000}", obj.GetDouble("property0")));
            Assert.AreEqual("0.000", String.Format("{0:0.000}", obj.GetDouble("property1")));
            Assert.AreEqual("0.000", String.Format("{0:0.000}", obj.GetDouble("property2")));
            Assert.AreEqual("0.120", String.Format("{0:0.000}", obj.GetDouble("property3")));
            Assert.AreEqual("0.123", String.Format("{0:0.000}", obj.GetDouble("property4")));
            Assert.AreEqual("1234.567", String.Format("{0:0.000}", obj.GetDouble("property5")));

        }

        [TestMethod]
        public void GetBoolean() {

            JObject obj = new JObject();
            obj.Add("property1", null);
            obj.Add("property2", true);
            obj.Add("property3", false);
            obj.Add("property4", 1);
            obj.Add("property5", 0);
            obj.Add("property6", "true");
            obj.Add("property7", "false");

            Assert.AreEqual(false, obj.GetBoolean("property0"));
            Assert.AreEqual(false, obj.GetBoolean("property1"));
            Assert.AreEqual(true, obj.GetBoolean("property2"));
            Assert.AreEqual(false, obj.GetBoolean("property3"));
            Assert.AreEqual(true, obj.GetBoolean("property4"));
            Assert.AreEqual(false, obj.GetBoolean("property5"));
            Assert.AreEqual(true, obj.GetBoolean("property6"));
            Assert.AreEqual(false, obj.GetBoolean("property7"));

        }

        [TestMethod]
        public void GetArray() {

            JObject obj = new JObject();
            obj.Add("property1", null);
            obj.Add("property2", new JArray());
            obj.Add("property3", new JArray(1,2,3));

            Assert.AreEqual(null, obj.GetArray("property0"));
            Assert.AreEqual(null, obj.GetArray("property1"));
            Assert.AreEqual(0, obj.GetArray("property2").Count);
            Assert.AreEqual(3, obj.GetArray("property3").Count);

        }
        
        public class TestObject {
            [JsonProperty("value")]
            public string Value { get; set; }
            public static TestObject Parse(JObject obj) {
                return obj == null ? null : new TestObject { Value = obj.GetString("value") };
            }
        }
    
    }

}

// ReSharper restore UseObjectOrCollectionInitializer