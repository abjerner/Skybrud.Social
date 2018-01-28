#if NET_FRAMEWORK

using System;
using System.Diagnostics;
using System.Reflection;

namespace Skybrud.Social {

    public static partial class SocialUtils {

        /// <summary>
        /// Static class with utility methods related to the version of this assembly.
        /// </summary>
        public static class Version {

            /// <summary>
            /// Gets the assembly version as a string.
            /// </summary>
            /// <returns>A string containing the version of the assembly.</returns>
            public static string GetVersion() {
                return typeof(SocialUtils).Assembly.GetName().Version.ToString();
            }

            /// <summary>
            /// Gets the informational version as a string.
            /// </summary>
            /// <returns>A string containing the informational version of the assembly.</returns>
            public static string GetInformationVersion() {
                Assembly assembly = typeof(SocialUtils).Assembly;
                return assembly.Location == null ? null : FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
            }

            /// <summary>
            /// Gets the file version as a string.
            /// </summary>
            /// <returns>A string containing the file version of the assembly.</returns>
            public static string GetFileVersion() {
                Assembly assembly = typeof(SocialUtils).Assembly;
                return assembly.Location == null ? null : FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
            }

            /// <summary>
            /// Gets the amount of days between the date of this build and the date the project was started - that is the
            /// 30th of July, 2012.
            /// </summary>
            /// <returns>An integer representing the amount of days since the project was started.</returns>
            public static int GetDaysSinceStart() {

                // Get the third bit as a string
                string str = GetFileVersion().Split('.')[2];

                // Parse the string into an integer
                return Int32.Parse(str);

            }

            /// <summary>
            /// Gets the date of this build of Skybrud.Social.
            /// </summary>
            /// <returns>An instance of <see cref="DateTime"/> representing the build date of the assembly.</returns>
            public static DateTime GetBuildDate() {
                return new DateTime(2012, 7, 30).AddDays(GetDaysSinceStart());
            }

            /// <summary>
            /// Gets the build number of the day. This is mostly used for internal
            /// purposes to distinguish builds with the same assembly version.
            /// </summary>
            /// <returns>An integer representing the build number of the day.</returns>
            public static int GetBuildNumber() {

                // Get the fourth bit as a string
                string str = GetFileVersion().Split('.')[3];

                // Parse the string into an integer
                return Int32.Parse(str);

            }

        }

    }

}

#endif