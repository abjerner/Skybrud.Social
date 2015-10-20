using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Dropbox.Options {
    
    public class DropboxGetMetadataOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the file limit. Default is 10,000 (max is 25,000). When listing a folder, the service won't
        /// report listings containing more than the specified amount of files and will instead respond with a
        /// 406 (Not Acceptable) status response.
        /// </summary>
        public int FileLimit { get; set; }

        /// <summary>
        /// Gets or sets the hash. 
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// If <code>true</code> (default), the folder's metadata will include a contents field with a list of metadata
        /// entries for the contents of the folder. If <code>false</code>, the contents field will be omitted.
        /// </summary>
        public bool List { get; set; }

        #endregion
        
        #region Constructors

        /// <summary>
        /// Initializes an instance with default options.
        /// </summary>
        public DropboxGetMetadataOptions() {
            List = true;
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {

            // Construct the query string
            SocialQueryString query = new SocialQueryString();
            if (FileLimit > 0) query.Set("file_limit", FileLimit);
            if (!String.IsNullOrWhiteSpace(Hash)) query.Set("hash", Hash);
            if (!List) query.Set("list", "false");

            return query;

        }

        #endregion
    
    }

}