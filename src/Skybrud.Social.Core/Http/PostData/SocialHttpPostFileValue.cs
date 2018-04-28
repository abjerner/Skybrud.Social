using System.IO;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Http.PostData {

    /// <summary>
    /// Class representing a HTTP POST value based on a local file.
    /// </summary>
    public class SocialHttpPostFileValue : IHttpPostValue {

        #region Properties

        /// <summary>
        /// Gets the name/key of the value.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the content type of the file.
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Gets the data of the file.
        /// </summary>
        public byte[] Data { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializea a new instance from the specified <paramref name="name"/> and <paramref name="path"/>.
        /// </summary>
        /// <param name="name">The name of the value.</param>
        /// <param name="path">The path to the file.</param>
        public SocialHttpPostFileValue(string name, string path) : this(name, path, null, null) { }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="name"/>, <paramref name="path"/>,
        /// <paramref name="contentType"/> and <paramref name="filename"/>.
        /// </summary>
        /// <param name="name">The name of the value.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="contentType">The content type of the file.</param>
        /// <param name="filename">The name of the file.</param>
        public SocialHttpPostFileValue(string name, string path, string contentType, string filename) {
        
            Name = name;
            Data = File.ReadAllBytes(path);
            ContentType = contentType;
            FileName = filename ?? Path.GetFileName(path);

            if (ContentType != null) return;
            
            switch (Path.GetExtension(path).ToLower()) {
                case ".jpg":
                case ".jpeg":
                    ContentType = "image/jpeg";
                    break;
                case ".png":
                    ContentType = "image/png";
                    break;
                case ".gif":
                    ContentType = "image/gif";
                    break;
                case ".tiff":
                    ContentType = "image/tiff";
                    break;
            }
        
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Writes the value to the specified <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The stream the value should be written to.</param>
        /// <param name="boundary">The multipart boundary.</param>
        /// <param name="newLine">The characters used to indicate a new line.</param>
        /// <param name="isLast">Whether the value is the last in the request body.</param>
        public void WriteToMultipartStream(Stream stream, string boundary, string newLine, bool isLast) {

            SocialHttpPostData.Write(stream, "--" + boundary + newLine);
            SocialHttpPostData.Write(stream, "Content-Disposition: form-data; name=\"" + Name + "\"; filename=\"" + FileName + "\"" + newLine);
            SocialHttpPostData.Write(stream, "Content-Type: " + ContentType + newLine);
            SocialHttpPostData.Write(stream, newLine);

            stream.Write(Data, 0, Data.Length);

            SocialHttpPostData.Write(stream, newLine);
            SocialHttpPostData.Write(stream, newLine);
            SocialHttpPostData.Write(stream, "--" + boundary + (isLast ? "--" : "") + newLine);

        }

        /// <summary>
        /// Gets a string representation of the value.
        /// </summary>
        /// <returns>Returns the value as a string.</returns>
        public override string ToString() {
            return FileName;
        }

        #endregion

    }

}