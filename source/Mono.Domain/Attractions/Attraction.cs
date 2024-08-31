// <copyright file="Attraction.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Mono.Domain.Attractions
{
    /// <inheritdoc />
    public class Attraction : AggregateRoot
    {
        /// <summary>
        /// Gets the current attraction status.
        /// </summary>
        public AttractionStatus Status { get; } = AttractionStatus.Open;
    }
}
