// <copyright file="GetAttractionStatusHandlerTests.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Mono.Application.Attractions.Common;
using Mono.Application.Attractions.GetStatus;
using Mono.Contracts.Attractions.GetStatus;
using Mono.Tests.Common;
using Moq;

namespace Mono.Tests.Unit.Application.Attractions
{
    /// <summary>
    /// Tests for the <see cref="GetAttractionStatusHandler"/> class.
    /// </summary>
    [TestClass]
    public class GetAttractionStatusHandlerTests
    {
        private readonly Mock<IAttractionRepository> _attractionRepository;
        private readonly GetAttractionStatusHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAttractionStatusHandlerTests"/> class.
        /// </summary>
        public GetAttractionStatusHandlerTests()
        {
            _attractionRepository = new Mock<IAttractionRepository>();
            _handler = new GetAttractionStatusHandler(_attractionRepository.Object);
        }

        /// <summary>
        /// Null attraction value, returns an error response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task Handle_AttractionNotFound_ReturnsCorrectResponse()
        {
            _attractionRepository.Setup(x => x.GetById(It.IsAny<Guid>(), CancellationToken.None))
                .ReturnsAsync(() => null);

            var result = await _handler.Handle(new GetAttractionStatusRequest(Guid.NewGuid()), CancellationToken.None);

            Assert.IsNull(result.Response);
        }

        /// <summary>
        /// Attraction found returns a valid response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Handle_AttractionFound_ReturnsCorrectResponse()
        {
            _attractionRepository.Setup(x => x.GetById(It.IsAny<Guid>(), CancellationToken.None))
                .ReturnsAsync(ValidEntities.Attraction(Guid.NewGuid()));

            var result = await _handler.Handle(new GetAttractionStatusRequest(Guid.NewGuid()), CancellationToken.None);

            Assert.IsNotNull(result.Response);
        }
    }
}
