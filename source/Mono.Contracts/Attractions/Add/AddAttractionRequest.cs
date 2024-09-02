// <copyright file="AddAttractionRequest.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using MediatorBuddy;

namespace Mono.Contracts.Attractions.Add
{
    /// <inheritdoc />
    public class AddAttractionRequest : IEnvelopeRequest<AddAttractionResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddAttractionRequest"/> class.
        /// </summary>
        /// <param name="name">The name of the attraction.</param>
        public AddAttractionRequest(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the attraction name.
        /// </summary>
        [Required]
        [MinLength(8)]
        public string Name { get; }
    }
}