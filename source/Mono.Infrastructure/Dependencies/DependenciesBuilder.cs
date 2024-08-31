// <copyright file="DependenciesBuilder.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Mono.Infrastructure.Dependencies
{
    /// <summary>
    /// Build for the application dependencies.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DependenciesBuilder
    {
        /// <summary>
        /// Adds all dependencies for the application.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly(),
                    Assembly.Load("Mono.Application")));
        }
    }
}
