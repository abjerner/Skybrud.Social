using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace Skybrud.Social {

    public static partial class SocialUtils {

        /// <summary>
        /// Static class with helper methods for parsing enums.
        /// </summary>
        public static class Enums {

            /// <summary>
            /// Parses the specified <code>str</code> into the enum of type <code>T</code>.
            /// </summary>
            /// <typeparam name="T">The type of the enum.</typeparam>
            /// <param name="str">The string to be parsed.</param>
            /// <returns>Returns an enum of type <code>T</code> from the specified <code>str</code>.</returns>
            public static T ParseEnum<T>(string str) where T : struct {

                // Check whether the type of T is an enum
                if (!typeof(T).IsEnum) throw new ArgumentException("Generic type T must be an enum");

                // Parse the enum
                foreach (string name in Enum.GetNames(typeof(T))) {
                    if (name.ToLowerInvariant() == str.ToLowerInvariant()) {
                        return (T)Enum.Parse(typeof(T), str, true);
                    }
                }

                throw new Exception("Unable to parse enum of type " + typeof(T).Name + " from value \"" + str + "\"");

            }

            /// <summary>
            /// Parses the specified <code>str</code> into the enum of type <code>T</code>.
            /// </summary>
            /// <typeparam name="T">The type of the enum.</typeparam>
            /// <param name="str">The string to be parsed.</param>
            /// <param name="fallback">The fallback if the enum could not be parsed.</param>
            /// <returns>Returns an enum of type <code>T</code> from the specified <code>str</code>.</returns>
            public static T ParseEnum<T>(string str, T fallback) where T : struct {

                // Check whether the type of T is an enum
                if (!typeof(T).IsEnum) throw new ArgumentException("Generic type T must be an enum");

                // Parse the enum
                foreach (string name in Enum.GetNames(typeof(T))) {
                    if (name.ToLowerInvariant() == str.ToLowerInvariant()) {
                        return (T)Enum.Parse(typeof(T), str, true);
                    }
                }

                return fallback;

            }

        }

    }

}