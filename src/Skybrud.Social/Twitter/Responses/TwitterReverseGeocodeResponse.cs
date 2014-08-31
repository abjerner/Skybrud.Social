using System;
using Skybrud.Social.Json;
using Skybrud.Social.Json.Exceptions;
using Skybrud.Social.Twitter.Enums;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Responses {
    
    public class TwitterReverseGeocodeResponse {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        public TwitterGranularity Granularity { get; private set; }
        public TwitterCoordinates Coordinates { get; private set; }
        public string Url { get; private set; }
        public string Type { get; private set; }
        public TwitterPlace[] Places { get; private set; }

        #endregion

        #region Constructor(s)

        private TwitterReverseGeocodeResponse() {
            // Hide default constructor
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a JSON string representing the object.
        /// </summary>
        public string ToJson() {
            return JsonObject == null ? null : JsonObject.ToJson();
        }

        /// <summary>
        /// Saves the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            if (JsonObject != null) JsonObject.SaveJson(path);
        }

        #endregion

        #region Static methods

        public static TwitterReverseGeocodeResponse ParseJson(string contents) {

            // Deserialize the JSON
            JsonObject json = JsonConverter.ParseObject(contents);

            // Can there be multiple errors? Need. More. Data.
            if (json.HasValue("errors")) {
                JsonArray errors = json.GetArray("errors");
                throw new TwitterException(
                    errors.GetObject(0).GetInt("code"),
                    errors.GetObject(0).GetString("message")
                );
            }

            // Parse the JSON object
            return Parse(json);

        }

        public static TwitterReverseGeocodeResponse Parse(JsonObject obj) {
            if (obj == null) return null;

            JsonObject query = obj.GetObject("query");
            JsonObject result = obj.GetObject("result");
            if (query == null) throw new JsonParseException("Object \"query\" not found.");
            if (result == null) throw new JsonParseException("Object \"result\" not found.");

            JsonObject parameters = query.GetObject("params");
            if (parameters == null) throw new JsonParseException("Object \"params\" not found.");

            return new TwitterReverseGeocodeResponse {
                JsonObject = obj,
                Granularity = TwitterUtils.ParseGranularity(parameters.GetString("granularity")),
                Coordinates = parameters.GetObject("coordinates", TwitterCoordinates.Parse),
                Url = query.GetString("url"),
                Type = query.GetString("type"),
                Places = result.GetArray("places", TwitterPlace.Parse)
            };
        }

        #endregion

    }

}
