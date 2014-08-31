using Skybrud.Social.Vimeo.Advanced.Responses;

namespace Skybrud.Social.Vimeo.Advanced.Endpoints {

    public class VimeoTestEndpoint {

        public VimeoService Service { get; private set; }

        internal VimeoTestEndpoint(VimeoService service) {
            Service = service;
        }

        /// <summary>
        /// API description: This will just repeat back any parameters that you send.
        /// </summary>
        public string Echo() {
            return Service.Client.Echo();
        }

        /// <summary>
        /// API description: Is the user logged in?
        /// </summary>
        public VimeoTestLoginResponse Login() {
            return Service.Client.Login();
        }

    }

}