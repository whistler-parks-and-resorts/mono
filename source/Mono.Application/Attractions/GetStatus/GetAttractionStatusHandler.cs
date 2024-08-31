// <copyright file="GetAttractionStatusHandler.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Mono.Application.Attractions.Common;
using Mono.Contracts.Attractions.GetStatus;

namespace Mono.Application.Attractions.GetStatus
{
    /// <inheritdoc />
    public class GetAttractionStatusHandler : EnvelopeHandler<GetAttractionStatusRequest, GetAttractionStatusResponse>
    {
        private readonly IAttractionRepository _attractionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAttractionStatusHandler"/> class.
        /// </summary>
        /// <param name="attractionRepository">An instance of the <see cref="IAttractionRepository"/> interface.</param>
        public GetAttractionStatusHandler(IAttractionRepository attractionRepository)
        {
            _attractionRepository = attractionRepository;
        }

        /// <inheritdoc/>
        public override async Task<IEnvelope<GetAttractionStatusResponse>> Handle(GetAttractionStatusRequest request, CancellationToken cancellationToken)
        {
            var attraction = await _attractionRepository.GetById(request.Id, cancellationToken);

            if (attraction == null)
            {
                return EntityWasNotFound();
            }

            var response = AttractionsFactory.GetAttractionStatusResponse(attraction);

            return Success(response);
        }
    }
}
