// <copyright file="GlobalExceptionHandlerTests.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Mono.Infrastructure.ErrorHandling.GlobalException;
using Moq;
using Serilog;

namespace Mono.Tests.Unit.Infrastructure.ErrorHandling.GlobalException
{
    /// <summary>
    /// Tests for the <see cref="GlobalExceptionHandler"/> class.
    /// </summary>
    [TestClass]
    public class GlobalExceptionHandlerTests
    {
        /// <summary>
        /// Ensures the logger correctly executes.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Handle_LogsCorrectly()
        {
            var logger = new Mock<ILogger>();

            var handler = new GlobalExceptionHandler(logger.Object);

            await handler.Handle(new GlobalExceptionOccurred(new Exception()), CancellationToken.None);

            logger.Verify(log => log.Error(It.IsAny<Exception>(), It.IsAny<string>(), It.IsAny<DateTime>()), Times.Once);
        }
    }
}
