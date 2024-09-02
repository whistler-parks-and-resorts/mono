// <copyright file="SecretsFinderTests.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.Configuration;
using Mono.Infrastructure.Dependencies;
using Moq;

namespace Mono.Tests.Unit.Infrastructure.Dependencies
{
    /// <summary>
    /// Tests the <see cref="SecretsFinder"/> class.
    /// </summary>
    [TestClass]
    public class SecretsFinderTests
    {
        private readonly Mock<ISecretsManager> _secretsManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretsFinderTests"/> class.
        /// </summary>
        public SecretsFinderTests()
        {
            _secretsManager = new Mock<ISecretsManager>();
        }

        /// <summary>
        /// Empty vault name, uses local connection.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task EmptyVaultName_ReturnsCorrectValue()
        {
            const string connection = "myConnection";

            var values = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("Secrets:Vault", string.Empty),
                new KeyValuePair<string, string?>("Secrets:ConnectionString", connection),
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(values)
                .Build();

            var result = await SecretsFinder.GetConnectionString(configuration, _secretsManager.Object);

            Assert.AreEqual(connection, result);
        }

        /// <summary>
        /// Empty vault and connection string throws exception.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task EmptyVaultName_EmptyConnectionString_ThrowsException()
        {
            var values = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("Secrets:Vault", string.Empty),
                new KeyValuePair<string, string?>("Secrets:ConnectionString", null),
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(values)
                .Build();

            await Assert.ThrowsExceptionAsync<NullReferenceException>(async () => await SecretsFinder.GetConnectionString(configuration, _secretsManager.Object));
        }

        /// <summary>
        /// Null vault name throws exception.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task NullVaultName_ThrowsException()
        {
            var values = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("Secrets:Vault", null),
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(values)
                .Build();

            await Assert.ThrowsExceptionAsync<NullReferenceException>(async () => await SecretsFinder.GetConnectionString(configuration, _secretsManager.Object));
        }

        /// <summary>
        /// Exception is thrown when connection string is null.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task NullConnectingString_ThrowsException()
        {
            var values = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("Secrets:Vault", "vaultName"),
                new KeyValuePair<string, string?>("Secrets:ConnectionString", null),
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(values)
                .Build();

            await Assert.ThrowsExceptionAsync<NullReferenceException>(async () => await SecretsFinder.GetConnectionString(configuration, _secretsManager.Object));
        }

        /// <summary>
        /// Valid response returns expected value.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ValidResponse_ReturnsCorrectly()
        {
            const string expected = "mySecret";

            _secretsManager.Setup(x => x.GetSecretAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(expected);

            var values = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("Secrets:Vault", "vaultName"),
                new KeyValuePair<string, string?>("Secrets:ConnectionString", "connectionString"),
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(values)
                .Build();

            var result = await SecretsFinder.GetConnectionString(configuration, _secretsManager.Object);

            Assert.AreEqual(expected, result);
        }
    }
}
