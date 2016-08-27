using System;
using System.Text;

namespace Skybrud.Social {
    
    public static partial class SocialUtils {

        /// <summary>
        /// Static class with miscellaneous helper methods.
        /// </summary>
        public static class Security {

			/// <summary>
			/// Base64 encodes the specified <code>input</code> string.
			/// </summary>
			/// <param name="input">The input string to be encoded.</param>
			/// <returns>Returns the Base64 encoded string.</returns>
			public static string Base64Encode(string input) {
				return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
			}

			/// <summary>
			/// Base64 decodes the specified <code>input</code> string.
			/// </summary>
			/// <param name="input">The input string to be decoded.</param>
			/// <returns>Returns the Base64 decoded string.</returns>
			public static string Base64Decode(string input) {
				return Encoding.UTF8.GetString(Convert.FromBase64String(input));
			}
		
        }
    
    }

}