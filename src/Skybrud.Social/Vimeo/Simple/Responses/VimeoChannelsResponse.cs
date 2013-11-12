using System.Xml.Linq;
using Skybrud.Social.Vimeo.Simple.Objects;

namespace Skybrud.Social.Vimeo.Simple.Responses {

    public class VimeoChannelsResponse {

        public VimeoChannel[] Channels { get; private set; }
        public XElement XElement { get; private set; }

        public static VimeoChannelsResponse Parse(XElement xChannels) {
            if (xChannels == null || xChannels.Name != "channels") return null;
            return new VimeoChannelsResponse {
                Channels = VimeoChannel.ParseMultiple(xChannels) ?? new VimeoChannel[0],
                XElement = xChannels
            };
        }

    }

}
