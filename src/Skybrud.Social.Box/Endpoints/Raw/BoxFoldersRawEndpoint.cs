using System;
using Skybrud.Social.Box.OAuth;
using Skybrud.Social.Box.Options.Folders;
using Skybrud.Social.Http;

namespace Skybrud.Social.Box.Endpoints.Raw {
    
    public class BoxFoldersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public BoxOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal BoxFoldersRawEndpoint(BoxOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        public SocialHttpResponse GetFolderInfo(BoxGetFolderOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://api.box.com/2.0/folders/" + options.Id, options);
        }

        #endregion

    }

}