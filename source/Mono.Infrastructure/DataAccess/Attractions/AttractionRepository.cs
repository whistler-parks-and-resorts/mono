// <copyright file="AttractionRepository.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Mono.Application.Attractions.Common;
using Mono.Domain.Attractions;
using Mono.Infrastructure.DataAccess.Common;

namespace Mono.Infrastructure.DataAccess.Attractions
{
    /// <summary>
    /// Concrete persistence class for <see cref="Attraction"/>.
    /// </summary>
    public class AttractionRepository : BaseRepository<Attraction>, IAttractionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttractionRepository"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of the <see cref="DbContext"/> class.</param>
        public AttractionRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
