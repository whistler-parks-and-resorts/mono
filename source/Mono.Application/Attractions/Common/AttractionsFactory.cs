// <copyright file="AttractionsFactory.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Mono.Application.Common.Validation;
using Mono.Contracts.Attractions.Add;
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

        /// <summary>
        /// Instantiates an attraction object.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>An attraction object.</returns>
        public static ValidationEnvelope<Attraction> Attraction(AddAttractionRequest request)
        {
            return FactoryHelpers.TryValidate(() => new Attraction(request.Name));
        }

        /// <summary>
        /// Instantiates an add attraction response.
        /// </summary>
        /// <param name="attraction">The attraction just added.</param>
        /// <returns>A response object.</returns>
        public static AddAttractionResponse AddAttractionResponse(Attraction attraction)
        {
            return new AddAttractionResponse(attraction.Id);
        }
    }
}
