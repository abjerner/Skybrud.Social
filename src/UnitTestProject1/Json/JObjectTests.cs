using System.Net;
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
        public void GetEnumValue() {

            JObject root = new JObject();
            root.Add("property1", "NotFound");
            root.Add("property2", "notfound");
            root.Add("property3", "not_found");
            root.Add("property4", "OK");
            root.Add("property5", "Ok");
            root.Add("property6", "ok");

            JObject obj = new JObject();
            obj.Add("root", root);

            Assert.AreEqual(HttpStatusCode.NotFound, obj.GetEnum<HttpStatusCode>("root.property1"), "Check #1 failed");
            Assert.AreEqual(HttpStatusCode.NotFound, obj.GetEnum<HttpStatusCode>("root.property2"), "Check #2 failed");
            Assert.AreEqual(HttpStatusCode.NotFound, obj.GetEnum<HttpStatusCode>("root.property3"), "Check #3 failed");
            Assert.AreEqual(HttpStatusCode.OK, obj.GetEnum<HttpStatusCode>("root.property4"), "Check #4 failed");
            Assert.AreEqual(HttpStatusCode.OK, obj.GetEnum<HttpStatusCode>("root.property5"), "Check #5 failed");
            Assert.AreEqual(HttpStatusCode.OK, obj.GetEnum<HttpStatusCode>("root.property6"), "Check #6 failed");

        }

        [TestMethod]
        public void GetArray() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[123,456,789]}}");

            Assert.AreEqual(null, obj.GetArray("null"), "Check #1 failed");
            Assert.AreEqual(null, obj.GetArray("nothing"), "Check #2 failed");
            Assert.AreEqual(3, obj.GetArray("root.array").Count, "Check #3 failed");

        }

        [TestMethod]
        public void GetArrayItems1() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[123,456,789]}}");

            JToken[] array1 = obj.GetArrayItems("nope");
            int[] array2 = obj.GetArrayItems<int>("nope");

            JToken[] array3 = obj.GetArrayItems("null");
            int[] array4 = obj.GetArrayItems<int>("null");

            JToken[] array5 = obj.GetArrayItems("root.array");
            int[] array6 = obj.GetArrayItems<int>("root.array");

            Assert.AreEqual(0, array1.Length, "Check #1 failed");
            Assert.AreEqual(0, array2.Length, "Check #2 failed");
            Assert.AreEqual(0, array3.Length, "Check #3 failed");
            Assert.AreEqual(0, array4.Length, "Check #4 failed");
            Assert.AreEqual(3, array5.Length, "Check #5 failed");
            Assert.AreEqual(3, array6.Length, "Check #6 failed");

            Assert.AreEqual(123, array5[0], "Check #7 failed");
            Assert.AreEqual(456, array5[1], "Check #8 failed");
            Assert.AreEqual(789, array5[2], "Check #9 failed");

        }

        [TestMethod]
        public void GetArrayItems2() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[{\"value\":\"Alpha\"},{\"value\":\"Bravo\"},{\"value\":\"Charlie\"}]}}");

            TestObject[] array1 = obj.GetArrayItems<JObject, TestObject>("nope", TestObject.Parse);
            TestObject[] array2 = obj.GetArrayItems("nope", TestObject.Parse);

            TestObject[] array3 = obj.GetArrayItems<JObject, TestObject>("null", TestObject.Parse);
            TestObject[] array4 = obj.GetArrayItems("null", TestObject.Parse);

            TestObject[] array5 = obj.GetArrayItems<JObject, TestObject>("root.array", TestObject.Parse);
            TestObject[] array6 = obj.GetArrayItems("root.array", TestObject.Parse);

            Assert.AreEqual(0, array1.Length, "Check #1 failed");
            Assert.AreEqual(0, array2.Length, "Check #2 failed");
            Assert.AreEqual(0, array3.Length, "Check #3 failed");
            Assert.AreEqual(0, array4.Length, "Check #4 failed");
            Assert.AreEqual(3, array5.Length, "Check #5 failed");
            Assert.AreEqual(3, array6.Length, "Check #6 failed");

            Assert.AreEqual("Alpha", array5[0].Value, "Check #7 failed");
            Assert.AreEqual("Bravo", array5[1].Value, "Check #8 failed");
            Assert.AreEqual("Charlie", array5[2].Value, "Check #9 failed");

        }

        [TestMethod]
        public void GetStringArray() {
            
            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[\"Alpha\",\"Bravo\",\"Charlie\"]}}");

            Assert.AreEqual(0, obj.GetStringArray("null").Length, "Check #1 failed");
            Assert.AreEqual(0, obj.GetStringArray("nothing").Length, "Check #2 failed");
            Assert.AreEqual(3, obj.GetStringArray("root.array").Length, "Check #3 failed");
            Assert.AreEqual("Alpha,Bravo,Charlie", String.Join(",", obj.GetStringArray("root.array")), "Check #4 failed");

        }

        [TestMethod]
        public void GetInt32Array() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[123,456,789]}}");

            Assert.AreEqual(0, obj.GetInt32Array("null").Length, "Check #1 failed");
            Assert.AreEqual(0, obj.GetInt32Array("nothing").Length, "Check #2 failed");
            Assert.AreEqual(3, obj.GetInt32Array("root.array").Length, "Check #3 failed");
            Assert.AreEqual("123,456,789", String.Join(",", obj.GetInt32Array("root.array")), "Check #4 failed");

        }

        [TestMethod]
        public void GetInt64Array() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[123,456,789]}}");

            Assert.AreEqual(0, obj.GetInt64Array("null").Length, "Check #1 failed");
            Assert.AreEqual(0, obj.GetInt64Array("nothing").Length, "Check #2 failed");
            Assert.AreEqual(3, obj.GetInt64Array("root.array").Length, "Check #3 failed");
            Assert.AreEqual("123,456,789", String.Join(",", obj.GetInt64Array("root.array")), "Check #4 failed");

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