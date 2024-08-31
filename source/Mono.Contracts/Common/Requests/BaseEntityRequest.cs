// <copyright file="BaseEntityRequest.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

namespace Mono.Contracts.Common.Requests
{
    /// <summary>
    /// Designates a base entity request.
    /// </summary>
    public abstract class BaseEntityRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntityRequest"/> class.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> identifier.</param>
        protected BaseEntityRequest(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the request identifier.
        /// </summary>
        public Guid Id { get; }
    }
}
