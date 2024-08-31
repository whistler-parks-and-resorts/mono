// <copyright file="AttractionStatus.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

namespace Mono.Domain.Attractions
{
    /// <summary>
    /// Designates the current status of an attraction.
    /// </summary>
    public enum AttractionStatus
    {
        /// <summary>
        /// The attraction is open and working.
        /// </summary>
        Open,

        /// <summary>
        /// The attraction is closed for a designated time period.
        /// </summary>
        Closed,

        /// <summary>
        /// The attraction is currently unavailable due to an unforeseen circumstance.
        /// </summary>
        Inoperable,
    }
}
