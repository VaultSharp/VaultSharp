using System.Collections.Generic;
using Newtonsoft.Json;

namespace VaultSharp.V1.SecretsEngines.Transit
{
    /// <summary>
    /// Represents the list response.
    /// </summary>
    public class ListResponse
    {
        /// <summary>
        /// Gets or sets the key names.
        /// </summary>
        /// <value>
        /// The key names.
        /// </value>
        public string[] Keys
        {
            get; set;
        }
    }
}