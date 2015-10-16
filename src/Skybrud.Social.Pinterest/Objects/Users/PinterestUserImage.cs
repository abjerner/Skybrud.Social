using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Pinterest.Objects.Users {
    
    /// <summary>
    /// Class representing the profile image of a user. The class serves as a collection of various size of the image.
    /// </summary>
    public class PinterestUserImage : PinterestObject {

        #region Private fields

        private readonly Dictionary<string, PinterestUserImageSize> _sizes = new Dictionary<string, PinterestUserImageSize>();

        #endregion

        #region Properties

        public PinterestUserImageSize this[string alias] {
            get { return _sizes[alias]; }
        }

        /// <summary>
        /// Gets a reference to the small image size, or <code>null</code> if not specified.
        /// </summary>
        public PinterestUserImageSize Small { get; private set; }

        /// <summary>
        /// Gets a reference to the medium image size, or <code>null</code> if not specified.
        /// </summary>
        public PinterestUserImageSize Medium { get; private set; }

        /// <summary>
        /// Gets a reference to the large image size, or <code>null</code> if not specified.
        /// </summary>
        public PinterestUserImageSize Large { get; private set; }

        /// <summary>
        /// Gets whether a small image size is present in the response from the Pinterest API.
        /// </summary>
        public bool HasSmall {
            get { return Small != null; }
        }

        /// <summary>
        /// Gets whether a small medium size is present in the response from the Pinterest API.
        /// </summary>
        public bool HasMedium {
            get { return Medium != null; }
        }

        /// <summary>
        /// Gets whether a small large size is present in the response from the Pinterest API.
        /// </summary>
        public bool HasLarge {
            get { return Large != null; }
        }

        #endregion

        #region Constructors

        private PinterestUserImage(JObject obj) : base(obj) {
            
            _sizes = (
                from property in obj.Properties()
                select PinterestUserImageSize.Parse(property.Value as JObject)
            ).ToDictionary(x => x.Alias, x => x);
            
            Small = _sizes.Values.FirstOrDefault(x => x.Alias == "small");
            Medium = _sizes.Values.FirstOrDefault(x => x.Alias == "medium");
            Large = _sizes.Values.FirstOrDefault(x => x.Alias == "large");
        
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets whether an image size with the specified <code>alias</code> is present in the response from the Pinterest API.
        /// </summary>
        /// <param name="alias">The alias of the image size.</param>
        /// <returns>Returns <code>true </code> if the image size is present in the response from the Pinterest API, otherwise <code>false</code>.</returns>
        public bool HasSize(string alias) {
            return _sizes.ContainsKey(alias);
        }

        #endregion

        #region Static methods

        public static PinterestUserImage Parse(JObject obj) {
            return obj == null ? null : new PinterestUserImage(obj);
        }

        #endregion

    }

}