// <copyright file="SecretsManager.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Mono.Infrastructure.Dependencies
{
    /// <inheritdoc />
    public class SecretsManager : ISecretsManager
    {
        /// <inheritdoc/>
        public async Task<string> GetSecretAsync(string vaultName, string secretKey)
        {
            var client = new SecretClient(new Uri(vaultName), new DefaultAzureCredential());

            var response = await client.GetSecretAsync(secretKey);

            return response.Value.Value;
        }
    }
}
