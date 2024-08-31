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
        /// Initializes a new instance of the <see cref="Attraction"/> class.
        /// </summary>
        /// <param name="id">The attraction identifier.</param>
        public Attraction(Guid id)
            : base(id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attraction"/> class.
        /// </summary>
        public Attraction()
        {
        }

        /// <summary>
        /// Gets the current attraction status.
        /// </summary>
        public AttractionStatus Status { get; } = AttractionStatus.Open;
    }
}
