// <copyright file="GetAttractionStatusHandlerTests.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Mono.Application.Attractions.GetStatus;
using Mono.Contracts.Attractions.GetStatus;

namespace Mono.Tests.Integration.Application.Attractions
{
    /// <summary>
    /// Tests for the <see cref="GetAttractionStatusHandler"/> class.
    /// </summary>
    [TestClass]
    public class GetAttractionStatusHandlerTests
    {
        private readonly GetAttractionStatusHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAttractionStatusHandlerTests"/> class.
        /// </summary>
        public GetAttractionStatusHandlerTests()
        {
            _handler = new GetAttractionStatusHandler();
        }

        /// <summary>
        /// Handler has correct default behavior.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task Handle_BehavesCorrectly()
        {
            var result = await _handler.Handle(new GetAttractionStatusRequest(), CancellationToken.None);

            Assert.IsNotNull(result.Response);
        }
    }
}
