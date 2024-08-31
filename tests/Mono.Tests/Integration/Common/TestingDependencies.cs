// <copyright file="TestingDependencies.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mono.Infrastructure.DataAccess.Common;
using Mono.Infrastructure.Dependencies;

namespace Mono.Tests.Integration.Common
{
    /// <summary>
    /// Builds a service provider for testing dependencies.
    /// </summary>
    public static class TestingDependencies
    {
        private static readonly IServiceProvider ServiceProvider = BuildProvider();

        /// <summary>
        /// Returns a <see cref="IRequestHandler{TRequest,TResponse}"/> for the defined types.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request object.</typeparam>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>An instance of a request handler for testing.</returns>
        public static IRequestHandler<TRequest, IEnvelope<TResponse>> GetHandler<TRequest, TResponse>()
            where TRequest : IRequest<IEnvelope<TResponse>>
        {
            return ServiceProvider.GetRequiredService<IRequestHandler<TRequest, IEnvelope<TResponse>>>();
        }

        /// <summary>
        /// Gets the testing application context.
        /// </summary>
        /// <returns>The testing <see cref="ApplicationContext"/>.</returns>
        public static ApplicationContext GetApplicationContext()
        {
            return ServiceProvider.GetRequiredService<ApplicationContext>();
        }

        private static ServiceProvider BuildProvider()
        {
            var collection = new ServiceCollection();

            var testConnectionString = Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING") ??
                "Server=.\\SQLExpress;Database=mono-local-sql;Trusted_Connection=true;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true;";

            var inMemoryCollection = new List<KeyValuePair<string, string?>>
            {
               new KeyValuePair<string, string?>("ConnectionStrings:Database", testConnectionString),
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemoryCollection)
                .Build();

            collection.AddDependencies(configuration);

            return collection.BuildServiceProvider();
        }
    }
}
