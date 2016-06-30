using System;
using Skybrud.Social.Exceptions;

namespace Skybrud.Social {

    public static partial class SocialUtils {

        /// <summary>
        /// Static class with helper methods for parsing enums.
        /// </summary>
        public static class Enums {

            /// <summary>
            /// Gets an array of all values of the specified enum class <code>T</code>.
            /// </summary>
            /// <typeparam name="T">The type of the enum class.</typeparam>
            /// <returns>Returns an array of <code>T</code>.</returns>
            public static T[] GetEnumValues<T>() where T : struct {
                return (T[]) Enum.GetValues(typeof(T));
            }

            /// <summary>
            /// Parses the specified <code>str</code> into the enum of type <code>T</code>.
            /// </summary>
            /// <typeparam name="T">The type of the enum.</typeparam>
            /// <param name="str">The string to be parsed.</param>
            /// <returns>Returns an enum of type <code>T</code> from the specified <code>str</code>.</returns>
            /// <exception cref="ArgumentNullException">If <code>str</code> is <code>null</code> (or white space).</exception>
            /// <exception cref="ArgumentException">If <code>T</code> is not an enum class.</exception>
            /// <exception cref="EnumParseException">If <code>str</code> doesn't match any of the values of <code>T</code>.</exception>
            public static T ParseEnum<T>(string str) where T : struct {

                // Check whether the specified string is NULL (or white space)
                if (String.IsNullOrWhiteSpace(str)) throw new ArgumentNullException("str");

                // Check whether the type of T is an enum
                if (!typeof(T).IsEnum) throw new ArgumentException("Generic type T must be an enum");

                // Convert "str" to camel case and then lowercase
                string modified = Strings.ToCamelCase(str + "").ToLowerInvariant();
                
                // Parse the enum
                foreach (T value in GetEnumValues<T>()) {
                    string ordinal = Convert.ChangeType(value, TypeCode.Int32) + "";
                    string name = value.ToString().ToLowerInvariant();
                    if (ordinal == modified || name == modified) {
                        return (T) Enum.Parse(typeof(T), modified, true);
                    }
                }

                throw new EnumParseException(typeof(T), str);

            }

            /// <summary>
            /// Parses the specified <code>str</code> into the enum of type <code>T</code>.
            /// </summary>
            /// <typeparam name="T">The type of the enum.</typeparam>
            /// <param name="str">The string to be parsed.</param>
            /// <param name="fallback">The fallback if the enum could not be parsed.</param>
            /// <returns>Returns an enum of type <code>T</code> from the specified <code>str</code>.</returns>
            /// <exception cref="ArgumentException">If <code>T</code> is not an enum class.</exception>
            public static T ParseEnum<T>(string str, T fallback) where T : struct {

                // Check whether the type of T is an enum
                if (!typeof(T).IsEnum) throw new ArgumentException("Generic type T must be an enum");

                // Convert "str" to camel case and then lowercase
                string modified = Strings.ToCamelCase(str + "").ToLowerInvariant();

                // Parse the enum
                foreach (T value in GetEnumValues<T>()) {
                    string ordinal = Convert.ChangeType(value, TypeCode.Int32) + "";
                    string name = value.ToString().ToLowerInvariant();
                    if (ordinal == modified || name == modified) {
                        return (T) Enum.Parse(typeof(T), modified, true);
                    }
                }

                return fallback;

            }

        }

    }

}