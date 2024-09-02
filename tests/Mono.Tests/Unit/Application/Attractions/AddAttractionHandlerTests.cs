// <copyright file="AddAttractionHandlerTests.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Mono.Application.Attractions.Add;
using Mono.Application.Attractions.Common;
using Mono.Contracts.Attractions.Add;
using Mono.Domain.Attractions;
using Moq;

namespace Mono.Tests.Unit.Application.Attractions
{
    /// <summary>
    /// Tests for the <see cref="AddAttractionHandler"/> class.
    /// </summary>
    [TestClass]
    public class AddAttractionHandlerTests
    {
        private readonly Mock<IAttractionRepository> _attractionRepository;
        private readonly AddAttractionHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddAttractionHandlerTests"/> class.
        /// </summary>
        public AddAttractionHandlerTests()
        {
            _attractionRepository = new Mock<IAttractionRepository>();
            _handler = new AddAttractionHandler(_attractionRepository.Object);
        }

        /// <summary>
        /// Validation failure returns expected response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task InvalidEntity_ReturnsCorrectResponse()
        {
            var result = await _handler.Handle(new AddAttractionRequest(string.Empty), CancellationToken.None);

            Assert.AreEqual(ApplicationStatus.ValidationConstraintNotMet, result.Status);
        }

        /// <summary>
        /// Non-persisted entity returns expected result.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task EntityNotPersisted_ReturnsCorrectResponse()
        {
            _attractionRepository.Setup(x => x.AddEntity(It.IsAny<Attraction>(), CancellationToken.None))
                .ReturnsAsync(0);

            var result = await _handler.Handle(new AddAttractionRequest("Runaway Mine Train"), CancellationToken.None);

            Assert.AreEqual(ApplicationStatus.OperationCouldNotBeCompleted, result.Status);
        }

        /// <summary>
        /// Successful operation returns expected result.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Success_ReturnsCorrectResponse()
        {
            _attractionRepository.Setup(x => x.AddEntity(It.IsAny<Attraction>(), CancellationToken.None))
                .ReturnsAsync(1);

            var result = await _handler.Handle(new AddAttractionRequest("Runaway Mine Train"), CancellationToken.None);

            Assert.IsNotNull(result.Response);
        }
    }
}
