using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PromisePayDotNet.Dto;

namespace PromisePayDotNet.Internals
{
    public class ReceiverOfFeeJsonConverter : JsonConverter
    {
        private static readonly IDictionary<string, ReceiverOfFee> stringToEnum;
        private static readonly Dictionary<ReceiverOfFee, string> enumToString;

        static ReceiverOfFeeJsonConverter()
        {
            stringToEnum = new Dictionary<string, ReceiverOfFee>() {
                {"buyer", ReceiverOfFee.Buyer},
                {"seller", ReceiverOfFee.Seller},
                {"cc", ReceiverOfFee.CC},
                {"int_wire", ReceiverOfFee.IntWire},
                {"paypal_payout", ReceiverOfFee.PaypalPayout},
                {"", ReceiverOfFee.None},
            };
            enumToString = stringToEnum.ToDictionary(kv => kv.Value, kv => kv.Key);
        }


        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ReceiverOfFee);
        }

        public static ReceiverOfFee Parse(string str)
        {
            if (stringToEnum.TryGetValue(str, out var receiver)) return receiver;
            throw new Exception($"Unknown value {str}");
        }

        public static string ToString(ReceiverOfFee receiver)
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
            writer.WriteValue(ToString((ReceiverOfFee)value));
        }
    }
}
