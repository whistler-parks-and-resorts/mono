// <copyright file="SecretsFinder.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace Mono.Infrastructure.Dependencies
{
    /// <summary>
    /// Retrieves secrets from a key vault.
    /// </summary>
    public static class SecretsFinder
    {
        /// <summary>
        /// Finds the persistence connection string.
        /// </summary>
        /// <param name="configuration">An instance of the <see cref="IConfiguration"/> interface.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task<string> GetConnectionString(IConfiguration configuration)
        {
            var client = new SecretClient(new Uri(configuration["Secrets:Vault"] ?? string.Empty), new DefaultAzureCredential());

            var response = await client.GetSecretAsync(configuration["Secrets:ConnectionString"]);

            if (response.HasValue)
            {
                return response.Value.Value;
            }

            throw new NullReferenceException("The secret for the connection string was not found.");
        }
    }
}
