// <copyright file="AttractionRepository.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Mono.Application.Attractions.Common;
using Mono.Domain.Attractions;

namespace Mono.Infrastructure.DataAccess.Attractions
{
    /// <inheritdoc />
    public class AttractionRepository : IAttractionRepository
    {
        private readonly DbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttractionRepository"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of the <see cref="DbContext"/> class.</param>
        public AttractionRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<Attraction?> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Attraction>().FirstOrDefaultAsync(attraction => attraction.Id == id, cancellationToken);
        }
    }
}
