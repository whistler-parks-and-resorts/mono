// <copyright file="AttractionTests.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Mono.Domain.Attractions;

namespace Mono.Tests.Unit.Domain.Attractions
{
    /// <summary>
    /// Tests for the <see cref="Attraction"/> class.
    /// </summary>
    [TestClass]
    public class AttractionTests
    {
        /// <summary>
        /// Default status is correct.
        /// </summary>
        [TestMethod]
        public void Attraction_HasDefaultStatus()
        {
            var attraction = new Attraction();

            Assert.AreEqual(AttractionStatus.Open, attraction.Status);
        }
    }
}
