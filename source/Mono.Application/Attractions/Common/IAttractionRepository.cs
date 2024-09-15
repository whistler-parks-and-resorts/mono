// <copyright file="IAttractionRepository.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Mono.Application.Common.DataAccess;
using Mono.Domain.Attractions;

namespace Mono.Application.Attractions.Common
{
    /// <summary>
    /// Designates a way to interact with <see cref="Attraction"/> persistence.
    /// </summary>
    public interface IAttractionRepository :
        IAddEntity<Attraction>,
        IGetById<Attraction>
    {
    }
}
