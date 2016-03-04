using System.IO;

namespace Skybrud.Social.Http.PostData {

    /// <summary>
    /// Class representing a value of a HTTP POST request body.
    /// </summary>
    public interface ISocialPostValue {
        
        /// <summary>
        /// Gets the name/key of the value.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Writes the value to the specified <code>stream</code>.
        /// </summary>
        /// <param name="stream">The stream the value should be written to.</param>
        /// <param name="boundary">The multipart boundary.</param>
        /// <param name="newLine">The characters used to indicate a new line.</param>
        /// <param name="isLast">Whether the value is the last in the request body.</param>
        void WriteToMultipartStream(Stream stream, string boundary, string newLine, bool isLast);

    }

}