#if NET_FRAMEWORK

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Skybrud.Social.Http;

namespace Skybrud.Social.OAuth {

    public partial class SocialOAuthClient {

        /// <summary>
        /// Generates the signature.
        /// </summary>
        /// <param name="method">The method for the HTTP request.</param>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The POST data.</param>
        /// <returns>The generated signature.</returns>
        public virtual string GenerateSignature(SocialHttpMethod method, string url, NameValueCollection queryString, NameValueCollection body) {
            HMACSHA1 hasher = new HMACSHA1(new ASCIIEncoding().GetBytes(GenerateSignatureKey()));
            return Convert.ToBase64String(hasher.ComputeHash(new ASCIIEncoding().GetBytes(GenerateSignatureValue(method, url, queryString, body))));
        }

        /// <summary>
        /// Generates the string value used for making the signature.
        /// </summary>
        /// <param name="method">The method for the HTTP request.</param>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string.</param>
        /// <param name="body">The POST data.</param>
        /// <returns>The generated signature value.</returns>
        public virtual string GenerateSignatureValue(SocialHttpMethod method, string url, NameValueCollection queryString, NameValueCollection body) {
            return String.Format(
                "{0}&{1}&{2}",
                method.ToString().ToUpper(),
                Uri.EscapeDataString(url.Split('#')[0].Split('?')[0]),
                Uri.EscapeDataString(GenerateParameterString(queryString, body))
            );
        }


        /// <summary>
        /// Generates the the string of parameters used for making the signature.
        /// </summary>
        /// <param name="queryString">Values representing the query string.</param>
        /// <param name="body">Values representing the POST body.</param>
        /// <returns>The generated parameter string.</returns>
        public virtual string GenerateParameterString(NameValueCollection queryString, NameValueCollection body) {

            // The parameters must be alphabetically sorted
            SortedDictionary<string, string> sorted = new SortedDictionary<string, string>();

            // Add parameters from the query string
            if (queryString != null) {
                foreach (string key in queryString.Keys) {
                    //if (key.StartsWith("oauth_")) continue;
                    sorted.Add(Uri.EscapeDataString(key), Uri.EscapeDataString(queryString[key]));
                }
            }

            // Add parameters from the POST data
            if (body != null) {
                foreach (string key in body.Keys) {
                    //if (key.StartsWith("oauth_")) continue;
                    sorted.Add(Uri.EscapeDataString(key), Uri.EscapeDataString(body[key]));
                }
            }

            // Add OAuth values
            if (!String.IsNullOrEmpty(Callback)) sorted.Add("oauth_callback", Uri.EscapeDataString(Callback));
            sorted.Add("oauth_consumer_key", Uri.EscapeDataString(ConsumerKey));
            sorted.Add("oauth_nonce", Uri.EscapeDataString(Nonce));
            sorted.Add("oauth_signature_method", "HMAC-SHA1");
            sorted.Add("oauth_timestamp", Uri.EscapeDataString(Timestamp));
            if (!String.IsNullOrEmpty(Token)) sorted.Add("oauth_token", Uri.EscapeDataString(Token));
            sorted.Add("oauth_version", Uri.EscapeDataString(Version));

            // Merge all parameters
            return sorted.Aggregate("", (current, pair) => current + ("&" + pair.Key + "=" + pair.Value)).Substring(1);

        }

    }

}

#endif