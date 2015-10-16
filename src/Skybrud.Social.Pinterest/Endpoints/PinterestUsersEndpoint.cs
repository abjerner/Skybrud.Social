using System;
using Skybrud.Social.Http;
using Skybrud.Social.Pinterest.Endpoints.Raw;
using Skybrud.Social.Pinterest.Fields;
using Skybrud.Social.Pinterest.Options;
using Skybrud.Social.Pinterest.Responses.Users;

namespace Skybrud.Social.Pinterest.Endpoints {

    public class PinterestUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Pinterest service.
        /// </summary>
        public PinterestService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public PinterestUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal PinterestUsersEndpoint(PinterestService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <returns>Returns an instance of <code>PinterestGetUserResponse</code> representing the response.</returns>
        public PinterestGetUserResponse GetUser(string identifier) {
            if (String.IsNullOrWhiteSpace(identifier)) throw new ArgumentNullException("identifier");
            return PinterestGetUserResponse.ParseResponse(Raw.GetUser(identifier));
        }

        /// <summary>
        /// Gets information about the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <param name="fields">The fields that should be returned.</param>
        /// <returns>Returns an instance of <code>PinterestGetUserResponse</code> representing the response.</returns>
        public PinterestGetUserResponse GetUser(string identifier, PinterestFieldsCollection fields) {
            if (String.IsNullOrWhiteSpace(identifier)) throw new ArgumentNullException("identifier");
            return PinterestGetUserResponse.ParseResponse(Raw.GetUser(identifier, fields));
        }

        /// <summary>
        /// Gets information about the user matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public PinterestGetUserResponse GetUser(PinterestGetUserOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return PinterestGetUserResponse.ParseResponse(Raw.GetUser(options));
        }

        #endregion

    }

}