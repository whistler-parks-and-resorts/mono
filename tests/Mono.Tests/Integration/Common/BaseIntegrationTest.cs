// <copyright file="BaseIntegrationTest.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

namespace Mono.Tests.Integration.Common
{
    /// <summary>
    /// Base class for all integration tests.
    /// </summary>
    public abstract class BaseIntegrationTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIntegrationTest"/> class.
        /// </summary>
        protected BaseIntegrationTest()
        {
            var context = TestingDependencies.GetApplicationContext();

            context.Attractions.RemoveRange(context.Attractions);

            context.SaveChanges();
        }
    }
}
