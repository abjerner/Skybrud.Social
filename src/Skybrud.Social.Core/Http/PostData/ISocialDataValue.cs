using System.IO;

namespace Skybrud.Social.Http.PostData {

    public interface ISocialPostValue {

        string Name { get; }

        void WriteToMultipartStream(Stream stream, string boundary, string newLine, bool isLast);

    }
}
