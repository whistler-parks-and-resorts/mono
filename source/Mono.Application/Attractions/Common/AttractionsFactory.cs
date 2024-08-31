// <copyright file="AttractionsFactory.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Mono.Contracts.Attractions.GetStatus;
using Mono.Domain.Attractions;

namespace Mono.Application.Attractions.Common
{
    /// <summary>
    /// Factory for attraction related objects.
    /// </summary>
    public static class AttractionsFactory
    {
        /// <summary>
        /// Instantiates a response object.
        /// </summary>
        /// <param name="attraction">An <see cref="Attraction"/> class.</param>
        /// <returns>A response object.</returns>
        public static GetAttractionStatusResponse GetAttractionStatusResponse(Attraction attraction)
        {
            return new GetAttractionStatusResponse(attraction.Status == AttractionStatus.Open);
        }
    }
}
