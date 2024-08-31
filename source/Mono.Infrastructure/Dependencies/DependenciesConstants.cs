// <copyright file="DependenciesConstants.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using System.Reflection;

namespace Mono.Infrastructure.Dependencies
{
    /// <summary>
    /// Static constants for dependency registration.
    /// </summary>
    public static class DependenciesConstants
    {
        /// <summary>
        /// Gets the application assembly.
        /// </summary>
        public static readonly Assembly ApplicationAssembly = Assembly.Load("Mono.Application");
    }
}
