// <copyright file="GetAttractionStatusResponse.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Mono.Contracts.Attractions.GetStatus
{
    /// <summary>
    /// Response class for a <see cref="GetAttractionStatusRequest"/> class.
    /// </summary>
    public class GetAttractionStatusResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAttractionStatusResponse"/> class.
        /// </summary>
        /// <param name="isOperational">The attraction operational flag.</param>
        public GetAttractionStatusResponse(bool isOperational)
        {
            IsOperational = isOperational;
        }

        /// <summary>
        /// Gets a value indicating whether the attraction is running.
        /// </summary>
        [Required]
        public bool IsOperational { get; }
    }
}
