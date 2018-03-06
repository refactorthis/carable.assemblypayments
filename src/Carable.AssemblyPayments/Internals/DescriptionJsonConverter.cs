using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Reflection;
using System.ComponentModel;

namespace Carable.AssemblyPayments.Internals
{
    public class DescriptionJsonConverter<T> : JsonConverter
    {
        private static readonly IDictionary<string, T> _stringToEnum;
        private static readonly Dictionary<T, string> _enumToString;

        static DescriptionJsonConverter()
        {
            _stringToEnum = Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(t => GetDescription(t), t => t);
            _enumToString = _stringToEnum.ToDictionary(kv => kv.Value, kv => kv.Key);
        }

        private static string GetDescription(T source)
        {
            FieldInfo fi = source.GetType().GetTypeInfo().GetDeclaredField(source.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }

        public static T Parse(string str)
        {
            if (_stringToEnum.TryGetValue(str, out var value)) return value;
            throw new Exception($"Unknown value {str}");
        }
        /// <summary>
        /// Get description of value
        /// </summary>
        public static string ToString(T value)
        {
            if (_enumToString.TryGetValue(value, out var str))
            {
                return str;
            }
            else
            {
                throw new Exception($"Unknown value {value}");
            }
        }
        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Parse((string)serializer.Deserialize(reader, typeof(string)) ?? string.Empty);
        }
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(ToString((T)value));
        }
    }
}
