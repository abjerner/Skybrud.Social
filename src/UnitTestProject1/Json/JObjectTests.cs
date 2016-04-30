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
        public void HasValue() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"obj\":{\"value\":\"1234\",\"nothing\":null,\"empty\":\"\",\"whitespace\":\"    \"}}}");

            Assert.AreEqual(false, obj.HasValue("root.nothing"), "Check #1 failed");
            Assert.AreEqual(false, obj.HasValue("root.obj.nothing"), "Check #2 failed");
            Assert.AreEqual(true, obj.HasValue("root.obj"), "Check #3 failed");
            Assert.AreEqual(true, obj.HasValue("root.obj.value"), "Check #4 failed");
            Assert.AreEqual(false, obj.HasValue("root.obj.empty"), "Check #5 failed");
            Assert.AreEqual(true, obj.HasValue("root.obj.whitespace"), "Check #6 failed");

        }

        [TestMethod]
        public void GetObject() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"obj\":{\"value\":\"1234\"}}}");

            Assert.AreEqual(null, obj.GetObject("nope"), "Check #1 failed");
            Assert.AreEqual(null, obj.GetObject("root.nothing"), "Check #2 failed");
            Assert.IsNotNull(obj.GetObject("root.obj"), "Check #3 failed");
            Assert.AreEqual("1234", obj.GetObject<TestObject>("root.obj").Value, "Check #4 failed");
            Assert.AreEqual("1234", obj.GetObject("root.obj", TestObject.Parse).Value, "Check #5 failed");

        }

        [TestMethod]
        public void GetString() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"obj\":{\"value\":\"1234\",\"nothing\":null,\"empty\":\"\",\"whitespace\":\"    \"}}}");

            Assert.AreEqual(null, obj.GetString("root.nope"), "Check #1 failed");
            Assert.AreEqual(null, obj.GetString("root.nothing"), "Check #2 failed");
            Assert.AreEqual("1234", obj.GetString("root.obj.value"), "Check #3 failed");
            Assert.AreEqual(null, obj.GetString("root.obj.nothing"), "Check #4 failed");
            Assert.AreEqual("", obj.GetString("root.obj.empty"), "Check #5 failed");
            Assert.AreEqual("    ", obj.GetString("root.obj.whitespace"), "Check #6 failed");

        }

        [TestMethod]
        public void GetInt32() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"obj\":{\"value\":\"1234\",\"nothing\":\"0\",\"number\":1234}}}");

            Assert.AreEqual(0, obj.GetInt32("root.nothing"), "Check #1 failed");
            Assert.AreEqual(1234, obj.GetInt32("root.obj.value"), "Check #2 failed");
            Assert.AreEqual(0, obj.GetInt32("root.obj.nothing"), "Check #3 failed");
            Assert.AreEqual(1234, obj.GetInt32("root.obj.number"), "Check #4 failed");
            Assert.AreEqual(1234, obj.GetInt32("root.obj.number", x => (int) TimeSpan.FromSeconds(x).TotalSeconds), "Check #5 failed");

        }

        [TestMethod]
        public void GetInt64() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"obj\":{\"value\":\"1234\",\"nothing\":\"0\",\"number\":2147483648}}}");

            Assert.AreEqual(0, obj.GetInt64("root.nothing"), "Check #1 failed");
            Assert.AreEqual(1234, obj.GetInt64("root.obj.value"), "Check #2 failed");
            Assert.AreEqual(0, obj.GetInt64("root.obj.nothing"), "Check #3 failed");
            Assert.AreEqual(2147483648, obj.GetInt64("root.obj.number"), "Check #4 failed");
            Assert.AreEqual(2147483648, obj.GetInt64("root.obj.number", x => (long) TimeSpan.FromSeconds(x).TotalSeconds), "Check #5 failed");

        }


        [TestMethod]
        public void GetFloat() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"obj\":{\"value\":\"0.123\",\"nothing\":\"0\",\"number\":1234.567}}}");

            Assert.AreEqual("0.000", String.Format("{0:0.000}", obj.GetFloat("nothing")), "Check #1 failed");
            Assert.AreEqual("0.000", String.Format("{0:0.000}", obj.GetFloat("root.nothing")), "Check #2 failed");
            Assert.AreEqual("0.123", String.Format("{0:0.000}", obj.GetFloat("root.obj.value")), "Check #3 failed");
            Assert.AreEqual("0.000", String.Format("{0:0.000}", obj.GetFloat("root.obj.nothing")), "Check #4 failed");
            Assert.AreEqual("1234.567", String.Format("{0:0.000}", obj.GetFloat("root.obj.number")), "Check #5 failed");

        }

        [TestMethod]
        public void GetDouble() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"obj\":{\"value\":\"0.123\",\"nothing\":\"0\",\"number\":1234.567}}}");

            Assert.AreEqual("0.000", String.Format("{0:0.000}", obj.GetDouble("nothing")), "Check #1 failed");
            Assert.AreEqual("0.000", String.Format("{0:0.000}", obj.GetDouble("root.nothing")), "Check #2 failed");
            Assert.AreEqual("0.123", String.Format("{0:0.000}", obj.GetDouble("root.obj.value")), "Check #3 failed");
            Assert.AreEqual("0.000", String.Format("{0:0.000}", obj.GetDouble("root.obj.nothing")), "Check #4 failed");
            Assert.AreEqual("1234.567", String.Format("{0:0.000}", obj.GetDouble("root.obj.number")), "Check #5 failed");

        }

        [TestMethod]
        public void GetBoolean() {
            
            JObject root = new JObject();
            root.Add("property1", null);
            root.Add("property2", true);
            root.Add("property3", false);
            root.Add("property4", 1);
            root.Add("property5", 0);
            root.Add("property6", "true");
            root.Add("property7", "false");

            JObject obj = new JObject();
            obj.Add("root", root);

            Assert.AreEqual(false, obj.GetBoolean("root.property0"), "Check #1 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property1"), "Check #2 failed");
            Assert.AreEqual(true, obj.GetBoolean("root.property2"), "Check #3 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property3"), "Check #4 failed");
            Assert.AreEqual(true, obj.GetBoolean("root.property4"), "Check #5 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property5"), "Check #6 failed");
            Assert.AreEqual(true, obj.GetBoolean("root.property6"), "Check #7 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property7"), "Check #8 failed");

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