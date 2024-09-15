// <copyright file="IGetById.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Mono.Application.Common.DataAccess
{
    /// <summary>
    /// Interface for querying the persistence layer by a <see cref="Guid"/> identifier.
    /// </summary>
    /// <typeparam name="TRoot">The type of the <typeparamref name="TRoot"/>.</typeparam>
    public interface IGetById<TRoot>
        where TRoot : IAggregateRoot
    {
        /// <summary>
        /// Attempts to find an <see cref="IAggregateRoot"/> via its' primary identifier.
        /// </summary>
        /// <param name="id">A <see cref="Guid"/> to query by.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <typeparamref name="TRoot"/> representing the asynchronous operation.</returns>
        Task<TRoot?> GetById(Guid id, CancellationToken cancellationToken = default);
    }
}
