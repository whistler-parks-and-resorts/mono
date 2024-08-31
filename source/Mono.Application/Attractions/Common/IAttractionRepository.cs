// <copyright file="IAttractionRepository.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Mono.Domain.Attractions;

namespace Mono.Application.Attractions.Common
{
    /// <summary>
    /// Designates a way to interact with <see cref="Attraction"/> persistence.
    /// </summary>
    public interface IAttractionRepository
    {
        /// <summary>
        /// Retrieves an attraction by an identifier.
        /// </summary>
        /// <param name="id">A <see cref="Guid"/> based identifier.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Attraction?> GetById(Guid id, CancellationToken cancellationToken = default);
    }
}
