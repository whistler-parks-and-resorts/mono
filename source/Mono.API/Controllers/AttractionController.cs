// <copyright file="AttractionController.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace Mono.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("attraction")]
    public class AttractionController : ControllerBase
    {
        /// <summary>
        /// Queries for the current status of an attraction using an identifier.
        /// </summary>
        /// <param name="id">The attraction identifier.</param>
        /// <returns>An <see cref="IActionResult"/>.</returns>
        [HttpGet("{id:guid}/status", Name = "GetStatus")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public IActionResult GetStatus(Guid id)
        {
            return Ok(id);
        }
    }
}
