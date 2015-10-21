using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Box.Options.Folders {
    
    public class BoxGetFolderOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the folder. An ID of <code>0</code> indicates the root folder.
        /// </summary>
        public string Id { get; set; }

        #endregion
        
        #region Constructors

        /// <summary>
        /// Initializes an instance with default options.
        /// </summary>
        public BoxGetFolderOptions() {
            Id = "0";
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            return new SocialQueryString();
        }

        #endregion
    
    }

}