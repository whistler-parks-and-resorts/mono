// <copyright file="AddAttractionResponse.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Mono.Contracts.Common.Responses;

namespace Mono.Contracts.Attractions.Add
{
    /// <inheritdoc />
    public class AddAttractionResponse : BaseEntityResponse
    {
        /// <inheritdoc />
        public AddAttractionResponse(Guid id)
            : base(id)
        {
        }
    }
}
