using System;
using Carable.AssemblyPayments.Abstractions;
using Carable.AssemblyPayments.ValueTypes;
using Newtonsoft.Json;

namespace Carable.AssemblyPayments.Entities
{
    /// <summary>
    /// The response returned when creating a callback
    /// </summary>
    public class Callback
    {
        /// <summary>
        /// Id of the callback
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// description to identify the callback
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// object or entity to which the callbacks refer
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// object or entity to which the callbacks refer
        /// </summary>
        [JsonProperty("object_type")]
        public ObjectType ObjectType { get; set; }
        /// <summary>
        /// toggle whether callback is active or inactive
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        /// <summary>
        /// When the callback was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// When the callback was updated latest
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// Relative paths that makes it easy to handle callback
        /// </summary>
        [JsonProperty("links")]
        public CallbackLinks Links { get; set; }
    }
}