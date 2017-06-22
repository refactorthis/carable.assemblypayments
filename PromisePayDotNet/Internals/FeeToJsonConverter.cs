using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PromisePayDotNet.Enums;

namespace PromisePayDotNet.Internals
{
    public class FeeToJsonConverter : JsonConverter
    {
        private static readonly IDictionary<string, PaymentOfFeeFrom> stringToEnum;
        private static readonly Dictionary<PaymentOfFeeFrom, string> enumToString;

        static FeeToJsonConverter()
        {
            stringToEnum = new Dictionary<string, PaymentOfFeeFrom>() {
                {"buyer", PaymentOfFeeFrom.Buyer},
                {"seller", PaymentOfFeeFrom.Seller},
                {"cc", PaymentOfFeeFrom.CC},
                {"int_wire", PaymentOfFeeFrom.IntWire},
                {"paypal_payout", PaymentOfFeeFrom.PaypalPayout},
                {"", PaymentOfFeeFrom.None},
            };
            enumToString = stringToEnum.ToDictionary(kv => kv.Value, kv => kv.Key);
        }


        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PaymentOfFeeFrom);
        }

        public static PaymentOfFeeFrom Parse(string str)
        {
            if (stringToEnum.TryGetValue(str, out var receiver)) return receiver;
            throw new Exception($"Unknown value {str}");
        }

        public static string ToString(PaymentOfFeeFrom receiver)
        {
            if (enumToString.TryGetValue(receiver, out var str))
            {
                return str;
            }
            else
            {
                throw new Exception($"Unknown value {receiver}");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Parse((string)serializer.Deserialize(reader, typeof(string)) ?? string.Empty);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(ToString((PaymentOfFeeFrom)value));
        }
    }
}
