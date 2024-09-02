// <copyright file="Program.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using MediatorBuddy.AspNet.Registration;
using Mono.Infrastructure.Dependencies;
using Serilog;

namespace Mono.API
{
    /// <summary>
    /// Entry program.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Program
    {
        /// <summary>
        /// Entry point for the application.
        /// </summary>
        /// <param name="args">A <see cref="IEnumerable{T}"/> of command line arguments.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = await SecretsFinder.GetConnectionString(builder.Configuration, new SecretsManager());

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDependencies(connectionString);
            builder.Services.AddMediatorBuddy(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddSerilog((services, configureLogger) => configureLogger
                    .ReadFrom.Configuration(builder.Configuration)
                    .ReadFrom.Services(services));

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            if (!app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(policyBuilder => policyBuilder.WithOrigins(builder.Configuration["CorsOrigin"] ?? string.Empty));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
