using System;
using Skybrud.Social.Box.Endpoints.Raw;
using Skybrud.Social.Box.Options.Folders;
using Skybrud.Social.Box.Responses.Folders;

namespace Skybrud.Social.Box.Endpoints {
    
    /// <summary>
    /// Implementation of the folder endpoint.
    /// </summary>
    public class BoxFoldersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Microsoft service.
        /// </summary>
        public BoxService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public BoxFoldersRawEndpoint Raw {
            get { return Service.Client.Folders; }
        }

        #endregion

        #region Constructors

        internal BoxFoldersEndpoint(BoxService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        public BoxGetFolderInfoResponse GetFolderInfo(BoxGetFolderOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return BoxGetFolderInfoResponse.ParseResponse(Raw.GetFolderInfo(options));
        }

        #endregion

    }

}