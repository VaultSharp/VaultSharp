using System.Collections.Generic;
using Newtonsoft.Json;

namespace VaultSharp.V1.SecretsEngines.Transit
{
    /// <summary>
    /// Represents the rewrap response.
    /// </summary>
    public class RewrapResponse : CipherTextData
    {
        /// <summary>
        /// Gets or sets the batch results.
        /// </summary>
        /// <value>
        /// The batch results.
        /// </value>
        [JsonProperty("batch_results")]
        public List<CipherTextData> BatchedResults
        {
            get; set;
        }
    }
}