using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Skybrud.Social.Http.PostData;

namespace Skybrud.Social.Http {
    
    public class SocialPostData {

        private readonly Dictionary<string, ISocialPostValue> _data = new Dictionary<string, ISocialPostValue>();

        public int Count {
            get { return _data.Count; }
        }

        public Dictionary<string, ISocialPostValue>.ValueCollection Values {
            get { return _data.Values; }
        }

        public void Add(string name, string value) {
            _data.Add(name, new SocialPostValue(name, value));
        }

        public void AddFile(string name, string path) {
            _data.Add(name, new SocialPostFileValue(name, path));
        }

        public void AddFile(string name, string path, string contentType, string filename) {
            _data.Add(name, new SocialPostFileValue(name, path, contentType, filename));
        }

        internal static void Write(Stream stream, string str) {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            stream.Write(bytes, 0, bytes.Length);
        }

        public void WriteMultipartFormData(Stream stream, string boundary) {
            int i = 0;
            foreach (ISocialPostValue value in _data.Values) {
                value.WriteToMultipartStream(stream, boundary, "\n", i++ == _data.Count - 1);
            }
        }

        public override string ToString() {
            return String.Join("&", _data.Select(pair => HttpUtility.UrlEncode(pair.Key) + "=" + HttpUtility.UrlEncode(pair.Value.ToString())));
        }
    
    }

}
