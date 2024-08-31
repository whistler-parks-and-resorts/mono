// <copyright file="AttractionController.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mono.Contracts.Attractions.GetStatus;

namespace Mono.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("attraction")]
    public class AttractionController : MediatorBuddyApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttractionController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        public AttractionController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Queries for the current status of an attraction using an identifier.
        /// </summary>
        /// <param name="id">The attraction identifier.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>An <see cref="IActionResult"/>.</returns>
        [HttpGet("{id:guid}/status", Name = "GetStatus")]
        [ProducesResponseType(typeof(GetAttractionStatusResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStatus(Guid id, CancellationToken cancellationToken)
        {
            return await ExecuteRequest(new GetAttractionStatusRequest(id), ResponseOptions.OkObjectResponse<GetAttractionStatusResponse>(), cancellationToken);
        }
    }
}
