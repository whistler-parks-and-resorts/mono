// <copyright file="AttractionValidator.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using FluentValidation;

namespace Mono.Domain.Attractions
{
    /// <inheritdoc />
    public class AttractionValidator : AbstractValidator<Attraction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttractionValidator"/> class.
        /// </summary>
        public AttractionValidator()
        {
            RuleFor(attraction => attraction.Id).NotEqual(Guid.Empty);

            const int attractionNameLength = 8;
            RuleFor(attraction => attraction.Name).MinimumLength(attractionNameLength);
        }
    }
}
