using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Skybrud.Social.Time;

namespace Skybrud.Social.Json.Converters {
    
    /// <summary>
    /// Converts an instance of <see cref="SocialDateTime"/> to and from the ISO 8601 date format (e.g. 2008-04-12T12:53Z).
    /// </summary>
    public class SocialDateTimeConverter : IsoDateTimeConverter {

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="Newtonsoft.Json.JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (!(value is SocialDateTime)) return;
            SocialDateTime dt = (SocialDateTime) value;
            base.WriteJson(writer, dt.DateTime, serializer);
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

            if (reader.TokenType == JsonToken.Null) return null;

            switch (reader.TokenType) {

                case JsonToken.Null:
                    return null;

                case JsonToken.Date:
                    if (reader.Value is DateTime) return new SocialDateTime((DateTime) reader.Value);
                    throw new JsonSerializationException("Value doesn't match an instance of DateTime: " + reader.Value.GetType());

                case JsonToken.String:
                    if (String.IsNullOrWhiteSpace(reader.Value + "")) return null;
                    if (!String.IsNullOrEmpty(DateTimeFormat)) {
                        return (SocialDateTime) DateTime.ParseExact(reader.Value + "", DateTimeFormat, Culture, DateTimeStyles);
                    }
                    return (SocialDateTime) DateTime.Parse(reader.Value + "", Culture, DateTimeStyles);

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