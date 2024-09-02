// <copyright file="IAddEntity.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Mono.Application.Common.DataAccess
{
    /// <summary>
    /// Designates an interface to add objects to the persistence method.
    /// </summary>
    /// <typeparam name="TRoot">The type of the aggregate root.</typeparam>
    public interface IAddEntity<in TRoot>
        where TRoot : IAggregateRoot
    {
        /// <summary>
        /// Adds an entity to the persistence model.
        /// </summary>
        /// <param name="aggregateRoot">The root to add.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<int> AddEntity(TRoot aggregateRoot, CancellationToken cancellationToken = default);
    }
}
