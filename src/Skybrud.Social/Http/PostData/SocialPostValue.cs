using System.IO;

namespace Skybrud.Social.Http.PostData {
    
    public class SocialPostValue : ISocialPostValue {

        public string Name { get; private set; }

        public string Value { get; set; }

        public SocialPostValue(string name, string value) {
            Name = name;
            Value = value;
        }

        public void WriteToMultipartStream(Stream stream, string boundary, string newLine, bool isLast) {

            SocialPostData.Write(stream, "--" + boundary + newLine);
            SocialPostData.Write(stream, "Content-Disposition: form-data; name=\"" + Name + "\"" + newLine);
            SocialPostData.Write(stream, newLine);

            SocialPostData.Write(stream, Value);

            SocialPostData.Write(stream, newLine);
            SocialPostData.Write(stream, "--" + boundary + (isLast ? "--" : "") + newLine);

        }

        public override string ToString() {
            return Value;
        }

    }

}