// <copyright file="BaseRepository.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Microsoft.EntityFrameworkCore;
using Mono.Application.Common.DataAccess;

namespace Mono.Infrastructure.DataAccess.Common
{
    /// <summary>
    /// Base class for all repositories.
    /// </summary>
    /// <typeparam name="TRoot">The type of the aggregate root.</typeparam>
    public abstract class BaseRepository<TRoot>
        : IAddEntity<TRoot>
    where TRoot : class, IAggregateRoot
    {
        private readonly DbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TRoot}"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of the <see cref="DbContext"/> class.</param>
        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<int> AddEntity(TRoot aggregateRoot, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TRoot>().AddAsync(aggregateRoot, cancellationToken);

            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
