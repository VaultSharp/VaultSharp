using System.Collections.Generic;
using Newtonsoft.Json;

namespace VaultSharp.V1.SecretsEngines.Transit
{
    /// <summary>
    /// Represents the Decrypt Request Options.
    /// </summary>
    public class RewrapRequestOptions : RewrapItem
    {
        /// <summary>
        /// [optional]
        ///  Specifies the version of the key to use for the operation.
        ///  If not set, uses the latest version. 
        ///  Must be greater than or equal to the key's min_encryption_version, if set.
        /// </summary>
        [JsonProperty("key_version")]
        public int? KeyVersion { get; set; }

        /// <summary>
        /// [optional]
        /// Specifies a list of items to be rewrapped in a single batch. 
        /// When this parameter is set, if the parameters 'ciphertext', 'context' and 'nonce' are also set, they will be ignored.
        /// </summary>
        [JsonProperty("batch_input")]
        public List<RewrapItem> BatchedRewrapItems { get; set; }
    }
}