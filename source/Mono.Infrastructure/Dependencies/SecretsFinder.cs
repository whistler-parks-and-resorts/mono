// <copyright file="SecretsFinder.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

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
        /// <param name="manager">An instance of the <see cref="ISecretsManager"/> interface.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task<string> GetConnectionString(IConfiguration configuration, ISecretsManager manager)
        {
            var vaultName = configuration["Secrets:Vault"];

            if (vaultName == string.Empty)
            {
                return configuration["Secrets:ConnectionString"] ?? throw new NullReferenceException("The local connection string could not be found.");
            }

            return await manager.GetSecretAsync(
                vaultName ?? throw new NullReferenceException("Vault name was null."),
                configuration["Secrets:ConnectionString"] ?? throw new NullReferenceException("Connection string was null."));
        }
    }
}
