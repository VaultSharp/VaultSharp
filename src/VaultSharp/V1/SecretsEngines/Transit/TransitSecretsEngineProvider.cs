using System.Net.Http;
using System.Threading.Tasks;
using VaultSharp.Core;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.SecretsEngines.Transit
{
    internal class TransitSecretsEngineProvider : ITransitSecretsEngine
    {
        private readonly Polymath _polymath;

        public TransitSecretsEngineProvider(Polymath polymath)
        {
            _polymath = polymath;
        }

        public async Task<Secret<ListResponse>> ListAsync(string mountPoint = SecretsEngineDefaultPaths.Transit, string wrapTimeToLive = null)
        {
            return await _polymath.MakeVaultApiRequest<Secret<ListResponse>>("v1/" + mountPoint.Trim('/') + "/keys", new HttpMethod("LIST"), wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<EncryptionResponse>> EncryptAsync(string keyName, EncryptRequestOptions encryptRequestOptions, string mountPoint = SecretsEngineDefaultPaths.Transit, string wrapTimeToLive = null)
        {
            Checker.NotNull(keyName, "keyName");
            return await _polymath.MakeVaultApiRequest<Secret<EncryptionResponse>>("v1/" + mountPoint.Trim('/') + "/encrypt/" + keyName.Trim('/'), HttpMethod.Post, encryptRequestOptions, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<DecryptionResponse>> DecryptAsync(string keyName, DecryptRequestOptions decryptRequestOptions, string mountPoint = "transit", string wrapTimeToLive = null)
        {
            Checker.NotNull(keyName, "keyName");
            return await _polymath.MakeVaultApiRequest<Secret<DecryptionResponse>>("v1/" + mountPoint.Trim('/') + "/decrypt/" + keyName.Trim('/'), HttpMethod.Post, decryptRequestOptions, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<RewrapResponse>> RewrapAsync(string keyName, RewrapRequestOptions rewrapRequestOptions, string mountPoint = "transit", string wrapTimeToLive = null)
        {
            Checker.NotNull(keyName, "keyName");
            return await _polymath.MakeVaultApiRequest<Secret<RewrapResponse>>("v1/" + mountPoint.Trim('/') + "/rewrap/" + keyName.Trim('/'), HttpMethod.Post, rewrapRequestOptions, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }
    }
}