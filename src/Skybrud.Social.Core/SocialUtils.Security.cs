using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

            /// <summary>
            /// Gets the MD5 hash of <code>input</code>, and returns that hash. The input string is converted
            /// using <see cref="Encoding.UTF8"/>.
            /// </summary>
            /// <param name="input">The input string</param>
            /// <returns>Returns the hash as a 32-character hexadecimal number.</returns>
            public static string GetMd5Hash(string input) {
                using (MD5 md5 = MD5.Create()) return GetHash(md5, input);
            }

            /// <summary>
            /// Gets the MD5 hash of <code>input</code>, and returns that hash. The input string is converted
            /// using <code>encoding</code>.
            /// </summary>
            /// <param name="input">The input string</param>
            /// <param name="encoding">The encoding to be used for the conversion.</param>
            /// <returns>Returns the hash as a 32-character hexadecimal number.</returns>
            public static string GetMd5Hash(string input, Encoding encoding) {
                using (MD5 md5 = MD5.Create()) return GetHash(md5, input, encoding);
            }

            /// <summary>
            /// Gets the MD5 hash of the file specified by the <code>path</code>. The hash is a 64-character
            /// hexadecimal number.
            /// </summary>
            /// <param name="path">The path of the file.</param>
            /// <returns>Returns the hash as a 32-character hexadecimal number.</returns>
            public static string GetMd5HashFromFile(string path) {
                using (MD5 md5 = MD5.Create()) return GetHashFromFile(md5, path);
            }

            /// <summary>
            /// Gets the SHA1 hash of <code>input</code>, and returns that hash. The input string is converted
            /// using <see cref="Encoding.UTF8"/>.
            /// </summary>
            /// <param name="input">The input string</param>
            /// <returns>Returns the hash as a 40-character hexadecimal number.</returns>
            public static string GetSha1Hash(string input) {
                using (SHA1 sha1 = SHA1.Create()) return GetHash(sha1, input);
            }

            /// <summary>
            /// Gets the SHA1 hash of <code>input</code>, and returns that hash. The input string is converted
            /// using <code>encoding</code>.
            /// </summary>
            /// <param name="input">The input string</param>
            /// <param name="encoding">The encoding to be used for the conversion.</param>
            /// <returns>Returns the hash as a 40-character hexadecimal number.</returns>
            public static string GetSha1Hash(string input, Encoding encoding) {
                using (SHA1 sha1 = SHA1.Create()) return GetHash(sha1, input, encoding);
            }

            /// <summary>
            /// Gets the SHA1 hash of the file specified by the <code>path</code>. The hash is a 40-character
            /// hexadecimal number.
            /// </summary>
            /// <param name="path">The path of the file.</param>
            /// <returns>Returns the hash as a 40-character hexadecimal number.</returns>
            public static string GetSha1FromFile(string path) {
                using (SHA1 sha1 = SHA1.Create()) return GetHashFromFile(sha1, path);
            }

            /// <summary>
            /// Gets the SHA256 hash of <code>input</code>, and returns that hash. The input string is converted using <see cref="Encoding.UTF8"/>.
            /// </summary>
            /// <param name="input">The input string</param>
            /// <returns>Returns the hash as a 64-character hexadecimal number.</returns>
            public static string GetSha256Hash(string input) {
                using (SHA256 sha256 = SHA256.Create()) return GetHash(sha256, input);
            }

            /// <summary>
            /// Gets the SHA256 hash of <code>input</code>, and returns that hash. The input string is converted using <code>encoding</code>.
            /// </summary>
            /// <param name="input">The input string</param>
            /// <param name="encoding">The encoding to be used for the conversion.</param>
            /// <returns>Returns the hash as a 64-character hexadecimal number.</returns>
            public static string GetSha256Hash(string input, Encoding encoding) {
                using (SHA256 sha256 = SHA256.Create()) return GetHash(sha256, input, encoding);
            }

            /// <summary>
            /// Gets the SHA256 hash of the file specified by the <code>path</code>. The hash is a 64-character
            /// hexadecimal number.
            /// </summary>
            /// <param name="path">The path of the file.</param>
            /// <returns>Returns the hash as a 64-character hexadecimal number.</returns>
            public static string GetSha256HashFromFile(string path) {
                using (SHA256 sha256 = SHA256.Create()) return GetHashFromFile(sha256, path);
            }

            /// <summary>
            /// Gets the SHA512 hash of <code>input</code>, and returns that hash. The input string is converted using <see cref="Encoding.UTF8"/>.
            /// </summary>
            /// <param name="input">The input string</param>
            /// <returns>Returns the hash as a 128-character hexadecimal number.</returns>
            public static string GetSha512Hash(string input) {
                using (SHA512 sha512 = SHA512.Create()) return GetHash(sha512, input);
            }

            /// <summary>
            /// Gets the SHA512 hash of <code>input</code>, and returns that hash. The input string is converted using <code>encoding</code>.
            /// </summary>
            /// <param name="input">The input string</param>
            /// <param name="encoding">The encoding to be used for the conversion.</param>
            /// <returns>Returns the hash as a 128-character hexadecimal number.</returns>
            public static string GetSha512Hash(string input, Encoding encoding) {
                using (SHA512 sha512 = SHA512.Create()) return GetHash(sha512, input, encoding);
            }

            /// <summary>
            /// Gets the SHA512 hash of the file specified by the <code>path</code>. The hash is a 128-character
            /// hexadecimal number.
            /// </summary>
            /// <param name="path">The path of the file.</param>
            /// <returns>Returns the hash as a 128-character hexadecimal number.</returns>
            public static string GetSha512HashFromFile(string path) {
                using (SHA512 sha512 = SHA512.Create()) return GetHashFromFile(sha512, path);
            }

            /// <summary>
            /// Gets the hash of <code>input</code> using the specified <code>algorithm</code>.
            /// </summary>
            /// <param name="algorithm">The algorithm to be used.</param>
            /// <param name="input">The input string to be hashed.</param>
            /// <returns>Returns the hash as a hexadecimal number.</returns>
            public static string GetHash(HashAlgorithm algorithm, string input) {
                return GetHash(algorithm, input, Encoding.UTF8);
            }

            /// <summary>
            /// Gets the hash of <code>input</code> using the specified <code>algorithm</code>.
            /// </summary>
            /// <param name="algorithm">The algorithm to be used.</param>
            /// <param name="input">The input string to be hashed.</param>
            /// <param name="encoding">The encoding to be used.</param>
            /// <returns>Returns the hash as a hexadecimal number.</returns>
            public static string GetHash(HashAlgorithm algorithm, string input, Encoding encoding) {
                return BitConverter.ToString(algorithm.ComputeHash(encoding.GetBytes(input))).Replace("-", "").ToLower();
            }

            /// <summary>
            /// Gets the hash of the file specified by the <code>path</code> using the specified <code>algorithm</code>.
            /// </summary>
            /// <param name="algorithm">The algorithm to be used.</param>
            /// <param name="path">The path of the file.</param>
            /// <returns>Returns the hash as a 64-character hexadecimal number.</returns>
            public static string GetHashFromFile(HashAlgorithm algorithm, string path) {
                using (FileStream stream = File.OpenRead(path)) {
                    return BitConverter.ToString(algorithm.ComputeHash(stream)).Replace("-", "").ToLower();
                }
            }

        }

    }

}