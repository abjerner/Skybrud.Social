using System;
using System.Globalization;
using System.Xml.Linq;

namespace Skybrud.Social.LinkedIn.ExtensionMethods {

    public static class XElementExtensionMethods {

        public static T ChangeTypeOrDefault<T>(Object value) {
            return ChangeTypeOrDefault<T>(value, CultureInfo.CurrentCulture);
        }

        public static T ChangeTypeOrDefault<T>(Object value, IFormatProvider provider) {

            if (value == null) return default(T);

            IConvertible v = value as IConvertible;
            if (v == null) return default(T);

            TypeCode typeCode = Type.GetTypeCode(typeof(T));

            switch (typeCode) {
                case TypeCode.Boolean:
                    Boolean booleanResult;
                    Boolean.TryParse(v.ToString(provider), out booleanResult);
                    return (T) (object) booleanResult;
                case TypeCode.Char:
                    Char charResult;
                    Char.TryParse(v.ToString(provider), out charResult);
                    return (T) (object) charResult;
                case TypeCode.SByte:
                    SByte sbyteResult;
                    SByte.TryParse(v.ToString(provider), NumberStyles.Integer, provider, out sbyteResult);
                    return (T) (object) sbyteResult;
                case TypeCode.Byte:
                    Byte byteResult;
                    Byte.TryParse(v.ToString(provider), NumberStyles.Integer, provider, out byteResult);
                    return (T) (object) byteResult;
                case TypeCode.Int16:
                    Int16 int16Result;
                    Int16.TryParse(v.ToString(provider), NumberStyles.Integer, provider, out int16Result);
                    return (T) (object) int16Result;
                case TypeCode.UInt16:
                    UInt16 uint16Result;
                    UInt16.TryParse(v.ToString(provider), NumberStyles.Integer, provider, out uint16Result);
                    return (T) (object) uint16Result;
                case TypeCode.Int32:
                    Int32 int32Result;
                    Int32.TryParse(v.ToString(provider), NumberStyles.Integer, provider, out int32Result);
                    return (T) (object) int32Result;
                case TypeCode.UInt32:
                    UInt32 uint32Result;
                    UInt32.TryParse(v.ToString(provider), NumberStyles.Integer, provider, out uint32Result);
                    return (T) (object) uint32Result;
                case TypeCode.Int64:
                    Int64 int64Result;
                    Int64.TryParse(v.ToString(provider), NumberStyles.Integer, provider, out int64Result);
                    return (T) (object) int64Result;
                case TypeCode.UInt64:
                    UInt64 uint64Result;
                    UInt64.TryParse(v.ToString(provider), NumberStyles.Integer, provider, out uint64Result);
                    return (T) (object) uint64Result;
                case TypeCode.Single:
                    Single singleResult;
                    Single.TryParse(v.ToString(provider), NumberStyles.Float | NumberStyles.AllowThousands, provider, out singleResult);
                    return (T) (object) singleResult;
                case TypeCode.Double:
                    Double doubleResult;
                    Double.TryParse(v.ToString(provider), NumberStyles.Float | NumberStyles.AllowThousands, provider, out doubleResult);
                    return (T) (object) doubleResult;
                case TypeCode.Decimal:
                    Decimal decimalResult;
                    Decimal.TryParse(v.ToString(provider), NumberStyles.Number, provider, out decimalResult);
                    return (T) (object) decimalResult;
                case TypeCode.DateTime:
                    DateTime dateTimeValue;
                    DateTime.TryParse(v.ToString(provider), provider, DateTimeStyles.None, out dateTimeValue);
                    return (T) (object) dateTimeValue;
                case TypeCode.String:
                    return (T) (object) v.ToString(provider);
                case TypeCode.Object:
                    return (T) value;
                case TypeCode.DBNull:
                    throw new InvalidCastException();
                case TypeCode.Empty:
                    throw new InvalidCastException();
                default:
                    throw new ArgumentException();
            }

        }

        public static T GetElementValueOrDefault<T>(this XElement element, XName name) {
            if (element == null) return default(T);
            XElement child = element.Element(name);
            return child == null ? default(T) : ChangeTypeOrDefault<T>(child.Value);
        }

        public static T GetAttributeValueOrDefault<T>(this XElement element, XName name) {
            if (element == null) return default(T);
            XAttribute attribute = element.Attribute(name);
            return attribute == null ? default(T) : ChangeTypeOrDefault<T>(attribute.Value);
        }

    }

}