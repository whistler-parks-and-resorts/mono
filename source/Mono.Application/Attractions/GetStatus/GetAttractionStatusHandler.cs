// <copyright file="GetAttractionStatusHandler.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Mono.Application.Attractions.Common;
using Mono.Contracts.Attractions.GetStatus;
using Mono.Domain.Attractions;

namespace Mono.Application.Attractions.GetStatus
{
    /// <inheritdoc />
    public class GetAttractionStatusHandler : EnvelopeHandler<GetAttractionStatusRequest, GetAttractionStatusResponse>
    {
        /// <inheritdoc/>
        public override Task<IEnvelope<GetAttractionStatusResponse>> Handle(GetAttractionStatusRequest request, CancellationToken cancellationToken)
        {
            var response = AttractionsFactory.GetAttractionStatusResponse(new Attraction());

            return Task.FromResult(Success(response));
        }
    }
}
