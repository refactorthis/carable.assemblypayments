using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Carable.AssemblyPayments.ValueTypes;

namespace Carable.AssemblyPayments.Internals
{
    public class FeePayerToJsonConverter : JsonConverter
    {
        private static readonly IDictionary<string, FeePayer> _stringToEnum;
        private static readonly Dictionary<FeePayer, string> _enumToString;

        static FeePayerToJsonConverter()
        {
            _stringToEnum = new Dictionary<string, FeePayer>() {
                {"buyer", FeePayer.Buyer},
                {"seller", FeePayer.Seller},
                {"cc", FeePayer.CC},
                {"int_wire", FeePayer.IntWire},
                {"paypal_payout", FeePayer.PaypalPayout},
                {"", FeePayer.None},
            };
            _enumToString = _stringToEnum.ToDictionary(kv => kv.Value, kv => kv.Key);
        }


        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(FeePayer);
        }

        public static FeePayer Parse(string str)
        {
            if (_stringToEnum.TryGetValue(str, out var payer)) return payer;
            throw new Exception($"Unknown value {str}");
        }

        public static string ToString(FeePayer payer)
        {
            if (_enumToString.TryGetValue(payer, out var str))
            {
                return str;
            }
            else
            {
                throw new Exception($"Unknown value {payer}");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Parse((string)serializer.Deserialize(reader, typeof(string)) ?? string.Empty);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(ToString((FeePayer)value));
        }
    }
}
