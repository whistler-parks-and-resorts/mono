// <copyright file="BaseEntityResponse.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Mono.Contracts.Common.Responses
{
    /// <summary>
    /// Base class for all entity responses.
    /// </summary>
    public abstract class BaseEntityResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntityResponse"/> class.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        protected BaseEntityResponse(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        [Required]
        public Guid Id { get; }
    }
}
