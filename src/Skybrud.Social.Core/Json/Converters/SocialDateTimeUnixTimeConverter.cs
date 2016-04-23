using System;
using Newtonsoft.Json;
using Skybrud.Social.Time;

namespace Skybrud.Social.Json.Converters {
    
    /// <summary>
    /// Converts an instance of <see cref="SocialDateTime"/> to and from a Unix timestamp.
    /// </summary>
    public class SocialDateTimeUnixTimeConverter : JsonConverter {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (!(value is SocialDateTime)) return;
            SocialDateTime dt = (SocialDateTime) value;
            writer.WriteValue(dt.UnixTimestamp);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {

            switch (reader.TokenType) {

                case JsonToken.Null:
                    return null;

                case JsonToken.Integer:
                    return SocialDateTime.FromUnixTimestamp((long) reader.Value);

                case JsonToken.Float:
                    return SocialDateTime.FromUnixTimestamp((double) reader.Value);

                case JsonToken.String:
                    Double value;
                    if (Double.TryParse(reader.Value + "", out value)) return SocialDateTime.FromUnixTimestamp(value);
                    throw new JsonSerializationException("String value doesn't match a Unix timestamp: " + reader.Value);

                default:
                    throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);

            }

        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(SocialDateTime);
        }

    }

}