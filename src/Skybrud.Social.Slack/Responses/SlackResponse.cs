using System;
using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Slack.Exceptions;
using Skybrud.Social.Slack.Objects;

namespace Skybrud.Social.Slack.Responses {

    /// <summary>
    /// Class representing a response from the Slack API.
    /// </summary>
    public abstract class SlackResponse : SocialResponse {

        #region Constructor

        protected SlackResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // The Slack API will always return a "200 OK" status even when an error is returned, so we need to check
            // the "ok" property in the boolean instead

            // Get root object
            JsonObject obj = response.GetBodyAsJsonObject();

            // Is the request/response successful?
            bool isOk = obj.GetBoolean("ok");
                
            // Now throw some exceptions
            if (!isOk) throw new SlackException(response, obj.GetString("error"));

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Slack API.
    /// </summary>
    public class SlackResponse<T> : SlackResponse where T : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        protected SlackResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}