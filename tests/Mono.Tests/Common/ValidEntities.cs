// <copyright file="ValidEntities.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Mono.Domain.Attractions;

namespace Mono.Tests.Common
{
    /// <summary>
    /// Helpers for valid entities.
    /// </summary>
    public static class ValidEntities
    {
        /// <summary>
        /// Returns a valid attraction.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns>An attraction object.</returns>
        public static Attraction Attraction(Guid id)
        {
            return new Attraction(id, "Crazy Karts");
        }
    }
}
