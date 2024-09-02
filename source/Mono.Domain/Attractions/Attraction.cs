// <copyright file="Attraction.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using FluentValidation;

namespace Mono.Domain.Attractions
{
    /// <inheritdoc />
    public class Attraction : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Attraction"/> class.
        /// </summary>
        /// <param name="id">The attraction identifier.</param>
        /// <param name="name">The attraction name.</param>
        public Attraction(Guid id, string name)
            : base(id)
        {
            Name = name;

            new AttractionValidator().ValidateAndThrow(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attraction"/> class.
        /// </summary>
        /// <param name="name">The name of the attraction.</param>
        public Attraction(string name)
            : this(Guid.NewGuid(), name)
        {
        }

        /// <summary>
        /// Gets the current attraction status.
        /// </summary>
        public AttractionStatus Status { get; } = AttractionStatus.Open;

        /// <summary>
        /// Gets the attraction name.
        /// </summary>
        public string Name { get; }
    }
}
