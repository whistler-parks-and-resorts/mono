// <copyright file="GetAttractionStatusHandlerTests.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Mono.Contracts.Attractions.GetStatus;
using Mono.Tests.Common;
using Mono.Tests.Integration.Common;

namespace Mono.Tests.Integration.Application.Attractions
{
    /// <inheritdoc />
    [TestClass]
    public class GetAttractionStatusHandlerTests : BaseIntegrationTest
    {
        /// <summary>
        /// Handler has correct default behavior.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task Handle_BehavesCorrectly()
        {
            var context = TestingDependencies.GetApplicationContext();

            var id = Guid.NewGuid();

            await context.Attractions.AddAsync(ValidEntities.Attraction(id));

            await context.SaveChangesAsync();

            var result = await TestingDependencies
                .GetHandler<GetAttractionStatusRequest, GetAttractionStatusResponse>()
                .Handle(new GetAttractionStatusRequest(id), CancellationToken.None);

            Assert.IsNotNull(result.Response);
        }
    }
}
