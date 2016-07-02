using System;
using Newtonsoft.Json;
using Skybrud.Social.Time;

namespace Skybrud.Social.Json.Converters {
    
    /// <summary>
    /// Converts an instance of <see cref="DateTime"/> to and from a Unix timestamp.
    /// </summary>
    public class DateTimeUnixTimeConverter : JsonConverter {

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="Newtonsoft.Json.JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (!(value is DateTime)) return;
            SocialDateTime dt = (DateTime)value;
            writer.WriteValue(dt.UnixTimestamp);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="Newtonsoft.Json.JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {

            switch (reader.TokenType) {

                case JsonToken.Null:
                    return null;

                case JsonToken.Integer:
                    return SocialUtils.Time.GetDateTimeFromUnixTime((long) reader.Value);

                case JsonToken.Float:
                    return SocialUtils.Time.GetDateTimeFromUnixTime((double) reader.Value);

                case JsonToken.String:
                    Double value;
                    if (Double.TryParse(reader.Value + "", out value)) return SocialUtils.Time.GetDateTimeFromUnixTime(value);
                    throw new JsonSerializationException("String value doesn't match a Unix timestamp: " + reader.Value);

                default:
                    throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);

            }

        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <code>true</code> if this instance can convert the specified object type; otherwise, <code>false</code>.</returns>
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(SocialDateTime);
        }

    }

}