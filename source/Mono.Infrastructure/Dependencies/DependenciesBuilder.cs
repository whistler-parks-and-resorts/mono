// <copyright file="DependenciesBuilder.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mono.Application.Attractions.Common;
using Mono.Infrastructure.DataAccess.Attractions;
using Mono.Infrastructure.DataAccess.Common;

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
        /// <param name="configuration">An instance of the <see cref="IConfiguration"/> interface.</param>
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(serviceConfiguration => serviceConfiguration.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly(),
                    DependenciesConstants.ApplicationAssembly));

            // Data Access
            services.AddDbContext<DbContext, ApplicationContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("Database")));

            services.AddTransient<IAttractionRepository, AttractionRepository>();
        }
    }
}
