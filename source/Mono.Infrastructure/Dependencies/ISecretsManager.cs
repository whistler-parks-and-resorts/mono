// <copyright file="ISecretsManager.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

namespace Mono.Infrastructure.Dependencies
{
    /// <summary>
    /// Interface for interacting with secrets.
    /// </summary>
    public interface ISecretsManager
    {
        /// <summary>
        /// Gets a secrets from a vault.
        /// </summary>
        /// <param name="vaultName">The name of the secret vault.</param>
        /// <param name="secretKey">The name of the secret key.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<string> GetSecretAsync(string vaultName, string secretKey);
    }
}
