using System;
using Newtonsoft.Json;
using SignNow.Net.Internal.Helpers.Converters;

namespace SignNow.Net.Model
{
    /// <summary>
    /// Represents sign invite request properties.
    /// </summary>
    public class FreeformInvite
    {
        /// <summary>
        /// Sign invite unique id.
        /// </summary>
        [JsonProperty("unique_id")]
        public string Id { get; set; }

        /// <summary>
        /// Identity of user who invited to sign the document.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Identity of the signers' signature
        /// </summary>
        [JsonProperty("signature_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SignatureId { get; set; }

        /// <summary>
        /// Timestamp sign invite was created.
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(UnixTimeStampJsonConverter))]
        public DateTime Created { get; set; }

        /// <summary>
        /// Email of document owner.
        /// </summary>
        [JsonProperty("originator_email")]
        public string Owner { get; set; }

        /// <summary>
        /// Email of user who invited to sign the document.
        /// </summary>
        [JsonProperty("signer_email")]
        public string Signer { get; set; }

        /// <summary>
        /// Is freeform sign invite canceled or not.
        /// </summary>
        [JsonProperty("canceled", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringToBoolJsonConverter))]
        public bool? IsCanceled { get; set; }
    }
}
