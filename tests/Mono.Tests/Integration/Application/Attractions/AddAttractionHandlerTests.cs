// <copyright file="AddAttractionHandlerTests.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Mono.Contracts.Attractions.Add;
using Mono.Tests.Integration.Common;

namespace Mono.Tests.Integration.Application.Attractions
{
    /// <inheritdoc />
    [TestClass]
    public class AddAttractionHandlerTests : BaseIntegrationTest
    {
        /// <summary>
        /// Handle has correct default behavior.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Handle_BehavesCorrectly()
        {
            var request = new AddAttractionRequest("My Attraction Name");

            var result = await TestingDependencies
                .GetHandler<AddAttractionRequest, AddAttractionResponse>()
                .Handle(request, CancellationToken.None);

            var context = TestingDependencies.GetApplicationContext();

            await context.Attractions.SingleAsync();

            Assert.IsNotNull(result.Response);
        }
    }
}
