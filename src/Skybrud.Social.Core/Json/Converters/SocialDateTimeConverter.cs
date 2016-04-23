using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Skybrud.Social.Time;

namespace Skybrud.Social.Json.Converters {
    
    /// <summary>
    /// Converts an instance of <see cref="SocialDateTime"/> to and from the ISO 8601 date format (e.g. 2008-04-12T12:53Z).
    /// </summary>
    public class SocialDateTimeConverter : IsoDateTimeConverter {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (!(value is SocialDateTime)) return;
            SocialDateTime dt = (SocialDateTime) value;
            base.WriteJson(writer, dt.DateTime, serializer);
        }

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

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(SocialDateTime);
        }

    }

}