using System;
using Skybrud.Social.Dropbox.OAuth;
using Skybrud.Social.Dropbox.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.Dropbox.Endpoints.Raw {
    
    public class DropboxFilesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public DropboxOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal DropboxFilesRawEndpoint(DropboxOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        public SocialHttpResponse GetMetadata(string path, DropboxGetMetadataOptions options) {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentNullException("path");
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://api.dropboxapi.com/1/metadata/" + path, options);
        }

        #endregion

    }

}