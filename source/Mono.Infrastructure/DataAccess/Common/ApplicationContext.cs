// <copyright file="ApplicationContext.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Mono.Domain.Attractions;

namespace Mono.Infrastructure.DataAccess.Common
{
    /// <inheritdoc />
    public sealed class ApplicationContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">An instance of the <see cref="DbContextOptions"/> class.</param>
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();

            Attractions = Set<Attraction>();
        }

        /// <summary>
        /// Gets the attractions dbSet.
        /// </summary>
        public DbSet<Attraction> Attractions { get; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
