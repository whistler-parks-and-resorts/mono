// <copyright file="AddAttractionHandler.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Mono.Application.Attractions.Common;
using Mono.Contracts.Attractions.Add;

namespace Mono.Application.Attractions.Add
{
    /// <inheritdoc />
    public class AddAttractionHandler : EnvelopeHandler<AddAttractionRequest, AddAttractionResponse>
    {
        private readonly IAttractionRepository _attractionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddAttractionHandler"/> class.
        /// </summary>
        /// <param name="attractionRepository">An instance of the <see cref="IAttractionRepository"/> interface.</param>
        public AddAttractionHandler(IAttractionRepository attractionRepository)
        {
            _attractionRepository = attractionRepository;
        }

        /// <inheritdoc/>
        public override async Task<IEnvelope<AddAttractionResponse>> Handle(AddAttractionRequest request, CancellationToken cancellationToken)
        {
            var attraction = AttractionsFactory.Attraction(request);

            if (attraction.IsInvalid)
            {
                return ValidationConstraintNotMet();
            }

            var result = await _attractionRepository.AddEntity(attraction.Entity, cancellationToken);

            if (result == 0)
            {
                return OperationCouldNotBeCompleted();
            }

            var response = AttractionsFactory.AddAttractionResponse(attraction.Entity);

            return Success(response);
        }
    }
}
