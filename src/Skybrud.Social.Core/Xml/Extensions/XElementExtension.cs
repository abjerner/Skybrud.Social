using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Skybrud.Social.Exceptions;
using Skybrud.Social.Time;

namespace Skybrud.Social.Xml.Extensions {
    
    /// <summary>
    /// Class with various extension methods for <see cref="XElement"/>.
    /// </summary>
    public static class XElementExtension {

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code>.
        /// </summary>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>Returns the value of the attribute, or <code>null</code> if not found.</returns>
        public static string GetAttributeValue(this XElement element, XName name) {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? null : child.Value;
        }

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>Returns an instance of <see cref="T"/> represnting the attribute value, or the default value of
        /// <see cref="T"/> if not found.</returns>
        public static T GetAttributeValue<T>(this XElement element, XName name) {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? default(T) : (T) Convert.ChangeType(child.Value, typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="callback">A callback function for parsing the attribute value.</param>
        /// <returns>Returns the value as parsed by the specified <code>callback</code>.</returns>
        public static T GetAttributeValue<T>(this XElement element, XName name, Func<string, T> callback) {
            XAttribute child = element == null ? null : element.Attribute(name);
            return callback(child == null ? null : child.Value);
        }

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="callback">A callback function for parsing the attribute value.</param>
        /// <returns>Returns the value as parsed by the specified <code>callback</code>.</returns>
        public static TResult GetAttributeValue<T, TResult>(this XElement element, XName name, Func<T, TResult> callback) {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? default(TResult) : callback((T) Convert.ChangeType(child.Value, typeof(T), CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code> as an instance of <see cref="Int32"/>.
        /// </summary>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>Returns an instance of <see cref="Int32"/>, or <code>0</code> if the attribute isn't found.</returns>
        public static int GetAttributeAsInt32(this XElement element, XName name) {
            return GetAttributeValue<int>(element, name);
        }

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code> as an instance of <see cref="Int32"/>.
        /// </summary>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="callback">A callback function for parsing the attribute value.</param>
        /// <returns>Returns an instance of <see cref="Int32"/>, or <code>0</code> if the attribute isn't found.</returns>
        public static T GetAttributeAsInt32<T>(this XElement element, XName name, Func<int, T> callback) {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? default(T) : callback((int) Convert.ChangeType(child.Value, typeof(Int32), CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code> as an instance of <see cref="Int64"/>.
        /// </summary>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>Returns an instance of <see cref="Int64"/>, or <code>0</code> if the attribute isn't found.</returns>
        public static long GetAttributeAsInt64(this XElement element, XName name) {
            return GetAttributeValue<long>(element, name);
        }

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code> as an instance of <see cref="Int64"/>.
        /// </summary>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="callback">A callback function for parsing the attribute value.</param>
        /// <returns>Returns an instance of <see cref="Int64"/>, or <code>0</code> if the attribute isn't found.</returns>
        public static T GetAttributeAsInt64<T>(this XElement element, XName name, Func<long, T> callback) {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? default(T) : callback((long) Convert.ChangeType(child.Value, typeof(Int64), CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code> as an instance of <see cref="Boolean"/>.
        /// </summary>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>Returns an instance of <see cref="Boolean"/>, or <code>false</code> if the attribute isn't found.</returns>
        public static bool GetAttributeAsBoolean(this XElement element, XName name) {
            string value = (GetAttributeValue(element, name) ?? "").ToLower();
            return value == "true" || value == "1" || value == "t";
        }

        /// <summary>
        /// Gets an instance of <see cref="T"/> based on the value of the attribute matching the specified
        /// <code>name</code>. An exception of the type <see cref="EnumParseException"/> will be thrown if the
        /// attribute value doesn't match any of the values of <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>Returns an instance of </returns>
        public static T GetAttributeAsEnum<T>(this XElement element, XName name) where T : struct {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? default(T) : SocialUtils.Enums.ParseEnum<T>(child.Value);
        }

        /// <summary>
        /// Gets an instance of <see cref="T"/> based on the value of the attribute matching the specified
        /// <code>name</code>. If the value cant be parsed, <code>fallback</code> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="fallback">A fallback used if the attribute value doesn't match any of the values of
        /// <see cref="T"/>.</param>
        /// <returns>Returns an instance of <see cref="T"/>.</returns>
        public static T GetAttributeAsEnum<T>(this XElement element, XName name, T fallback) where T : struct {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? fallback : SocialUtils.Enums.ParseEnum(child.Value, fallback);
        }

        /// <summary>
        /// Gets the first <see cref="XElement"/> matching the specified <code>name</code>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the element.</param>
        /// <returns>Returns an instance of <see cref="XElement"/>, or <code>null</code> if <code>name</code> doesn't match any elements.</returns>
        public static XElement GetElement(this XElement element, XName name) {
            return element == null ? null : element.Element(name);
        }

        /// <summary>
        /// Gets the first <see cref="XElement"/> matching the specified <code>name</code> and parses it using <code>callback</code>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the element.</param>
        /// <param name="callback">A callback function for parsing the element.</param>
        /// <returns>Returns the value as parsed by the specified <code>callback</code>.</returns>
        public static T GetElement<T>(this XElement element, XName name, Func<XElement, T> callback) {
            return callback(element == null ? null : element.Element(name));
        }

        /// <summary>
        /// Gets the value of the element matching the specified <code>expression</code>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <returns>Returns the value of the element, or <code>null</code> if not found.</returns>
        public static string GetElementValue(this XElement element, string expression) {
            XElement child = element == null ? null : element.XPathSelectElement(expression);
            return child == null ? null : child.Value;
        }

        /// <summary>
        /// Gets the value of the element matching the specified <code>expression</code>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">A <see cref="System.String"/> that contains an XPath expression..</param>
        /// <param name="resolver">An <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression..</param>
        /// <returns>Returns the value of the element, or <code>null</code> if not found.</returns>
        public static string GetElementValue(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            XElement child = element == null ? null : element.XPathSelectElement(expression, resolver);
            return child == null ? null : child.Value;
        }

        /// <summary>
        /// Gets the value of the first child element with the specified <see cref="XName"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> to match.</param>
        /// <returns>Returns the value of the element, or <code>null</code> if not found.</returns>
        public static string GetElementValue(this XElement element, XName name) {
            XElement child = element == null ? null : element.Element(name);
            return child == null ? null : child.Value;
        }

        /// <summary>
        /// Gets the value of the first child element with the specified <see cref="XName"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> to match.</param>
        /// <param name="callback">A callback function for parsing the element.</param>
        /// <returns>Returns the value as parsed by the specified <code>callback</code>.</returns>
        public static T GetElementValue<T>(this XElement element, XName name, Func<string, T> callback) {
            XElement child = element == null ? null : element.Element(name);
            return callback(child == null ? null : child.Value);
        }

        /// <summary>
        /// Gets an instance of <see cref="T"/> based on the value of the element matching the specified
        /// <code>name</code>. An exception of the type <see cref="EnumParseException"/> will be thrown if the
        /// element value doesn't match any of the values of <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the element.</param>
        /// <returns>Returns an instance of </returns>
        public static T GetElementValueAsEnum<T>(this XElement element, XName name) where T : struct {
            XElement child = element == null ? null : element.Element(name);
            return SocialUtils.Enums.ParseEnum<T>(child == null ? null : child.Value);
        }

        /// <summary>
        /// Gets an instance of <see cref="T"/> based on the value of the element matching the specified
        /// <code>name</code>. If the value cant be parsed, <code>fallback</code> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the element.</param>
        /// <param name="fallback">A fallback used if the element value doesn't match any of the values of
        /// <see cref="T"/>.</param>
        /// <returns>Returns an instance of <see cref="T"/>.</returns>
        public static T GetElementValueAsEnum<T>(this XElement element, XName name, T fallback) where T : struct {
            XElement child = element == null ? null : element.Element(name);
            return child == null ? fallback : SocialUtils.Enums.ParseEnum(child.Value, fallback);
        }

        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <code>name</code>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the elements.</param>
        /// <returns>Returns an array of <see cref="XElement"/>.</returns>
        public static XElement[] GetElements(this XElement element, XName name) {
            return element.Elements(name).ToArray();
        }

        /// <summary>
        /// Gets an array <see cref="XElement"/> matching the specified <code>name</code> and parses it using <code>callback</code>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the element.</param>
        /// <param name="callback">A callback function for parsing each element.</param>
        /// <returns>Returns an array of <see cref="T"/>.</returns>
        public static T[] GetElements<T>(this XElement element, XName name, Func<XElement, T> callback) {
            return element.Elements(name).Select(callback).ToArray();
        }

    }

}