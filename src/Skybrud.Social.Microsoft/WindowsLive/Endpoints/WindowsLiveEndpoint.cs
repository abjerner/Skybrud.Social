using Skybrud.Social.Microsoft.WindowsLive.Endpoints.Raw;
using Skybrud.Social.Microsoft.WindowsLive.Responses;

namespace Skybrud.Social.Microsoft.WindowsLive.Endpoints {
    
    /// <summary>
    /// Implementation of the Windows Live endpoint.
    /// </summary>
    public class WindowsLiveEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Microsoft service.
        /// </summary>
        public MicrosoftService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public WindowsLiveRawEndpoint Raw {
            get { return Service.Client.WindowsLive; }
        }

        #endregion

        #region Constructors

        internal WindowsLiveEndpoint(MicrosoftService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public WindowsLiveUserResponse GetSelf() {
            return WindowsLiveUserResponse.ParseResponse(Raw.GetSelf());
        }

        #endregion

    }

}