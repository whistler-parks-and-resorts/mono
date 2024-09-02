// <copyright file="AttractionModelBuilder.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mono.Domain.Attractions;

namespace Mono.Infrastructure.DataAccess.Attractions
{
    /// <inheritdoc />
    public class AttractionModelBuilder : IEntityTypeConfiguration<Attraction>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Attraction> builder)
        {
            builder.HasKey(attraction => attraction.Id);
            builder.Property(attraction => attraction.Name);
        }
    }
}
