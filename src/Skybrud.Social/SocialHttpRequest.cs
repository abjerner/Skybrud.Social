using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Skybrud.Social {
    
    [Obsolete("Marking this as obsolete for now since I'm not sure on the final structure of the class.")]
    public class SocialHttpRequest {

        #region Private fields

        private NameValueCollection _headers = new NameValueCollection();
        private NameValueCollection _queryString = new NameValueCollection();
        private NameValueCollection _postData = new NameValueCollection();

        #endregion

        #region Properties

        public string Method { get; set; }
        public NetworkCredential Credentials { get; set; }

        /// <summary>
        /// Gets or sets the URL of the request. The query string can either be specified directly
        /// in the URL, or separately through the <var>QueryString</var> property.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the encoding of the request. Default is UTF-8.
        /// </summary>
        public Encoding Encoding { get; set; }

        public NameValueCollection Headers {
            get { return _headers; }
            set { _headers = value ?? new NameValueCollection(); }
        }

        public NameValueCollection QueryString {
            get { return _queryString; }
            set { _queryString = value ?? new NameValueCollection(); }
        }

        public NameValueCollection PostData {
            get { return _postData; }
            set { _postData = value ?? new NameValueCollection(); }
        }

        #endregion

        #region Constructor

        public SocialHttpRequest() {
            Method = "GET";
            Encoding = Encoding.UTF8;
        }

        #endregion

        #region Methods

        public SocialHttpResponse GetResponse() {
            
            // Merge the query string
            string url = new UriBuilder(Url).MergeQueryString(QueryString).ToString();

            // Initialize the request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // Set the method
            request.Method = Method;
            request.Credentials = Credentials;

            // Add any headers
            // TODO: Add headers

            // Add the request body (if a POST request)
            if (Method == "POST" && PostData != null && PostData.Count > 0) {
                string dataString = SocialUtils.NameValueCollectionToQueryString(PostData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = dataString.Length;
                using (Stream stream = request.GetRequestStream()) {
                    stream.Write(Encoding.UTF8.GetBytes(dataString), 0, dataString.Length);
                }
            }

            // Get the response
            try {
                return SocialHttpResponse.GetFromWebResponse(request.GetResponse() as HttpWebResponse);
            } catch (WebException ex) {
                if (ex.Status != WebExceptionStatus.ProtocolError) throw;
                return SocialHttpResponse.GetFromWebResponse(ex.Response as HttpWebResponse);
            }

        }

        #endregion

    }

}