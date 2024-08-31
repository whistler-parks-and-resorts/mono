// <copyright file="GetAttractionStatusRequest.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Mono.Contracts.Common.Requests;

namespace Mono.Contracts.Attractions.GetStatus
{
    /// <summary>
    /// A request for an attraction status.
    /// </summary>
    public class GetAttractionStatusRequest : BaseEntityRequest, IEnvelopeRequest<GetAttractionStatusResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAttractionStatusRequest"/> class.
        /// </summary>
        /// <param name="id">The request identifier.</param>
        public GetAttractionStatusRequest(Guid id)
            : base(id)
        {
        }
    }
}
